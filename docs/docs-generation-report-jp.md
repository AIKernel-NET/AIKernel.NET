---
title: "Documentation Generation Report"
lang: ja
description: "AIKernel.NET 0.1.3 公式サイト刷新で生成した docs、tutorials、glossary、Reference 根拠、検証方針を記録します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---
# Documentation Generation Report

## 概要

この report は 0.1.3 documentation renewal で生成した内容と、使用した repository facts を記録します。

## 背景

公式サイトは AdSense 審査で低品質と判断されているため、今回の renewal では品質判断を明示的に記録します。

## 使い方

生成ファイル、inventory source、follow-up TODO を監査するために使います。

## 例

### Generated files

- `SUMMARY-jp.md`
- `SUMMARY.md`
- `architecture/data-flow-jp.md`
- `architecture/data-flow.md`
- `architecture/index.md`
- `architecture/module-map-jp.md`
- `architecture/module-map.md`
- `architecture/system-architecture-jp.md`
- `architecture/system-architecture.md`
- `concepts/extensions-jp.md`
- `concepts/extensions.md`
- `concepts/index-jp.md`
- `concepts/index.md`
- `concepts/kernel-jp.md`
- `concepts/kernel.md`
- `concepts/messages-jp.md`
- `concepts/messages.md`
- `concepts/providers-jp.md`
- `concepts/providers.md`
- `concepts/runtime-jp.md`
- `concepts/runtime.md`
- `concepts/tools-jp.md`
- `concepts/tools.md`
- `doom/demo-overview-jp.md`
- `doom/demo-overview.md`
- `doom/how-it-works-jp.md`
- `doom/how-it-works.md`
- `doom/index-jp.md`
- `doom/index.md`
- `glossary/index-jp.md`
- `glossary/index.md`
- `index-jp.md`
- `index.md`
- `overview/index-jp.md`
- `overview/index.md`
- `overview/quick-start-jp.md`
- `overview/quick-start.md`
- `overview/what-is-aikernel-jp.md`
- `overview/what-is-aikernel.md`
- `providers/configuration-jp.md`
- `providers/configuration.md`
- `providers/creating-provider-jp.md`
- `providers/creating-provider.md`
- `providers/index-jp.md`
- `providers/index.md`
- `providers/provider-model-jp.md`
- `providers/provider-model.md`
- `runtime/configuration-jp.md`
- `runtime/configuration.md`
- `runtime/error-handling-jp.md`
- `runtime/error-handling.md`
- `runtime/execution-model-jp.md`
- `runtime/execution-model.md`
- `runtime/index-jp.md`
- `runtime/index.md`
- `runtime/lifecycle-jp.md`
- `runtime/lifecycle.md`
- `sitemap-jp.md`
- `sitemap.md`
- `tools/creating-tools-jp.md`
- `tools/creating-tools.md`
- `tools/index-jp.md`
- `tools/index.md`
- `tools/tool-execution-jp.md`
- `tools/tool-execution.md`
- `tools/tool-model-jp.md`
- `tools/tool-model.md`
- `tutorials/creating-provider-jp.md`
- `tutorials/creating-provider.md`
- `tutorials/creating-tool-jp.md`
- `tutorials/creating-tool.md`
- `tutorials/doom-demo-jp.md`
- `tutorials/doom-demo.md`
- `tutorials/first-kernel-jp.md`
- `tutorials/first-kernel.md`
- `tutorials/getting-started-jp.md`
- `tutorials/getting-started.md`
- `tutorials/index-jp.md`
- `tutorials/index.md`
- `tutorials/wasm-runtime-jp.md`
- `tutorials/wasm-runtime.md`
- `wasm/index-jp.md`
- `wasm/index.md`
- `wasm/integration-jp.md`
- `wasm/integration.md`
- `wasm/runtime-jp.md`
- `wasm/runtime.md`

### Inventory summary

| Module | Role | Version evidence | NuGet packages | Python packages | Public types | Tests | Source evidence |
|---|---|---:|---:|---:|---:|---:|---|
| `AIKernel.NET` | Contract packages and canonical interface surface. The 0.1.3 line adds the cognition pipeline interface surface while keeping DTO, enum, contract, and abstraction ownership separated. | `0.1.3` | 4 | 0 | 1065 | 1 | `AIKernel.NET/Directory.Build.props` |
| `AIKernel.Core` | Runtime and kernel implementation packages: hosting, VFS providers, kernel facade, fail-closed routing, and common runtime helpers. | `0.1.3` | 4 | 1 | 193 | 3 | `AIKernel.Core/Directory.Build.props` |
| `AIKernel.Control` | Physical execution and governance layer. It contains Control Core, CPU, GPU, Emulator, and Diagnostics packages for CTG-style execution evidence. | `0.1.3` | 6 | 1 | 62 | 1 | `AIKernel.Control/Directory.Build.props` |
| `AIKernel.Providers` | Official extension provider set. Provider-specific behavior is kept outside Core and is exposed through standard, chat, compute, pipeline, local LLM, and Microsoft AI packages. | `0.1.3` | 12 | 1 | 223 | 13 | `AIKernel.Providers/Directory.Build.props` |
| `AIKernel.Tools` | Developer and operations tools: CLI, inspectors, instrumentation, ROM export, replay helpers, and VFS/kernel-clock inspection. | `0.1.3` | 6 | 1 | 40 | 1 | `AIKernel.Tools/Directory.Build.props` |
| `AIKernel.Wasm` | Browser and WebAssembly runtime surface for process, memory, file system, WebGPU, audio, display, HUD, input, perception, and spatial packages. | `0.1.3` | 9 | 1 | 119 | 2 | `AIKernel.Wasm/Directory.Build.props` |
| `AIKernel.Doom` | Official source demo that models DOOM as a WASM process supervised by AIKernel-style provider, operator, consent, and perception boundaries. | `0.1.1.1` | 7 | 0 | 45 | 1 | `AIKernel.Doom/Directory.Build.props` |
| `AIKernel.Cuda13.0` | External Capability package for Windows win-x64, LibTorch 2.12.0, and CUDA 13.0. CUDA runtime concerns stay outside Core. | `0.1.3` | 1 | 1 | 7 | 1 | `AIKernel.Cuda13.0/src/AIKernel.Cuda13.0.Libtorch2.12.win-x64/AIKernel.Cuda13.0.Libtorch2.12.win-x64.csproj` |

## 補足

- Guide pages contain Summary / Why / Usage / Examples / Notes / See Also.
- Reference pages remain generated, but the site build template adds source paths, package context, meta tags, footer, and ad slot inherited from the existing site.
- Thin page risk is reduced by grouping docs around modules and workflows.
- Inventory JSON is stored at `ref/DocumentGenTask/docs-inventory.json` for resume/debug work.

## 関連ページ

- [Migration Report](docs-migration-report.md)
- [Docs Index](index.md)
- [Reference](/reference/)
