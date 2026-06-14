---
title: "AIKernel 0.1.1 Demo Programs Guide"
updated: 2026-06-10
published: 2026-06-10
version: "0.1.1"
edition: "Release"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel 0.1.1 Demo Programs Guide

AIKernel.Demo is the official example repository for the 0.1.1 package line.  
It is the best first stop after installing packages because each demo maps one OS layer to a minimal golden path.

## First Demo to Run

Start with `AIKernel.Demo.CoreRuntime`.

```bash
dotnet run --project src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj
```

This demo shows the smallest complete runtime shape: semantic router, capability registry, kernel clock, VFS, ROM, time, and security surfaces.

## Demo Map

| Demo Project | Primary Packages | What It Teaches |
|---|---|---|
| `AIKernel.Demo.CoreRuntime` | `AIKernel.Core` | Kernel runtime, hosting, VFS, ROM, time, and security baseline. |
| `AIKernel.Demo.Contracts` | `AIKernel.Abstractions`, `AIKernel.Contracts`, `AIKernel.Dtos`, `AIKernel.Enums` | Contract DTOs, policy results, unified context, and hash-chain DTOs. |
| `AIKernel.Demo.Control` | `AIKernel.Control` | Governance policy, deterministic scheduler, emulator, and control execution. |
| `AIKernel.Demo.Providers` | `AIKernel.Providers.*` | Provider descriptors, manifests, invokers, and dry-run provider selection. |
| `AIKernel.Demo.StandardProviders` | `AIKernel.Providers.Standard` | File systems, logging, network, EventBus, profiler, and scheduler. |
| `AIKernel.Demo.Tools` | `AIKernel.Tools.Instrumentation` | Canonical formatting, inspection, replay, and ROM tooling. |
| `AIKernel.Demo.Wasm` | `AIKernel.Wasm.Runtime`, `AIKernel.Wasm.WebGpuComputeProvider` | WASM runtime, memory, FS, event, audio, screenshot, save-state, time, and WebGPU surface. |
| `AIKernel.Demo.Cuda` | `AIKernel.Cuda13.0.Libtorch2.12.win-x64` | Windows-only CUDA descriptor and guarded native capability surface. |

## Running the Full Demo Set

The demos are designed to avoid external network calls and to run as dry-run golden paths.

```bash
dotnet build -c Release
dotnet run --project src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj
dotnet run --project src/AIKernel.Demo.Contracts/AIKernel.Demo.Contracts.csproj
dotnet run --project src/AIKernel.Demo.Control/AIKernel.Demo.Control.csproj
dotnet run --project src/AIKernel.Demo.Providers/AIKernel.Demo.Providers.csproj
dotnet run --project src/AIKernel.Demo.StandardProviders/AIKernel.Demo.StandardProviders.csproj
dotnet run --project src/AIKernel.Demo.Tools/AIKernel.Demo.Tools.csproj
dotnet run --project src/AIKernel.Demo.Wasm/AIKernel.Demo.Wasm.csproj
```

Run the CUDA demo only on Windows with the required CUDA native runtime:

```bash
dotnet run --project src/AIKernel.Demo.Cuda/AIKernel.Demo.Cuda.csproj
```

On non-Windows systems, the CUDA demo is expected to report a guarded skip instead of failing the release path.

## Python Demo Surface

AIKernel.Demo also mirrors the package story on the Python side. Use the Python demos to confirm wrapper imports, managed assembly discovery, and dry-run package surfaces after installing the PyPI packages.

These Python demo checks belong to the synchronized 0.1.1 package line. The 0.1.1.1 contract update does not introduce new PyPI packages or additional Python demo validation.

```bash
pip install aikernel-net==0.1.1 aikernel-providers==0.1.1 aikernel-tools==0.1.1
```

Add `aikernel-governance`, `aikernel-wasm`, or the Windows-only CUDA wrapper only when that layer is part of the scenario.

## Operational Reading Order

1. Run `AIKernel.Demo.CoreRuntime`.
2. Read the package installation guide.
3. Run `AIKernel.Demo.StandardProviders`.
4. Run `AIKernel.Demo.Providers` to understand extension providers.
5. Add Control, Tools, WASM, or CUDA based on the layer you are evaluating.

This order keeps the OS mental model clear: kernel first, drivers second, governance and observability after the execution boundary is visible.
