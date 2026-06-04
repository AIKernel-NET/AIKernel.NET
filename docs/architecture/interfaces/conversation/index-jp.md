---
title: "conversation Interfaces"
created: 2026-05-03
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版: [Index](index.md)

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
- [IConversationBranch](../conversation/IConversationBranch-jp.md)
- [IConversationCheckpoint](../conversation/IConversationCheckpoint-jp.md)
- [IConversationDiff](../conversation/IConversationDiff-jp.md)
- [IConversationSnapshot](../conversation/IConversationSnapshot-jp.md)
- [IConversationStore](../conversation/IConversationStore-jp.md)
- [IConversationTimeline](../conversation/IConversationTimeline-jp.md)
- [IDiffFormatter](../conversation/IDiffFormatter-jp.md)
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
