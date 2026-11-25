"""Restore both frozen artifacts into a new cache and verify what the consumer actually runs."""
import argparse
import hashlib
import json
import os
from pathlib import Path
import subprocess
import tempfile
from xml.etree import ElementTree as ET
from zipfile import ZipFile

ROOT = Path(__file__).resolve().parent
LIB = ROOT / "AIKernel.Integration.LocalLlm"
TESTS = ROOT / "AIKernel.Integration.LocalLlm.Tests"
OFFICIAL = "https://api.nuget.org/v3/index.json"
FROZEN = {
    "AIKernel.Kernel": "e218820a47f58a53d929e6e9c390d4c443a779324e3d425a95e57903a1d66c26",
    "AIKernel.Providers.LocalLlm": "289414f107f36c7c9a61bdb0749fe2b712cc00c7d2932cfac19f7c9973c743ab",
}


def digest(path):
    with path.open("rb") as stream:
        return hashlib.file_digest(stream, "sha256").hexdigest()


def require(condition, message):
    if not condition:
        raise ValueError(message)


def check_archives(feed):
    for name, expected in FROZEN.items():
        require(digest(feed / f"{name}.0.3.0.nupkg") == expected, f"Frozen package differs: {name}")


def write_config(path, feed):
    root = ET.Element("configuration")
    sources = ET.SubElement(root, "packageSources")
    ET.SubElement(sources, "clear")
    mapping = ET.SubElement(root, "packageSourceMapping")
    for key, value, patterns in [("frozen", str(feed), FROZEN), ("public", OFFICIAL, ["*"])]:
        ET.SubElement(sources, "add", key=key, value=value)
        source = ET.SubElement(mapping, "packageSource", key=key)
        for pattern in patterns:
            ET.SubElement(source, "package", pattern=pattern)
    ET.ElementTree(root).write(path, encoding="utf-8", xml_declaration=True)


def verify_graph(project, cache, feed):
    assets = json.loads((project / "obj/project.assets.json").read_bytes())
    require({Path(p).resolve() for p in assets["packageFolders"]} == {cache}, "Unexpected package folder")
    entries = {}
    for key, lib in assets["libraries"].items():
        if lib["type"] != "package":
            require(project == TESTS and lib["type"] == "project"
                    and (project / lib["path"]).resolve() == LIB / (LIB.name + ".csproj"),
                    f"Unexpected source project in frozen package graph: {key}")
            continue
        name, version = key.rsplit("/", 1)
        package = cache / lib["path"]
        source = json.loads((package / ".nupkg.metadata").read_bytes())["source"]
        if name in FROZEN:
            require(Path(source).resolve() == feed and version == "0.3.0", key)
            require(digest(package / f"{key.replace('/', '.').lower()}.nupkg") == FROZEN[name], key)
        else:
            require(source.rstrip("/") == OFFICIAL, f"Nonofficial dependency: {key}")
            if name.startswith("AIKernel."):
                require(version == "0.1.4", key)
        entries[name] = version
    require(FROZEN.keys() <= entries.keys(), "Frozen reference missing")
    return entries


def check_output(feed, output):
    hashes = {}
    for name in FROZEN:
        with ZipFile(feed / f"{name}.0.3.0.nupkg") as package:
            if name == "AIKernel.Providers.LocalLlm":
                manifest = json.loads(package.read("providers/local-llm.provider.json"))
                require(manifest["providerId"] == "local-llm" and manifest["capabilities"] == ["chat.local"],
                        "Unexpected LocalLlm manifest")
            binaries = [p for p in package.namelist() if p.startswith("lib/net10.0/") and p.endswith(".dll")]
            native = [p for p in package.namelist() if "/native/" in p and not p.endswith("/")]
            if name == "AIKernel.Kernel":
                required = {"runtimes/win-x64/native/aikernel_cpu_accel.dll",
                            "runtimes/win-x64/native/aikernel_cuda_driver.dll",
                            "runtimes/linux-x64/native/libaikernel_cpu_accel.so",
                            "runtimes/linux-x64/native/libaikernel_cuda_driver.so"}
                require(required <= set(native), "Missing native asset")
            require(len(binaries) == 1, name)
            for entry in binaries + native:
                dest = output / (entry if entry in native else Path(entry).name)
                expected = hashlib.sha256(package.read(entry)).hexdigest()
                require(digest(dest) == expected, str(dest))
                hashes[entry] = expected
    return hashes


def check_shared_output(cache, output, graph):
    """Compare the shared AIKernel implementation files loaded by the test host to the locked packages."""
    hashes = {}
    for name, version in graph.items():
        if not name.startswith("AIKernel.") or name in FROZEN:
            continue
        package = cache / name.lower() / version
        with ZipFile(package / f"{name.lower()}.{version}.nupkg") as archive:
            for entry in archive.namelist():
                if entry.startswith("lib/net10.0/") and entry.endswith(".dll"):
                    dll = Path(entry).name
                    expected = hashlib.sha256(archive.read(entry)).hexdigest()
                    require(digest(output / dll) == expected, f"Shared output differs: {dll}")
                    hashes[dll] = expected
    return hashes


def main():
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument("--feed", type=Path, required=True)
    p.add_argument("--results", type=Path, help="New directory for an isolated cache and evidence")
    p.add_argument("--model", type=Path, help="Bonsai-1.7B-Q1_0.gguf for the full bilingual suite")
    args = p.parse_args()
    feed = args.feed.resolve(strict=True)
    check_archives(feed)
    results = args.results.resolve() if args.results else Path(tempfile.mkdtemp(prefix="aikernel-local-llm-"))
    if args.results:
        results.mkdir(parents=True, exist_ok=False)
    env = os.environ.copy()
    cache = results / "packages"
    env["NUGET_PACKAGES"] = str(cache)
    env.pop("AIKERNEL_TEST_BONSAI_GGUF", None)
    if args.model:
        env["AIKERNEL_TEST_BONSAI_GGUF"] = str(args.model.resolve(strict=True))
        require(args.model.is_file(), "Model fixture is not a file")
    config = results / "NuGet.Config"
    write_config(config, feed)
    project = TESTS / (TESTS.name + ".csproj")

    def dotnet(*arguments):
        subprocess.run(["dotnet", *arguments], cwd=ROOT, env=env, check=True)

    dotnet("restore", project, "--locked-mode", "--no-http-cache", "--configfile", config)
    graph = {p.name: verify_graph(p, cache, feed) for p in (LIB, TESTS)}
    dotnet("build", project, "-c", "Release", "--no-restore")
    output = TESTS / "bin/Release/net10.0"
    binaries = check_output(feed, output)
    shared = check_shared_output(cache, output, graph[TESTS.name])
    dotnet("test", project, "-c", "Release", "--no-build", "--no-restore",
           "--results-directory", results, "--logger", "trx;LogFileName=integration.trx")
    counts = ET.parse(results / "integration.trx").find(".//{*}Counters").attrib
    require(int(counts["passed"]) > 0, "No passing tests")
    if args.model:
        require(counts["passed"] == counts["total"], "Full run requires every test")
    check_archives(feed)
    report = {"packageSha256": FROZEN, "restored": graph, "binarySha256": binaries,
              "sharedDllSha256": shared, "modelSupplied": bool(args.model), "tests": counts}
    (results / "verification.json").write_text(json.dumps(report, indent=2), encoding="utf-8")
    print(results / "verification.json")


if __name__ == "__main__":
    main()
