---
title: "Quick Start"
lang: ja
description: "AIKernel.NET 0.1.2 を最小構成で確認するための package install、repository build、Reference の読み方を示します。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---
# Quick Start

## 概要

Quick Start は stable 0.1.2 package line を導入し、生成 Reference を読むための最短経路を示します。

## 背景

有用な quick start は隠れた前提を避ける必要があります。以下の例は repository の project metadata に存在する package ID を使います。

## 使い方

必要な package family だけを導入し、対応する Reference page で member と source path を確認します。

## 例

### NuGet

```bash
dotnet add package AIKernel.Core --version 0.1.2
dotnet add package AIKernel.Hosting --version 0.1.2
dotnet add package AIKernel.Providers.Standard --version 0.1.2
```

### Python wrappers

```bash
pip install aikernel-net==0.1.2
pip install aikernel-providers==0.1.2
pip install aikernel-tools==0.1.2
```

### Source build check

```bash
dotnet build AIKernel.Core/AIKernel.Core.slnx
dotnet build AIKernel.Providers/AIKernel.Providers.slnx
```

## 補足

- CUDA support is an external Capability package, not a Core dependency.
- Doom runtime assets are consent-gated and are documented separately.
- If a package is not listed in Reference, verify the corresponding `.csproj` or `pyproject.toml` first.

## 関連ページ

- [Reference](/reference/)
- [First Kernel Tutorial](/tutorials/first-kernel/)
- [Configuration](../runtime/configuration.md)
