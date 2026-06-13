---
title: "AIKernel 0.1.1 / 0.1.1.1 Package Installation Guide"
updated: 2026-06-14
published: 2026-06-10
version: "0.1.1.1"
edition: "Release"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel 0.1.1 / 0.1.1.1 Package Installation Guide

AIKernel 0.1.1 is the first synchronized package line for the public Semantic OS surface.  
The .NET packages are published through NuGet, the Python wrappers are published through PyPI, and the demo repository provides the official golden-path examples.

AIKernel 0.1.1.1 is an additive interface-extension update for selected public
packages. It does not require a GitHub release workflow and preserves v0.1.1
consumer compatibility. Use `0.1.1.1` package versions only when you need the
new semantic contract surface documented in
[`../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1.md`](../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1.md),
including the CTG developer documents:
[`../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md`](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md),
[`../design/CTG_CONTRACT_MODEL-v0.1.1.1.md`](../design/CTG_CONTRACT_MODEL-v0.1.1.1.md), and
[`CTG_DEVELOPER_GUIDE-v0.1.1.1.md`](CTG_DEVELOPER_GUIDE-v0.1.1.1.md). The published
paper reference is
[`../papers/12-canonical-trajectory-governance/README.md`](../papers/12-canonical-trajectory-governance/README.md).

## Quick Start: Start the OS Surface

Use these packages when you want the shortest path to a local AIKernel runtime with standard providers and operational tooling.

```bash
dotnet add package AIKernel.Core --version 0.1.1
dotnet add package AIKernel.Providers.Standard --version 0.1.1
dotnet tool install -g AIKernel.Tools.CLI --version 0.1.1
```

Then verify the command-line surface:

```bash
aik runtime ping
aik system info
aik system vfs --vfs-root .
aik capabilities invoke aikernel.vfs vfs.exists path=README.md
```

## NuGet Packages

| Layer | Package | Purpose |
|---|---|---|
| Contract boundary | `AIKernel.Abstractions` | Interface and OS boundary contracts. |
| Contract DTOs | `AIKernel.Contracts` | Contract-level request, response, and policy shapes. |
| Contract DTOs | `AIKernel.Dtos` | Public data-transfer objects used across the runtime. |
| Contract enums | `AIKernel.Enums` | Stable enum vocabulary for the Semantic OS. |
| Functional primitives | `AIKernel.Common` | Result, Option, Try, Async, identifiers, hashing, and shared deterministic helpers. |
| Runtime | `AIKernel.Core` | Kernel runtime, VFS, ROM, DSL, process, compute, routing, and OS abstractions. |
| Hosting | `AIKernel.Hosting` | Host composition and dependency-injection support. |
| Kernel facade | `AIKernel.Kernel` | Kernel-facing facade package for application entry points. |
| Governance | `AIKernel.Control` | Deterministic control plane, policy, emulator, and governance execution. |
| Standard drivers | `AIKernel.Providers.Standard` | CPU compute, file systems, logging, event bus, network, profiler, and scheduler providers. |
| Provider extensions | `AIKernel.Providers.ChatHistory` | Lightweight chat history provider. |
| Provider extensions | `AIKernel.Providers.ChatOpenAI` | OpenAI chat provider manifest and invoker surface. |
| Provider extensions | `AIKernel.Providers.MicrosoftAI` | Microsoft AI provider surface. |
| Provider extensions | `AIKernel.Providers.LocalLlm` | Local LLM provider surface. |
| Provider extensions | `AIKernel.Providers.DynamicPipelineCompiler` | Dynamic pipeline compiler provider. |
| Provider extensions | `AIKernel.Providers.CudaCompute` | CUDA compute provider abstraction surface. |
| Tools | `AIKernel.Tools.Instrumentation` | Canonical formatting, inspection, replay, and instrumentation. |
| Tools inspectors | `AIKernel.Tools.Inspectors.Vfs` | VFS inspection helpers. |
| Tools inspectors | `AIKernel.Tools.Inspectors.ChatHistoryScraper` | Chat history scraping and inspection helpers. |
| Tools capability | `AIKernel.Tools.Capability.RomStorage` | ROM storage capability bridge. |
| CLI | `AIKernel.Tools.CLI` | `aik` command-line tool. |
| WASM | `AIKernel.Wasm.Runtime` | WASM runtime, process, memory, FS, event, audio, screenshot, save-state, and time surfaces. |
| WASM Compute | `AIKernel.Wasm.WebGpuComputeProvider` | WebGPU compute provider surface with CPU fallback integration. |
| CUDA native | `AIKernel.Cuda13.0.Libtorch2.12.win-x64` | Windows-only LibTorch 2.12 / CUDA 13.0 package. |

