---
title: "Run your first sample"
lang: en
description: "Restore and run the verified AIKernel CoreRuntime sample with .NET 10, compare the expected output, and diagnose common setup failures."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.4"
documentation_target: "0.1.4"
updated: "2026-11-23"
---

# Run your first sample

Run a small console application to see how AIKernel separates routing, available capabilities, time, and file access. The sample needs no API key, model download, or GPU at runtime.

## Prerequisites and version

Install Git and the .NET 10 SDK. Check the SDK with `dotnet --version`. Downloading the repository and restoring NuGet dependencies initially require network access.

This sample uses AIKernel 0.1.4 from NuGet. The output below was verified on Windows on November 23, 2026. To see a model respond before installing the SDK, open the [model-switching demo](https://aikernel.net/en/demo/chat/).

## Get the verified sample

Use a new directory so that checking out this revision does not disturb work in another copy.

```powershell
git clone https://github.com/AIKernel-NET/AIKernel.Demo.git aikernel-first-run
cd aikernel-first-run
git checkout 800f92fc816bb792e91d2a31d5ec363a8c737278
dotnet --version
```

## Restore and run one project

Run these commands from `aikernel-first-run`. Building the entire solution is unnecessary for this exercise.

```powershell
dotnet restore src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj -p:StablePackageVersion=0.1.4 -p:UseLocalPackageVersion=false
dotnet run --project src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj -c Release --no-restore -p:StablePackageVersion=0.1.4 -p:UseLocalPackageVersion=false
```

After any build messages, expect:

```text
AIKernel.Demo.CoreRuntime
router.route=local.default
registry=InMemoryCapabilityRegistry
clock.replaying=False
vfs.provider=MemoryFileProvider
```

A final `contract.map=` line lists the public types touched by the sample. `local.default` is the selected route. `False` means the clock is not replaying. This exercise constructs runtime components; it does not call an LLM or boot a complete Kernel. It establishes that the basic packages can run before you introduce credentials or external services.

## Troubleshooting

| Symptom | Check |
| --- | --- |
| `dotnet` cannot be found | Install the SDK, not just the runtime, and reopen the terminal. |
| SDK or target framework error | Check for a .NET 10 SDK with `dotnet --list-sdks`. If your working directory or a parent contains `global.json`, also check its SDK selection. |
| `NU1301` or restore failure | Check NuGet connectivity, proxy settings, and `NuGet.config`. An LLM API key cannot fix package restoration. |
| Project file not found | Run from the directory containing `AIKernel.Demo.slnx`. |
| Missing types or methods | Check out the pinned revision and include the 0.1.4 properties in both commands. |

The verification used project and configuration files retrieved from the pinned public commit, restored packages from NuGet into an empty package directory, and ran the sample. Use the table above to diagnose differences in network or proxy configuration.

Continue with [Read and change the sample](../tutorials/first-kernel.md) to connect each output line to code, or [Core concepts](../concepts/index.md) for the terminology.

To generate an answer using your own CPU and model weights, see the local inference steps in the [0.1.4 upgrade guide](upgrade-0-1-4.md).
