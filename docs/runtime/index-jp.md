---
title: "Runtime Model"
lang: ja
description: "AIKernel.NET 0.1.2 の execution model、lifecycle、configuration、error handling をまとめます。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---
# Runtime Model

## 概要

Runtime Model は 0.1.2 の repository metadata、package metadata、既存 docs を根拠に説明します。

## 背景

この guide page は explanatory material と generated Reference を分離し、低品質な API dump page になることを避けます。

## 使い方

package table で実装または wrapper package を探し、正確な API member は Reference で確認します。

## 例

### Related packages

| Package | Kind | Version | Description | Source |
|---|---|---|---|---|
| [`AIKernel.Common`](/reference/aikernel-core/aikernel-common/) | nuget | `0.1.2` | English AIKernel.Common provides foundational utility components shared across the AIKernel ecosystem. This package contains cross-cutting features such as f... | `AIKernel.Core/src/AIKernel.Common/AIKernel.Common.csproj` |
| [`AIKernel.Core`](/reference/aikernel-core/aikernel-core/) | nuget | `0.1.2` | EN: Core runtime engine for AIKernel.NET. Provides the foundational execution logic for VFS, ROM, Context construction, and inference execution in a determin... | `AIKernel.Core/src/AIKernel.Core/AIKernel.Core.csproj` |
| [`AIKernel.Hosting`](/reference/aikernel-core/aikernel-hosting/) | nuget | `0.1.2` | EN: Hosting and dependency injection extensions for AIKernel.NET. Provides IServiceCollection integration and startup wiring for ASP.NET Core and .NET Generi... | `AIKernel.Core/src/AIKernel.Hosting/AIKernel.Hosting.csproj` |
| [`AIKernel.Kernel`](/reference/aikernel-core/aikernel-kernel/) | nuget | `0.1.2` | EN: Kernel facade and orchestration layer for AIKernel.NET. Coordinates Core, Providers, Context, Governance, and execution flow through a unified IKernel in... | `AIKernel.Core/src/AIKernel.Kernel/AIKernel.Kernel.csproj` |
| [`AIKernel.Control`](/reference/aikernel-control/aikernel-control/) | nuget | `0.1.2` | Entry package for AIKernel.Control v0.1.2. Installs the Control Core, CPU, Emulator, Diagnostics, and GPU boundary packages for governed semantic execution h... | `AIKernel.Control/src/AIKernel.Control/AIKernel.Control.csproj` |
| [`AIKernel.Control.Core`](/reference/aikernel-control/aikernel-control-core/) | nuget | `0.1.2` | Control-plane runtime entry package for AIKernel.Control. Provides Bonsai provider contracts, model config/tokenizer/model-state wrappers, provider capabilit... | `AIKernel.Control/src/AIKernel.Control.Core/AIKernel.Control.Core.csproj` |
| [`AIKernel.Control.CPU`](/reference/aikernel-control/aikernel-control-cpu/) | nuget | `0.1.2` | CPU execution package for AIKernel.Control. Provides the public Bonsai Q1_0 1-bit CPU inference kernel and CPU-side physical execution boundary for governed... | `AIKernel.Control/src/AIKernel.Control.CPU/AIKernel.Control.CPU.csproj` |
| [`AIKernel.Control.Diagnostics`](/reference/aikernel-control/aikernel-control-diagnostics/) | nuget | `0.1.2` | Diagnostics package for AIKernel.Control. Provides public replay approval diagnostics records and observability support for governed control-plane execution. | `AIKernel.Control/src/AIKernel.Control.Diagnostics/AIKernel.Control.Diagnostics.csproj` |
| [`AIKernel.Control.Emulator`](/reference/aikernel-control/aikernel-control-emulator/) | nuget | `0.1.2` | Deterministic emulator package for AIKernel.Control. Provides public emulated execution graph/node wrappers, deterministic scheduling, allow-all policy, and... | `AIKernel.Control/src/AIKernel.Control.Emulator/AIKernel.Control.Emulator.csproj` |
| [`AIKernel.Control.GPU`](/reference/aikernel-control/aikernel-control-gpu/) | nuget | `0.1.2` | GPU boundary package for AIKernel.Control. Provides the public Bonsai GPU execution delegate contract so CUDA, WebGPU, ROCm, Vulkan, or other device-specific... | `AIKernel.Control/src/AIKernel.Control.GPU/AIKernel.Control.GPU.csproj` |
| [`AIKernel.Wasm.Audio`](/reference/aikernel-wasm/aikernel-wasm-audio/) | nuget | `0.1.2` | EN: AIKernel WASM audio package for runtime audio buffers and WebAudio boundary contracts. JA: runtime audio buffer と WebAudio boundary contract を提供する AIKern... | `AIKernel.Wasm/src/Audio/AIKernel.Wasm.Audio/AIKernel.Wasm.Audio.csproj` |
| [`AIKernel.Wasm.Display`](/reference/aikernel-wasm/aikernel-wasm-display/) | nuget | `0.1.2` | EN: AIKernel WASM display package for framebuffer, frame source, screenshot adapter, and virtual surface descriptors. JA: framebuffer、frame source、screenshot... | `AIKernel.Wasm/src/Display/AIKernel.Wasm.Display/AIKernel.Wasm.Display.csproj` |
| [`AIKernel.Wasm.Hud`](/reference/aikernel-wasm/aikernel-wasm-hud/) | nuget | `0.1.2` | EN: AIKernel WASM HUD package for signal and overlay annotation DTO generation without rendering. JA: rendering を行わず signal / overlay annotation DTO を生成する AI... | `AIKernel.Wasm/src/Hud/AIKernel.Wasm.Hud/AIKernel.Wasm.Hud.csproj` |
| [`AIKernel.Wasm.Input`](/reference/aikernel-wasm/aikernel-wasm-input/) | nuget | `0.1.2` | EN: AIKernel WASM input package for keyboard, pointer, gamepad, and virtual input injection. JA: keyboard、pointer、gamepad、virtual input injection を提供する AIKer... | `AIKernel.Wasm/src/Input/AIKernel.Wasm.Input/AIKernel.Wasm.Input.csproj` |
| [`AIKernel.Wasm.Models`](/reference/aikernel-wasm/aikernel-wasm-models/) | nuget | `0.1.2` | EN: AIKernel WASM model execution package for descriptor-driven WebGPU resident model boundaries. JA: descriptor-driven な WebGPU resident model 境界を提供する AIKer... | `AIKernel.Wasm/src/Models/AIKernel.Wasm.Models/AIKernel.Wasm.Models.csproj` |
| [`AIKernel.Wasm.Perception`](/reference/aikernel-wasm/aikernel-wasm-perception/) | nuget | `0.1.2` | EN: AIKernel WASM perception package for browser-neutral frame and WebAudio signal extraction. JA: browser-neutral な frame / WebAudio signal extraction を提供する... | `AIKernel.Wasm/src/Perception/AIKernel.Wasm.Perception/AIKernel.Wasm.Perception.csproj` |
| [`AIKernel.Wasm.Runtime`](/reference/aikernel-wasm/aikernel-wasm-runtime/) | nuget | `0.1.2` | EN: AIKernel WASM runtime service package for browser/WebAssembly process, memory, stdin, file system, event, audio, screenshot, save-state, and time provide... | `AIKernel.Wasm/src/Runtime/AIKernel.Wasm.Runtime/AIKernel.Wasm.Runtime.csproj` |
| [`AIKernel.Wasm.Spatial`](/reference/aikernel-wasm/aikernel-wasm-spatial/) | nuget | `0.1.2` | EN: AIKernel WASM spatial cognition package for scenario-independent visual and auditory perception composition. JA: scenario 非依存の visual / auditory percepti... | `AIKernel.Wasm/src/Spatial/AIKernel.Wasm.Spatial/AIKernel.Wasm.Spatial.csproj` |
| [`AIKernel.Wasm.WebGpuComputeProvider`](/reference/aikernel-wasm/aikernel-wasm-webgpucomputeprovider/) | nuget | `0.1.2` | EN: Official AIKernel.NET WASM provider for WebGPU compute with deterministic CPU fallback. JA: deterministic CPU fallback を備えた WebGPU compute 向け AIKernel.NE... | `AIKernel.Wasm/src/Compute/WebGpuComputeProvider/WebGpuComputeProvider.csproj` |

## 補足

- Examples are limited to package and command shapes confirmed in repository metadata.
- For behavior details, inspect the linked source path and tests.
- If a runtime asset is hosted outside the source repository, the page treats it as deployment configuration rather than source behavior.

## 関連ページ

- [Architecture](../architecture/index.md)
- [Reference](/reference/)
- [Generation Report](../docs-generation-report.md)
