---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "conversation Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# conversation Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Conversation は対話履歴の分岐・差分・時系列復元を扱う境界です。スナップショット系インターフェースにより、長期セッションでも追跡可能性と再現性を維持します。

## 2. 関連ユースケース (Related UCs)
- `UC-17` Chat Diffing
- `UC-18` 会話永続化
- `UC-20` 決定論的リプレイ

## 3. 関連仕様 (Related Specs)
- `01.EXECUTION_PIPELINE_SPEC-jp.md`
- `06.REPLAY_DUMP_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos.Context`, `AIKernel.Dtos.Core`
- Called by: `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Vfs`

## ドキュメント一覧
- IConversationBranch-jp.md
- IConversationCheckpoint-jp.md
- IConversationDiff-jp.md
- IConversationSnapshot-jp.md
- IConversationStore-jp.md
- IConversationTimeline-jp.md
- IDiffFormatter-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
