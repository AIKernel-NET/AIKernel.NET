---
title: "Core Concepts"
lang: ja
description: "Kernel、Provider、Tool、Runtime、Message、Extension という AIKernel.NET の主要概念をまとめます。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---

# Core Concepts

## Summary

### EN

This page explains core concepts using repository metadata and links to the generated Reference.

### JA

このページでは Core Concepts を repository metadata と generated Reference に基づいて説明します。

## Why

### EN

Concept pages exist to keep the site useful for humans. They explain why the API surface is split instead of publishing only generated tables.

### JA

Concept page は人間に役立つ説明を置くためにあります。単なる生成表ではなく、API surface がなぜ分割されているかを説明します。

## Usage

### EN

Read the concept first, then open package Reference for exact members and source paths.

### JA

まず概念を読み、正確な member と source path は package Reference で確認します。

## Examples

### Source-backed Example

concept overview

### Package context

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
| [`aikernel-net`](/reference/aikernel-core/python/aikernel-net/) | python | `0.1.2` | Python binding for AIKernel Core 0.1.2 functional primitives, provider contracts, manifests, and managed assembly discovery. | `AIKernel.Core/python/pyproject.toml` |
| [`AIKernel.Control`](/reference/aikernel-control/aikernel-control/) | nuget | `0.1.2` | Entry package for AIKernel.Control v0.1.2. Installs the Control Core, CPU, Emulator, Diagnostics, and GPU boundary packages for governed semantic execution h... | `AIKernel.Control/src/AIKernel.Control/AIKernel.Control.csproj` |
| ... | ... | ... | 45 more packages are listed in the generated Reference. | ... |

## Notes

- AIKernel.NET の概念は package 境界と一緒に読む必要があります。
- If a behavior is not confirmed in source or tests, this documentation leaves it as `TODO: source required`.
- Generated Reference pages are separated from these hand-written guide pages.

## See Also

- [Architecture](../architecture/index.md)
- [Runtime](../runtime/index.md)
- [Reference](/reference/)
