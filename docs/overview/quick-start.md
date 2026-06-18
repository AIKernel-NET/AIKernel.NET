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

## Summary

### EN

Quick Start gives a source-backed path for installing the stable 0.1.2 package line and navigating the generated reference.

### JA

Quick Start は stable 0.1.2 package line を導入し、生成 Reference を読むための最短経路を示します。

## Why

### EN

A useful quick start must avoid hidden assumptions. The examples below name package IDs that are present in repository project metadata.

### JA

有用な quick start は隠れた前提を避ける必要があります。以下の例は repository の project metadata に存在する package ID を使います。

## Usage

### EN

Install only the package family you need, then open the matching Reference page to inspect members and source paths.

### JA

必要な package family だけを導入し、対応する Reference page で member と source path を確認します。

## Examples

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


## Notes

- CUDA support is an external Capability package, not a Core dependency.
- Doom runtime assets are consent-gated and are documented separately.
- If a package is not listed in Reference, verify the corresponding `.csproj` or `pyproject.toml` first.

## See Also

- [Reference](/reference/)
- [First Kernel Tutorial](/tutorials/first-kernel/)
- [Configuration](../runtime/configuration.md)
