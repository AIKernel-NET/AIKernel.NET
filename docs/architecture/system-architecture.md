---
title: "System Architecture"
lang: ja
description: "Core、Control、Providers、Tools、Wasm、Doom、CUDA の責務境界と runtime composition を説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---

# System Architecture

## Summary

### EN

System Architecture focuses on package responsibility: contracts define, Core executes, Providers extend, Control governs, Tools inspect, Wasm isolates browser execution, and Doom validates the demo path.

### JA

System Architecture は package の責務に焦点を当てます。contracts は定義、Core は実行、Providers は拡張、Control は統治、Tools は検査、Wasm は browser 実行隔離、Doom は demo path 検証を担います。

## Why

### EN

AdSense review risk increases when pages look like disconnected generated lists. This page gives a real system explanation before linking to generated Reference.

### JA

生成一覧だけのページは低品質に見えやすいため、このページでは Reference へ進む前に system としての説明を与えます。

## Usage

### EN

Trace a feature from contract to runtime package, then to provider/tool integration and finally to the Reference page.

### JA

機能を contract から runtime package、provider/tool integration、Reference page へ辿ります。

## Examples

```mermaid
flowchart TD
    App["Application"] --> Contracts["AIKernel.NET contracts"]
    Contracts --> Core["AIKernel.Core runtime"]
    Core --> Providers["AIKernel.Providers"]
    Core --> Tools["AIKernel.Tools"]
    Core --> Wasm["AIKernel.Wasm"]
    Core --> Control["AIKernel.Control"]
    Cuda["AIKernel.Cuda13.0"] --> Core
    Doom["AIKernel.Doom demo"] --> Wasm
    Doom --> Providers
```


## Notes

- Runtime behavior must not be inferred from names alone; check package descriptions and tests.
- Provider and Tool packages are extension surfaces, not contract owners.
- CUDA is optional and external to Core.

## See Also

- [Runtime Model](../runtime/execution-model.md)
- [Provider Model](../providers/provider-model.md)
- [Tools](../tools/tool-model.md)
