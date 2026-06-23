---
title: "Wasm Runtime Model"
lang: ja
description: "process、memory、file system、WebGPU、audio、display、input の runtime model を説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---
# Wasm Runtime Model

## 概要

Wasm Runtime Model は 0.1.3 の repository metadata、package metadata、既存 docs を根拠に説明します。

## 背景

この guide page は explanatory material と generated Reference を分離し、低品質な API dump page になることを避けます。

## 使い方

package table で実装または wrapper package を探し、正確な API member は Reference で確認します。

## 例

### Related packages

| Package | Kind | Version | Description | Source |
|---|---|---|---|---|
| [`AIKernel.Wasm.Audio`](/reference/aikernel-wasm/aikernel-wasm-audio/) | nuget | `0.1.3` | EN: AIKernel WASM audio package for runtime audio buffers and WebAudio boundary contracts. JA: runtime audio buffer と WebAudio boundary contract を提供する AIKern... | `AIKernel.Wasm/src/Audio/AIKernel.Wasm.Audio/AIKernel.Wasm.Audio.csproj` |
| [`AIKernel.Wasm.Display`](/reference/aikernel-wasm/aikernel-wasm-display/) | nuget | `0.1.3` | EN: AIKernel WASM display package for framebuffer, frame source, screenshot adapter, and virtual surface descriptors. JA: framebuffer、frame source、screenshot... | `AIKernel.Wasm/src/Display/AIKernel.Wasm.Display/AIKernel.Wasm.Display.csproj` |
| [`AIKernel.Wasm.Hud`](/reference/aikernel-wasm/aikernel-wasm-hud/) | nuget | `0.1.3` | EN: AIKernel WASM HUD package for signal and overlay annotation DTO generation without rendering. JA: rendering を行わず signal / overlay annotation DTO を生成する AI... | `AIKernel.Wasm/src/Hud/AIKernel.Wasm.Hud/AIKernel.Wasm.Hud.csproj` |
| [`AIKernel.Wasm.Input`](/reference/aikernel-wasm/aikernel-wasm-input/) | nuget | `0.1.3` | EN: AIKernel WASM input package for keyboard, pointer, gamepad, and virtual input injection. JA: keyboard、pointer、gamepad、virtual input injection を提供する AIKer... | `AIKernel.Wasm/src/Input/AIKernel.Wasm.Input/AIKernel.Wasm.Input.csproj` |
| [`AIKernel.Wasm.Models`](/reference/aikernel-wasm/aikernel-wasm-models/) | nuget | `0.1.3` | EN: AIKernel WASM model execution package for descriptor-driven WebGPU resident model boundaries. JA: descriptor-driven な WebGPU resident model 境界を提供する AIKer... | `AIKernel.Wasm/src/Models/AIKernel.Wasm.Models/AIKernel.Wasm.Models.csproj` |
| [`AIKernel.Wasm.Perception`](/reference/aikernel-wasm/aikernel-wasm-perception/) | nuget | `0.1.3` | EN: AIKernel WASM perception package for browser-neutral frame and WebAudio signal extraction. JA: browser-neutral な frame / WebAudio signal extraction を提供する... | `AIKernel.Wasm/src/Perception/AIKernel.Wasm.Perception/AIKernel.Wasm.Perception.csproj` |
| [`AIKernel.Wasm.Runtime`](/reference/aikernel-wasm/aikernel-wasm-runtime/) | nuget | `0.1.3` | EN: AIKernel WASM runtime service package for browser/WebAssembly process, memory, stdin, file system, event, audio, screenshot, save-state, and time provide... | `AIKernel.Wasm/src/Runtime/AIKernel.Wasm.Runtime/AIKernel.Wasm.Runtime.csproj` |
| [`AIKernel.Wasm.Spatial`](/reference/aikernel-wasm/aikernel-wasm-spatial/) | nuget | `0.1.3` | EN: AIKernel WASM spatial cognition package for scenario-independent visual and auditory perception composition. JA: scenario 非依存の visual / auditory percepti... | `AIKernel.Wasm/src/Spatial/AIKernel.Wasm.Spatial/AIKernel.Wasm.Spatial.csproj` |
| [`AIKernel.Wasm.WebGpuComputeProvider`](/reference/aikernel-wasm/aikernel-wasm-webgpucomputeprovider/) | nuget | `0.1.3` | EN: Official AIKernel.NET WASM provider for WebGPU compute with deterministic CPU fallback. JA: deterministic CPU fallback を備えた WebGPU compute 向け AIKernel.NE... | `AIKernel.Wasm/src/Compute/WebGpuComputeProvider/WebGpuComputeProvider.csproj` |
| [`aikernel-wasm`](/reference/aikernel-wasm/python/aikernel-wasm/) | python | `0.1.3` | Python wrapper for AIKernel.Wasm 0.1.3 runtime and WebGPU provider assemblies. | `AIKernel.Wasm/python/pyproject.toml` |

## 補足

- Examples are limited to package and command shapes confirmed in repository metadata.
- For behavior details, inspect the linked source path and tests.
- If a runtime asset is hosted outside the source repository, the page treats it as deployment configuration rather than source behavior.

## 関連ページ

- [Architecture](../architecture/index.md)
- [Reference](/reference/)
- [Generation Report](../docs-generation-report.md)
