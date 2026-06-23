---
title: "Messages"
lang: ja
description: "request、response、context、carrier、DTO の流れと source-backed Reference への導線を説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---
# Messages

## 概要

このページでは Messages を repository metadata と generated Reference に基づいて説明します。

## 背景

Concept page は人間に役立つ説明を置くためにあります。単なる生成表ではなく、API surface がなぜ分割されているかを説明します。

## 使い方

まず概念を読み、正確な member と source path は package Reference で確認します。

## 例

### Source-backed Example

`AIKernel.NET` owns DTO and contract package boundaries; behavior belongs outside the contract package surface.

### Package context

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
| ... | ... | ... | 45 more packages are listed in the generated Reference. | ... |

## 補足

- Message/DTO は runtime behavior と混同しないことが重要です。
- If a behavior is not confirmed in source or tests, this documentation leaves it as `TODO: source required`.
- Generated Reference pages are separated from these hand-written guide pages.

## 関連ページ

- [Architecture](../architecture/index.md)
- [Runtime](../runtime/index.md)
- [Reference](/reference/)
