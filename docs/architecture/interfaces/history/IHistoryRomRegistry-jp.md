---
title: "IHistoryRomRegistry"
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
  - history
  - japanese
---

英語版: [IHistoryRomRegistry.md](IHistoryRomRegistry.md)

# IHistoryRomRegistry

## 責務
immutable History ROM snapshot を登録・解決する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `RegisterAsync(HistoryRomSnapshot snapshot, CancellationToken cancellationToken = default)` | `Task<HistoryRomMetadata>` | History ROM snapshot を登録し metadata を返す。 |
| `Contains(string romId)` | `bool` | History ROM id が登録済みか確認する。 |
| `ResolveAsync(string romId, CancellationToken cancellationToken = default)` | `Task<HistoryRomSnapshot>` | 登録済み History ROM snapshot を解決する。 |

## 境界ルール
- registry entry は受理後 immutable である。
- hash identity は resolve call をまたいで保持する。
