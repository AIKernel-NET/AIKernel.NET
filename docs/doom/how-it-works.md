---
title: "How the Doom Demo Works"
lang: ja
description: "DoomProvider、DoomWasm、DoomWeb、DoomCapabilities、DoomOptimizer の関係を説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---

# How the Doom Demo Works

## Summary

### EN

Doom source docs identify package responsibilities and runtime consent rules.

### JA

How the Doom Demo Works は 0.1.3 の repository metadata、package metadata、既存 docs を根拠に説明します。

## Why

### EN

This guide page keeps generated Reference separate from explanatory material, which helps avoid low-value API dump pages.

### JA

この guide page は explanatory material と generated Reference を分離し、低品質な API dump page になることを避けます。

## Usage

### EN

Use the package table to locate the implementation or wrapper package, then open Reference for exact API members.

### JA

package table で実装または wrapper package を探し、正確な API member は Reference で確認します。

## Examples

### Related packages

| Package | Kind | Version | Description | Source |
|---|---|---|---|---|
| [`DoomCapabilities`](/reference/aikernel-doom/doomcapabilities/) | nuget | `0.1.1.1` | doom.start, doom.stop, and doom.status capability invoker for AIKernel.Doom. | `AIKernel.Doom/src/DoomCapabilities/DoomCapabilities.csproj` |
| [`DoomDemo`](/reference/aikernel-doom/doomdemo/) | nuget | `0.1.1.1` | Prompt-style AIKernel boot sequence and CLI demo for DOOM as a WASM process. | `AIKernel.Doom/src/DoomDemo/DoomDemo.csproj` |
| [`DoomOptimizer`](/reference/aikernel-doom/doomoptimizer/) | nuget | `0.1.1.1` | Observer ROM profile optimizer for the AIKernel.Doom autoplay demo. | `AIKernel.Doom/src/DoomOptimizer/DoomOptimizer.csproj` |
| [`DoomProvider`](/reference/aikernel-doom/doomprovider/) | nuget | `0.1.1.1` | DOOM WASM process provider for AIKernel.Doom. | `AIKernel.Doom/src/DoomProvider/DoomProvider.csproj` |
| [`DoomWasm`](/reference/aikernel-doom/doomwasm/) | nuget | `0.1.1.1` | DOOM WASM ROM metadata and asset resolution support for AIKernel.Doom. | `AIKernel.Doom/src/DoomWasm/DoomWasm.csproj` |
| [`DoomWasm.Native`](/reference/aikernel-doom/doomwasm-native/) | nuget | `0.1.1.1` | MSBuild utility project for building the DOOM WASM native overlay with Emscripten. | `AIKernel.Doom/src/DoomWasm.Native/DoomWasm.Native.csproj` |
| [`DoomWeb`](/reference/aikernel-doom/doomweb/) | nuget | `0.1.1.1` | Public Web runtime assets for the AIKernel.Doom WASM demo. Does not include WAD, model, or generated WASM binaries. | `AIKernel.Doom/src/DoomWeb/DoomWeb.csproj` |


## Notes

- Examples are limited to package and command shapes confirmed in repository metadata.
- For behavior details, inspect the linked source path and tests.
- If a runtime asset is hosted outside the source repository, the page treats it as deployment configuration rather than source behavior.

## See Also

- [Architecture](../architecture/index.md)
- [Reference](/reference/)
- [Generation Report](../docs-generation-report.md)