CUDA is intentionally platform-scoped. Use the CUDA package only on Windows win-x64 environments that satisfy its native runtime requirements.

## PyPI Packages

| Package | Import Surface | Purpose |
|---|---|---|
| `aikernel-net` | `aikernel_net` | Core runtime and managed assembly discovery wrapper. |
| `aikernel-governance` | `aikernel_governance` | Control and governance wrapper. |
| `aikernel-providers` | `aikernel_providers` | Provider descriptors, manifests, and invoker wrappers. |
| `aikernel-tools` | `aikernel_tools` | Instrumentation, formatter, inspector, replay, and CLI-adjacent wrappers. |
| `aikernel-wasm` | `aikernel_wasm` | WASM runtime and WebGPU provider wrapper surface. |
| `aikernel-cuda13-libtorch2-12-win-x64` | `aikernel_cuda13_libtorch2_12_win_x64` | Windows-only CUDA wrapper metadata and loader guidance. |

Install the Python side by layer:

```bash
pip install aikernel-net==0.1.1
pip install aikernel-providers==0.1.1
pip install aikernel-tools==0.1.1
```

Add governance or WASM when your application uses those surfaces:

```bash
pip install aikernel-governance==0.1.1
pip install aikernel-wasm==0.1.1
```

## Provider Selection

Choose the provider package by the runtime boundary you need:

| Scenario | Package |
|---|---|
| Local OS services, file systems, logging, scheduler, profiler | `AIKernel.Providers.Standard` |
| Local LLM experimentation without a hosted API | `AIKernel.Providers.LocalLlm` |
| OpenAI chat integration | `AIKernel.Providers.ChatOpenAI` |
| Microsoft AI integration | `AIKernel.Providers.MicrosoftAI` |
| Lightweight history-backed inference surfaces | `AIKernel.Providers.ChatHistory` |
| Dynamic DSL pipeline compilation | `AIKernel.Providers.DynamicPipelineCompiler` |
| CUDA compute capability bridge | `AIKernel.Providers.CudaCompute` plus the CUDA runtime package when needed |

## Repository Links

- [AIKernel.NET](https://github.com/AIKernel-NET/AIKernel.NET) — contract boundary packages.
- [AIKernel.Core](https://github.com/AIKernel-NET/AIKernel.Core) — runtime and OS abstractions.
- [AIKernel.Providers](https://github.com/AIKernel-NET/AIKernel.Providers) — standard and extension provider drivers.
- [AIKernel.Control](https://github.com/AIKernel-NET/AIKernel.Control) — governance and control plane.
- [AIKernel.Tools](https://github.com/AIKernel-NET/AIKernel.Tools) — instrumentation and CLI.
- [AIKernel.Wasm](https://github.com/AIKernel-NET/AIKernel.Wasm) — sandboxed WASM runtime.
- [AIKernel.Cuda13.0](https://github.com/AIKernel-NET/AIKernel.Cuda13.0) — Windows CUDA package line.
- [AIKernel.Demo](https://github.com/AIKernel-NET/AIKernel.Demo) — official examples.

## Release Rule

Use only `0.1.1` packages together for the synchronized line. Mixing `0.1.0` and `0.1.1` packages can hide stale contracts, provider manifests, or Python wrapper surfaces.

For the additive interface-extension line, keep updated public packages on
`0.1.1.1` together. Local development packages use:

```text
0.1.1-dev<build-number>
```
