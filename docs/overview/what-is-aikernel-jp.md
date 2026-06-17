---
title: "What is AIKernel.NET"
lang: ja
description: "AIKernel.NET が解決する課題、Semantic OS SDK としての境界、0.1.2 の正典 interface surface を説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---
# What is AIKernel.NET

## 概要

AIKernel.NET は AIOS 型アプリケーションのための modular SDK です。contract package が境界を定義し、Core、Providers、Control、Tools、Wasm、Doom、CUDA package がその境界を実装または検証します。

## 背景

repo 分割の目的は、provider logic、control-plane evidence、runtime adapter、scenario demo を単一 package へ押し込めないことです。

## 使い方

依存を追加する前に module map を読みます。contract-only code は AIKernel.NET、runtime behavior は Core または extension package に置きます。

## 例

### Current Modules

| Module | Role | Version evidence | NuGet packages | Python packages | Public types | Tests | Source evidence |
|---|---|---:|---:|---:|---:|---:|---|
| `AIKernel.NET` | Contract packages and canonical interface surface. The 0.1.2 line adds the cognition pipeline interface surface while keeping DTO, enum, contract, and abstraction ownership separated. | `0.1.2` | 4 | 0 | 1065 | 1 | `AIKernel.NET/Directory.Build.props` |
| `AIKernel.Core` | Runtime and kernel implementation packages: hosting, VFS providers, kernel facade, fail-closed routing, and common runtime helpers. | `0.1.2` | 4 | 1 | 193 | 3 | `AIKernel.Core/Directory.Build.props` |
| `AIKernel.Control` | Physical execution and governance layer. It contains Control Core, CPU, GPU, Emulator, and Diagnostics packages for CTG-style execution evidence. | `0.1.2` | 6 | 1 | 62 | 1 | `AIKernel.Control/Directory.Build.props` |
| `AIKernel.Providers` | Official extension provider set. Provider-specific behavior is kept outside Core and is exposed through standard, chat, compute, pipeline, local LLM, and Microsoft AI packages. | `0.1.2` | 12 | 1 | 223 | 13 | `AIKernel.Providers/Directory.Build.props` |
| `AIKernel.Tools` | Developer and operations tools: CLI, inspectors, instrumentation, ROM export, replay helpers, and VFS/kernel-clock inspection. | `0.1.2` | 6 | 1 | 40 | 1 | `AIKernel.Tools/Directory.Build.props` |
| `AIKernel.Wasm` | Browser and WebAssembly runtime surface for process, memory, file system, WebGPU, audio, display, HUD, input, perception, and spatial packages. | `0.1.2` | 9 | 1 | 119 | 2 | `AIKernel.Wasm/Directory.Build.props` |
| `AIKernel.Doom` | Official source demo that models DOOM as a WASM process supervised by AIKernel-style provider, operator, consent, and perception boundaries. | `0.1.1.1` | 7 | 0 | 45 | 1 | `AIKernel.Doom/Directory.Build.props` |
| `AIKernel.Cuda13.0` | External Capability package for Windows win-x64, LibTorch 2.12.0, and CUDA 13.0. CUDA runtime concerns stay outside Core. | `0.1.2` | 1 | 1 | 7 | 1 | `AIKernel.Cuda13.0/src/AIKernel.Cuda13.0.Libtorch2.12.win-x64/AIKernel.Cuda13.0.Libtorch2.12.win-x64.csproj` |

## 補足

- The 0.1.2 contract release is backed by `AIKernel.NET/Directory.Build.props` release notes.
- Doom-specific vocabulary remains outside the canonical package surface according to the 0.1.2 package notes.
- When source evidence is missing, this documentation uses `TODO: source required` instead of inventing behavior.

## 関連ページ

- [Module Map](../architecture/module-map.md)
- [Core Concepts](../concepts/index.md)
- [Glossary](/glossary/)
