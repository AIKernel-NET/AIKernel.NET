---
updated: 2026-11-08
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Package Release Alignment v0.1.3

[Japanese](package-release-alignment-v0.1.3-ja.md)

This note is the developer-facing source for package alignment in the
AIKernel.NET 0.1.3 canonical series. It exists so package maintainers can tell
which instructions are current, which instructions are historical, and which
versions are safe to combine during local validation.

## Current Package Line

The stable release target is `0.1.3`. Local development-build verification does
not mean stable packages were published or that stable PyPI wheels passed verification.

During local validation, use one matching development family at a time:

| Package system | Local development version |
|---|---|
| NuGet | `0.1.3-dev<build-number>` |
| PyPI | `0.1.3.dev<build-number>` |

Do not combine stable `0.1.3` packages with local packages from another build
unless the task explicitly tests migration or fallback behavior.

## Repository Order

Build and verify repositories in this order:

1. `AIKernel.NET`
2. `AIKernel.Core`
3. `AIKernel.Control`
4. `AIKernel.Providers`
5. `AIKernel.Cuda13.0`
6. `AIKernel.Wasm`
7. `AIKernel.Tools`
8. `AIKernel.Demo`
9. `AIKernel.Doom`

The first seven repositories define package surfaces. Demo and Doom are source
demos that validate integration; they are not NuGet or PyPI publication targets.
Native Dawn verification is a separate lane.

## Local Verification Record: `0.1.3-dev3`

Local verification as of 2026-11-08. The workspace feed is
`artifacts/local-nuget/v0.1.3-dev3/`; logs are under
`artifacts/contract-validation/v0.1.3-dev3/`. Release counts are from successful
runs only and exclude retries and separate smoke tests.

| Repository | Release tests passed | NuGet packages | Additional checks |
|---|---:|---:|---|
| AIKernel.NET | 173 | 4 | Includes 37 cases in `GpuCanonicalContractTests` |
| AIKernel.Core | 439 | 5 | Restored and verified against the dev3 contract packages |
| AIKernel.Control | 42 | 6 | Regenerated Python DLLs and dependency manifests; verified loading |
| AIKernel.Providers | 120 | 12 | Regenerated and loaded Python DLLs, including Compute; verified registration |
| AIKernel.Cuda13.0 | 21 | 1 | Verified the Windows x64 native ABI and loading from an isolated Python bundle; not model inference |
| AIKernel.Wasm | 64 | 9 | Ran three WebGPU passes in a real browser. Verified bundled DLLs and three `.create()` methods in the isolated dev3 wheel |
| AIKernel.Tools | 34 | 6 | Verified the CLI, bundled DLL loading, and eight Python tests with the isolated dev3 wheel |

The feed contains 43 NuGet packages. Demo is not covered by this record.
Separately, Doom passed 566 Release tests, 42 JavaScript tests, and four
versioned-page startup and rendering tests, and started in both GPU and CPU
modes in Edge. This is not a full browser lifecycle test.

## Stable Release Gates

1. Review changes per repository and pin the release commits. If the package
   payload changes, use a fresh development version and feed rather than
   overwriting dev3.
2. Verify Demo integration and any optional native
   capabilities included in the release scope, against the selected dependency graph.
3. Regenerate the bundle for each PyPI target from the matching package line and
   test a wheel installed in a clean environment. Recheck `.create()` for
   `WasmRuntime`, `WasmRuntimeContext`, and `WebGpuWasmBackend` with the stable DLLs.
   Check the inputs to the publishing workflow so stable wheels cannot bundle
   development-build binaries.
4. After release approval, build stable `0.1.3` artifacts anew in dependency order.
   Verify dependencies, payloads, hashes, and restore from a clean consumer.
   The NET repository defaults to a local version: pass `UseLocalPackageVersion=false`
   explicitly when building the stable contracts.
5. Verify stable packages from the official feeds before switching the website's
   installation instructions. Publish a new Doom URL only after the lifecycle
   and corresponding-source/license gates pass; do not overwrite the old version.

## Source Of Truth

- Package installation UX lives in
  [Package Installation Guide](../operations/PACKAGE_INSTALLATION_GUIDE.md).
- Demo execution UX lives in
  [Demo Programs Guide](../operations/DEMO_PROGRAMS_GUIDE.md).
- GPU migration context lives in
  [GPU Canonical Migration](../migration/v0.1.3-gpu-canonical-migration.md).
- XML comment rules live in
  [XML Documentation Policy](../operations/XML_DOCUMENTATION_POLICY-v0.1.3.md).

Historical documents may keep older version numbers in titles and filenames.
Current install commands, package tables, and local validation examples must
use the 0.1.3 family.

## Developer Checklist

- Keep NuGet and PyPI package families synchronized for public examples.
- Keep repository-specific build notes in the repository that owns the build.
- Keep stable install commands separate from local `dev` validation commands.
- Keep Demo and Doom documentation explicit that they are validation/demo
  surfaces, not package-publication roots.
- Keep public API documentation bilingual through .NET XML documentation tags
  or paired include files.
