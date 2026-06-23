---
title: "Overview"
lang: ja
description: "AIKernel.NET 0.1.3 の全体像、対象読者、主要モジュール、次に読むべき導線をまとめます。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---

# Overview

## Summary

### EN

Overview explains the 0.1.3 documentation set and how the package families relate to the official site.

### JA

Overview では 0.1.3 の公式ドキュメント全体像と、package family が公式サイト上でどのように整理されるかを説明します。

## Why

### EN

A reader should not have to infer the project shape from dozens of package pages. The overview gives a stable map first.

### JA

読者に package page の羅列から構造を推測させないため、Overview は最初に安定した地図を提供します。

## Usage

### EN

Use this page to choose between architecture, runtime, providers, tools, Wasm, Doom, tutorials, and API reference.

### JA

Architecture、Runtime、Providers、Tools、Wasm、Doom、Tutorial、API Reference のどこへ進むべきかを選ぶために使います。

## Examples

### Package Families

| Package | Kind | Version | Description | Source |
|---|---|---|---|---|
| [`AIKernel.Abstractions`](/reference/aikernel-net/aikernel-abstractions/) | nuget | `0.1.3` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Abstractions/AIKernel.Abstractions.csproj` |
| [`AIKernel.Contracts`](/reference/aikernel-net/aikernel-contracts/) | nuget | `0.1.3` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Contracts/AIKernel.Contracts.csproj` |
| [`AIKernel.Dtos`](/reference/aikernel-net/aikernel-dtos/) | nuget | `0.1.3` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Dtos/AIKernel.Dtos.csproj` |
| [`AIKernel.Enums`](/reference/aikernel-net/aikernel-enums/) | nuget | `0.1.3` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Enums/AIKernel.Enums.csproj` |
| [`AIKernel.Common`](/reference/aikernel-core/aikernel-common/) | nuget | `0.1.3` | English AIKernel.Common provides foundational utility components shared across the AIKernel ecosystem. This package contains cross-cutting features such as f... | `AIKernel.Core/src/AIKernel.Common/AIKernel.Common.csproj` |
| [`AIKernel.Core`](/reference/aikernel-core/aikernel-core/) | nuget | `0.1.3` | EN: Core runtime engine for AIKernel.NET. Provides the foundational execution logic for VFS, ROM, Context construction, and inference execution in a determin... | `AIKernel.Core/src/AIKernel.Core/AIKernel.Core.csproj` |
| [`AIKernel.Hosting`](/reference/aikernel-core/aikernel-hosting/) | nuget | `0.1.3` | EN: Hosting and dependency injection extensions for AIKernel.NET. Provides IServiceCollection integration and startup wiring for ASP.NET Core and .NET Generi... | `AIKernel.Core/src/AIKernel.Hosting/AIKernel.Hosting.csproj` |
| [`AIKernel.Kernel`](/reference/aikernel-core/aikernel-kernel/) | nuget | `0.1.3` | EN: Kernel facade and orchestration layer for AIKernel.NET. Coordinates Core, Providers, Context, Governance, and execution flow through a unified IKernel in... | `AIKernel.Core/src/AIKernel.Kernel/AIKernel.Kernel.csproj` |
| [`aikernel-net`](/reference/aikernel-core/python/aikernel-net/) | python | `0.1.3` | Python binding for AIKernel Core 0.1.3 functional primitives, provider contracts, manifests, and managed assembly discovery. | `AIKernel.Core/python/pyproject.toml` |
| [`AIKernel.Control`](/reference/aikernel-control/aikernel-control/) | nuget | `0.1.3` | Entry package for AIKernel.Control v0.1.3. Installs the Control Core, CPU, Emulator, Diagnostics, and GPU boundary packages for governed semantic execution h... | `AIKernel.Control/src/AIKernel.Control/AIKernel.Control.csproj` |
| [`AIKernel.Control.Core`](/reference/aikernel-control/aikernel-control-core/) | nuget | `0.1.3` | Control-plane runtime entry package for AIKernel.Control. Provides Bonsai provider contracts, model config/tokenizer/model-state wrappers, provider capabilit... | `AIKernel.Control/src/AIKernel.Control.Core/AIKernel.Control.Core.csproj` |
| [`AIKernel.Control.CPU`](/reference/aikernel-control/aikernel-control-cpu/) | nuget | `0.1.3` | CPU execution package for AIKernel.Control. Provides the public Bonsai Q1_0 1-bit CPU inference kernel and CPU-side physical execution boundary for governed... | `AIKernel.Control/src/AIKernel.Control.CPU/AIKernel.Control.CPU.csproj` |
| [`AIKernel.Control.Diagnostics`](/reference/aikernel-control/aikernel-control-diagnostics/) | nuget | `0.1.3` | Diagnostics package for AIKernel.Control. Provides public replay approval diagnostics records and observability support for governed control-plane execution. | `AIKernel.Control/src/AIKernel.Control.Diagnostics/AIKernel.Control.Diagnostics.csproj` |
| [`AIKernel.Control.Emulator`](/reference/aikernel-control/aikernel-control-emulator/) | nuget | `0.1.3` | Deterministic emulator package for AIKernel.Control. Provides public emulated execution graph/node wrappers, deterministic scheduling, allow-all policy, and... | `AIKernel.Control/src/AIKernel.Control.Emulator/AIKernel.Control.Emulator.csproj` |
| [`AIKernel.Control.GPU`](/reference/aikernel-control/aikernel-control-gpu/) | nuget | `0.1.3` | GPU boundary package for AIKernel.Control. Provides the public Bonsai GPU execution delegate contract so CUDA, WebGPU, ROCm, Vulkan, or other device-specific... | `AIKernel.Control/src/AIKernel.Control.GPU/AIKernel.Control.GPU.csproj` |
| [`aikernel-governance`](/reference/aikernel-control/python/aikernel-governance/) | python | `0.1.3` | Python wrapper for AIKernel.Control v0.1.3 governance contracts with bundled managed assemblies and pythonnet loading. | `AIKernel.Control/python/pyproject.toml` |
| ... | ... | ... | 39 more packages are listed in the generated Reference. | ... |


## Notes

- `AIKernel.NET` owns contracts and canonical interface boundaries.
- `AIKernel.Core` owns runtime behavior.
- `AIKernel.Providers`, `AIKernel.Control`, `AIKernel.Tools`, `AIKernel.Wasm`, and `AIKernel.Cuda13.0` are separate package families.
- `AIKernel.Doom` is documented as an official demo and validation surface.

## See Also

- [What is AIKernel.NET](what-is-aikernel.md)
- [Quick Start](quick-start.md)
- [Reference](/reference/)
