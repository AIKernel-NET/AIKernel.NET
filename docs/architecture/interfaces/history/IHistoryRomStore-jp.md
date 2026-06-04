---
title: "IHistoryRomStore"
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

英語版: [IHistoryRomStore.md](IHistoryRomStore.md)

# IHistoryRomStore

## 責務
caller-provided Vfs session を通じて History ROM artifact を保存・読み込みする境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `SaveHistoryAsRomAsync(...)` | `Task<HistoryRomMetadata>` | record を History ROM へ変換し、Vfs 経由で保存する。 |
| `SaveMarkdownAsRomAsync(...)` | `Task<HistoryRomMetadata>` | 生成済み History ROM Markdown を保存する。 |
| `LoadHistoryRomAsync(...)` | `Task<HistoryRomMetadata>` | History ROM を読み込み、必要に応じて hash を検証する。 |

## 境界ルール
- Vfs session の lifetime と read/write permission は caller が所有する。
- hash mismatch は implementation で fail-closed にする。
