---
title: "IDslCapabilityRegistry"
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

英語版: [IDslCapabilityRegistry.md](IDslCapabilityRegistry.md)

# IDslCapabilityRegistry

## 責務
deterministic DSL pipeline node が参照する capability name を解決し、実行する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `Contains(string name)` | `bool` | capability name が登録済みか確認する。 |
| `InvokeAsync(string name, DslPipelineValue input, IReadOnlyDictionary<string, string> args, CancellationToken cancellationToken = default)` | `Task<DslPipelineValue>` | deterministic input と string args を使って capability を実行する。 |

## 境界ルール
- unknown capability name は implementation layer で fail-closed にする。
- provider、tool、DSL ROM へ route してよいが、この contract 自体は provider-agnostic に保つ。
