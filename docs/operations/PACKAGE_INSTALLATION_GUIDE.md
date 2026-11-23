---
title: "AIKernel Package Installation Guide"
description: "Install AIKernel 0.1.4 from NuGet or PyPI, check the resolved version, and choose packages for runtime, hosting, or HTTP and MCP."
updated: 2026-11-23
published: 2026-06-16
version: "0.1.4"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel Package Installation Guide

This guide uses the published 0.1.4 packages. If you are starting from an empty folder, the [Quick Start](../overview/quick-start.md) gives you a project to run and the output to check. If you already use 0.1.3, start with the [0.1.4 migration guide](../overview/upgrade-0-1-4.md).

## NuGet Packages

From the directory containing your .NET project, check that .NET 10 is available and add the runtime package.

```console
dotnet --list-sdks
dotnet add package AIKernel.Core --version 0.1.4
dotnet list package --include-transitive
```

Check that `AIKernel.Core` resolves to 0.1.4. If your solution uses Central Package Management, check the corresponding `PackageVersion` in `Directory.Packages.props`. If restore fails, check which feed serves `AIKernel.*` and run `dotnet nuget list source` before changing versions.

| What you want to build | Add |
| --- | --- |
| A console sample using the runtime | [AIKernel.Core 0.1.4](https://www.nuget.org/packages/AIKernel.Core/0.1.4) |
| An application using .NET Generic Host | [AIKernel.Hosting 0.1.4](https://www.nuget.org/packages/AIKernel.Hosting/0.1.4) |
| One application service exposed over HTTP and MCP | [AIKernel.Providers.Distributed 0.1.4](https://www.nuget.org/packages/AIKernel.Providers.Distributed/0.1.4) with Hosting |

For other providers and dependencies, see the [module map](../architecture/module-map.md) or the [published NuGet packages](https://www.nuget.org/profiles/AIKernel-NET).

## Add WebGPU

Choose the provider that fits your host. Both use .NET 10 and support the AIKernel 0.1.4 SDK.

| Host | Package | Use |
| --- | --- | --- |
| Native .NET | [AIKernel.Dawn.Provider 0.1.4](https://www.nuget.org/packages/AIKernel.Dawn.Provider/0.1.4) | Run `compute.vector_add` with D3D12 or Vulkan |
| Browser WebAssembly | [AIKernel.Wasm.WebGpuComputeProvider 0.1.5](https://www.nuget.org/packages/AIKernel.Wasm.WebGpuComputeProvider/0.1.5) | Upload pages of immutable OPFS weights into a WebGPU buffer |

```bash
dotnet add package AIKernel.Dawn.Provider --version 0.1.4
dotnet add package AIKernel.Wasm.WebGpuComputeProvider --version 0.1.5
```

Dawn was verified on Linux with Ubuntu 24.04 and a Vulkan driver. Serve the browser assets from localhost or HTTPS and use a dedicated worker. The [browser and WebGPU guide](../wasm/runtime.md) shows the prerequisites and how to verify execution.

## Use CUDA

For CUDA on Windows x64 and Linux x64, use the CUDA Driver bundled with `AIKernel.Kernel` 0.1.4. Its only native runtime prerequisite is the NVIDIA driver.

```bash
dotnet add package AIKernel.Kernel --version 0.1.4
```

`AIKernel.Cuda13.0` is the legacy LibTorch reference implementation through 0.1.3. Maintenance has ended.

## PyPI Packages

Use a virtual environment and run these commands with its Python interpreter.

```console
python -m pip install aikernel-net==0.1.4
python -m pip show aikernel-net
```

Check that `Version: 0.1.4` appears. The [aikernel-net project on PyPI](https://pypi.org/project/aikernel-net/0.1.4/) lists its Python requirements and available files. If pip reports no matching distribution, check the interpreter version and the configured package index.

## Historical Lines

| Version | When to consult it |
| --- | --- |
| 0.1.4 | Current installation steps, including HTTP and MCP hosting and the standard CPU inference path. |
| 0.1.3 | Earlier configurations. See the [0.1.4 migration guide](../overview/upgrade-0-1-4.md). |
| 0.1.2 and earlier | Historical documentation for reproducing earlier deployments. |

When upgrading, update your directly referenced AIKernel packages together and check the versions of the resolved dependencies. For repository integration tests with local build packages, use a separate feed and a fresh package cache so that the packages under test are identifiable.

## Host configuration for 0.1.4

Configure a host principal, PDP, and Guard before using the `KernelRequest` entry point. Both `vfs.open` and `model.execute` require approval. For a file provider, set `CredentialValidator` and enable `AllowWrite` explicitly when writes are needed. Keep the physical VFS root and its directories under host control. For HTTP file providers, configure injected HTTP handlers with automatic redirects disabled. The built-in ROM verifier requires a SHA-256 pin over the complete ROM file keyed by its VFS path. Dynamic provider DLLs require a host-provisioned SHA-256 digest in `TrustedAssemblyDigests`.

List each destination the standard network provider may contact when registering it, for example `services.AddAIKernelStandardProviders("https://api.example.org")`. An empty list disables outbound requests through this provider. Include the port for nonstandard endpoints and use a separate `tcp://host:port` entry for raw TCP.
