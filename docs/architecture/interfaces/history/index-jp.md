---
title: "history Interfaces"
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

英語版: [history/index.md](index.md)

# history Interfaces

## 1. 責務境界
History contract は、履歴要約と immutable History ROM 公開を定義する。
conversation storage の内部、Vfs 実装詳細、Core 固有の Result monad は所有しない。

## 2. 公開 Contract
- [IHistorySummarizer](IHistorySummarizer-jp.md)
- [IChatHistoryRomExporter](IChatHistoryRomExporter-jp.md)
- [IHistoryRomRegistry](IHistoryRomRegistry-jp.md)
- [IHistoryRomStore](IHistoryRomStore-jp.md)

## 3. DTO Surface
- `ChatHistoryRomRecord`
- `ChatHistoryRomOptions`
- `HistoryRomMetadata`
- `HistoryRomSnapshot`

## 4. 関連 Spec
- `docs/architecture/18.DSL_PIPELINE_AND_ROM_SPEC-jp.md`
- `docs/operations/MIGRATION_GUIDE-jp.md`

## 境界ルール
- History ROM content は登録後 immutable である。
- timestamp は caller または deterministic clock boundary から渡す。
- contract package は `AIKernel.Core` や `AIKernel.Common` に依存してはならない。

---

# 変更履歴
- v0.0.4 (2026-06-04): package-public contract のため History ROM interface category を追加。
