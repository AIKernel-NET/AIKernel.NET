---
title: "IDslRomRegistry"
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

英語版: [IDslRomRegistry.md](IDslRomRegistry.md)

# IDslRomRegistry

## 責務
immutable DSL ROM snapshot を reusable capability として登録・解決する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `RegisterAsync(DslRomSnapshot snapshot, CancellationToken cancellationToken = default)` | `Task<DslRomMetadata>` | DSL ROM snapshot を登録し、deterministic metadata を返す。 |
| `Contains(string capabilityName)` | `bool` | DSL ROM capability が登録済みか確認する。 |
| `ResolveAsync(string capabilityName, CancellationToken cancellationToken = default)` | `Task<DslRomSnapshot>` | 登録済み DSL ROM capability を snapshot として解決する。 |

## 境界ルール
- registry 実装は ROM immutability と hash identity を保持する。
- runtime execution は ROM hash metadata を replay / audit output に記録する。
