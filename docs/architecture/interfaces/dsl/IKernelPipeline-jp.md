---
title: "IKernelPipeline"
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

英語版: [IKernelPipeline.md](IKernelPipeline.md)

# IKernelPipeline

## 責務
compiled DSL pipeline を deterministic DSL execution context に対して実行する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `ExecuteAsync(DslPipelineExecutionContext context, CancellationToken cancellationToken = default)` | `Task<DslPipelineExecutionResult>` | compiled pipeline を実行し、value / metadata / replay log / status を返す。 |

## 境界ルール
- contract は internal `ResultStep` type ではなく execution result DTO を公開する。
- implementation は同じ input に対する replay-log と hash の決定論性を保持する。
