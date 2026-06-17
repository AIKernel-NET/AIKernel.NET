---
title: "First Kernel"
lang: ja
description: "AIKernel.Core と provider package を使う最小構成の読み方を説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: tutorials
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---
# First Kernel

## 概要

First Kernel は、0.1.2 公式サイトで迷わず実作業へ進むための tutorial です。

## 背景

Tutorial page は workflow-based です。生成 API 一覧ではありません。

## 使い方

command 形を確認したら、実際の package と member の詳細は Reference で確認します。

## 例

```bash
dotnet add package AIKernel.Core --version 0.1.2
dotnet add package AIKernel.Providers.Standard --version 0.1.2
```

| Package | Kind | Version | Description | Source |
|---|---|---|---|---|
| [`AIKernel.Abstractions`](/reference/aikernel-net/aikernel-abstractions/) | nuget | `0.1.2` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Abstractions/AIKernel.Abstractions.csproj` |
| [`AIKernel.Contracts`](/reference/aikernel-net/aikernel-contracts/) | nuget | `0.1.2` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Contracts/AIKernel.Contracts.csproj` |
| [`AIKernel.Dtos`](/reference/aikernel-net/aikernel-dtos/) | nuget | `0.1.2` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Dtos/AIKernel.Dtos.csproj` |
| [`AIKernel.Enums`](/reference/aikernel-net/aikernel-enums/) | nuget | `0.1.2` | AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orche... | `AIKernel.NET/src/AIKernel.Enums/AIKernel.Enums.csproj` |
| [`AIKernel.Common`](/reference/aikernel-core/aikernel-common/) | nuget | `0.1.2` | English AIKernel.Common provides foundational utility components shared across the AIKernel ecosystem. This package contains cross-cutting features such as f... | `AIKernel.Core/src/AIKernel.Common/AIKernel.Common.csproj` |
| [`AIKernel.Core`](/reference/aikernel-core/aikernel-core/) | nuget | `0.1.2` | EN: Core runtime engine for AIKernel.NET. Provides the foundational execution logic for VFS, ROM, Context construction, and inference execution in a determin... | `AIKernel.Core/src/AIKernel.Core/AIKernel.Core.csproj` |
| [`AIKernel.Hosting`](/reference/aikernel-core/aikernel-hosting/) | nuget | `0.1.2` | EN: Hosting and dependency injection extensions for AIKernel.NET. Provides IServiceCollection integration and startup wiring for ASP.NET Core and .NET Generi... | `AIKernel.Core/src/AIKernel.Hosting/AIKernel.Hosting.csproj` |
| [`AIKernel.Kernel`](/reference/aikernel-core/aikernel-kernel/) | nuget | `0.1.2` | EN: Kernel facade and orchestration layer for AIKernel.NET. Coordinates Core, Providers, Context, Governance, and execution flow through a unified IKernel in... | `AIKernel.Core/src/AIKernel.Kernel/AIKernel.Kernel.csproj` |
| ... | ... | ... | 47 more packages are listed in the generated Reference. | ... |

## 補足

- Commands are examples of package selection, not a guarantee that every environment has all optional runtimes installed.
- CUDA and Doom assets have separate runtime requirements.
- Keep implementation changes outside documentation-only work.

## 関連ページ

- [Docs](/docs/)
- [Reference](/reference/)
- [Glossary](/glossary/)
