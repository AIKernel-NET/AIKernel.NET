---
title: "IDslRomStore"
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

英語版: [IDslRomStore.md](IDslRomStore.md)

# IDslRomStore

## 責務
caller-provided Vfs session を通じて DSL ROM JSON を保存・読み込みする境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `SaveDslAsRomAsync(...)` | `Task<DslRomMetadata>` | JSON DSL を検証し、immutable ROM artifact として保存する。 |
| `LoadDslRomAsync(...)` | `Task<DslRomMetadata>` | DSL ROM を読み込み、expected hash を検証する。 |

## 境界ルール
- Vfs session の lifetime と permission は caller が所有する。
- expected ROM hash mismatch は implementation で fail-closed にする。
