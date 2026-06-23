---
title: "AIKernel.NET 0.1.3 Documentation"
lang: ja
description: "AIKernel.NET 0.1.3 の公式ドキュメント入口です。Overview、Architecture、Concepts、Runtime、Providers、Tools、Wasm、Doom、Reference へ進めます。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---

# AIKernel.NET 0.1.3 Documentation

## Summary

### EN

This page is the curated entry point for the AIKernel.NET 0.1.3 documentation set. It separates hand-written guides from generated package reference pages and points readers to the next practical page.

### JA

このページは AIKernel.NET 0.1.3 公式ドキュメントの入口です。手書きガイド、自動生成 Reference、チュートリアル、用語集を分離し、読者が次に読むべきページへ迷わず進めるようにします。

## Why

### EN

The previous site mixed broad essays, interface pages, package references, and release material. The 0.1.3 renewal keeps the useful material but adds a clear reader path and source-backed summaries.

### JA

以前の公式サイトでは、設計論文、interface page、package reference、release 文章が同じ階層に混在していました。0.1.3 では既存の有用な内容を残しつつ、読者の目的別に入口を整理します。

## Usage

### EN

Start with Overview if you are new, Architecture if you need module boundaries, Runtime if you are integrating execution, and Reference when you need package or API details.

### JA

初めて読む場合は Overview、依存境界を確認する場合は Architecture、実行連携は Runtime、型や package の確認は Reference から読み始めます。

## Examples

### Repository Map

| Module | Role | Version evidence | NuGet packages | Python packages | Public types | Tests | Source evidence |
|---|---|---:|---:|---:|---:|---:|---|
| `AIKernel.NET` | Contract packages and canonical interface surface. The 0.1.3 line adds the cognition pipeline interface surface while keeping DTO, enum, contract, and abstraction ownership separated. | `0.1.3` | 4 | 0 | 1065 | 1 | `AIKernel.NET/Directory.Build.props` |
| `AIKernel.Core` | Runtime and kernel implementation packages: hosting, VFS providers, kernel facade, fail-closed routing, and common runtime helpers. | `0.1.3` | 4 | 1 | 193 | 3 | `AIKernel.Core/Directory.Build.props` |
| `AIKernel.Control` | Physical execution and governance layer. It contains Control Core, CPU, GPU, Emulator, and Diagnostics packages for CTG-style execution evidence. | `0.1.3` | 6 | 1 | 62 | 1 | `AIKernel.Control/Directory.Build.props` |
| `AIKernel.Providers` | Official extension provider set. Provider-specific behavior is kept outside Core and is exposed through standard, chat, compute, pipeline, local LLM, and Microsoft AI packages. | `0.1.3` | 12 | 1 | 223 | 13 | `AIKernel.Providers/Directory.Build.props` |
| `AIKernel.Tools` | Developer and operations tools: CLI, inspectors, instrumentation, ROM export, replay helpers, and VFS/kernel-clock inspection. | `0.1.3` | 6 | 1 | 40 | 1 | `AIKernel.Tools/Directory.Build.props` |
| `AIKernel.Wasm` | Browser and WebAssembly runtime surface for process, memory, file system, WebGPU, audio, display, HUD, input, perception, and spatial packages. | `0.1.3` | 9 | 1 | 119 | 2 | `AIKernel.Wasm/Directory.Build.props` |
| `AIKernel.Doom` | Official source demo that models DOOM as a WASM process supervised by AIKernel-style provider, operator, consent, and perception boundaries. | `0.1.1.1` | 7 | 0 | 37 | 1 | `AIKernel.Doom/Directory.Build.props` |
| `AIKernel.Cuda13.0` | External Capability package for Windows win-x64, LibTorch 2.12.0, and CUDA 13.0. CUDA runtime concerns stay outside Core. | `0.1.3` | 1 | 1 | 7 | 1 | `AIKernel.Cuda13.0/src/AIKernel.Cuda13.0.Libtorch2.12.win-x64/AIKernel.Cuda13.0.Libtorch2.12.win-x64.csproj` |

### Minimal install shape

```bash
dotnet add package AIKernel.Core --version 0.1.3
dotnet add package AIKernel.Providers.Standard --version 0.1.3
dotnet tool install -g AIKernel.Tools.CLI --version 0.1.3
```


## Notes

- Release date recorded for this renewal: `2026-06-16`.
- Package versions are read from repository metadata rather than guessed.
- Thin pages are avoided by grouping API facts at package, module, or concept level.
- Existing advertisement meta, AdSense slot, footer, and copyright display are inherited by the website build templates.

## See Also

- [What is AIKernel.NET](overview/what-is-aikernel.md)
- [Quick Start](overview/quick-start.md)
- [System Architecture](architecture/system-architecture.md)
- [Runtime Model](runtime/execution-model.md)
- [Provider Model](providers/provider-model.md)
- [Tool Model](tools/tool-model.md)
- [Wasm Runtime](wasm/runtime.md)
- [Doom Demo](doom/demo-overview.md)
- [API Reference](/reference/)
- [Glossary](/glossary/)
