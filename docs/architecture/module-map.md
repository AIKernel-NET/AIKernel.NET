---
title: "Choose the packages you need"
lang: en
description: "Choose AIKernel packages by the responsibility your application needs and understand the boundaries between contracts and implementations."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.4"
documentation_target: "0.1.4"
updated: "2026-11-24"
---

# Choose the packages you need

Choose dependencies by the responsibility your application needs: shared types, runtime behavior, external capabilities, or inspection tools. You do not need every package family to start.

## Grow from the smallest .NET example

The first sample uses Core, Hosting, Kernel, and shared contracts. Add a provider when you need an external model or service. Consider Wasm for browser execution. Basic onboarding runs on the CPU. For CUDA on Windows x64 and Linux x64, use the CUDA Driver bundled with `AIKernel.Kernel` 0.1.4. Its only native runtime prerequisite is the NVIDIA driver.

| Repository | Responsibility | When you need it |
| --- | --- | --- |
| AIKernel.NET | Interfaces, DTOs, and enums | Sharing input/output contracts between components |
| AIKernel.Core | Runtime, Hosting, Kernel, and VFS | Hosting the basic runtime in .NET |
| AIKernel.Providers | Model, service, and compute implementations | Connecting an external capability |
| AIKernel.Control | Execution and control components | Working with the control plane or emulator |
| AIKernel.Tools | CLI and inspection tools | Investigating runtime state and records |
| AIKernel.Wasm | Browser and WebAssembly components | Web execution and rendering |
| AIKernel.Demo | Application examples | Learning how to compose the pieces |

Applications call implementations through contracts. Provider-specific communication and GPU configuration belong with their implementations rather than in shared DTOs. This helps a test implementation and a real service share the same boundary.

The [sample project file](https://github.com/AIKernel-NET/AIKernel.Demo/blob/8c960f57bdf6f431663a1ca33de7584f5e882140/src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj) shows concrete dependencies for the first exercise.

## Keep versions aligned

The onboarding sample uses the published AIKernel SDK 0.1.4. See the [installation guide](../operations/PACKAGE_INSTALLATION_GUIDE.md) for the published version of each Provider and its shared contracts.

Use [API Reference](/reference/) for exact members, [Quick Start](../overview/quick-start.md) for installation order, and [Runtime troubleshooting](../runtime/index.md) when integration fails.
