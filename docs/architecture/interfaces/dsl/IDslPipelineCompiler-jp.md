---
title: "IDslPipelineCompiler"
created: 2026-06-04
updated: 2026-06-04
published: 2026-06-04
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - dsl
  - japanese
---

英語版: [IDslPipelineCompiler.md](IDslPipelineCompiler.md)

# IDslPipelineCompiler

## 責務
parsed `DslDocument` を executable `IKernelPipeline` へ compile する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `CompileAsync(DslDocument document, CancellationToken cancellationToken = default)` | `Task<IKernelPipeline>` | DSL semantic IR を検証し、pipeline contract へ compile する。 |

## 境界ルール
- DSL は C# source code ではなく structured data として扱う。
- 同じ document と registry state からの compile は deterministic であること。
- invalid DSL は implementation result として fail-closed にする。
