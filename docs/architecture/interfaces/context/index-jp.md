---
title: "context Interfaces"
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

英語版: [Specification Index](specs/index.md)

# context Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Context は推論サイクル内の作業記憶を管理します。`IContextCollection` がバッファ境界を、`IContextSnapshot` が監査・再現用の固定点を提供し、3層分離と決定論的リプレイを支えます。

## 2. 関連ユースケース (Related UCs)
- `UC-06` 3層バッファ境界
- `UC-09` 実行状態の永続化と復元
- `UC-20` 決定論的リプレイと監査証跡

## 3. 関連仕様 (Related Specs)
- `01.EXECUTION_PIPELINE_SPEC-jp.md`
- `06.REPLAY_DUMP_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos.Context`, `AIKernel.Dtos.Kernel`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Conversation`

## ドキュメント一覧
- [IContextCollection (インターフェース仕様)](architecture/interfaces/context/IContextCollection-jp.md)
- [IContextSnapshot (インターフェース仕様)](architecture/interfaces/context/IContextSnapshot-jp.md)
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
