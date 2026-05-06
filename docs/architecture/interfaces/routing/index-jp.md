---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "routing Interfaces"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# routing Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Routing は、要求能力・制約・実行状況に基づくモデル選定の境界です。`IModelVectorRouter` が意思決定を、`ICapabilityRegistry` が候補情報の解決を担当し、Replay 時は固定条件を優先します。

## 2. 関連ユースケース (Related UCs)
- `UC-03` モデルベクトルルーティング
- `UC-22` 動的キャパシティ制御とモデルルーティング
- `UC-30` トークン・ベクトル推定

## 3. 関連仕様 (Related Specs)
- `04.MODEL_ROUTING_SPEC-jp.md`
- `06.REPLAY_DUMP_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`

## ドキュメント一覧
- ICapabilityRegistry-jp.md
- IModelVectorRouter-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
