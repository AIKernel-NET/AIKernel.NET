---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "provider Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# provider Interfaces

## 1. 責務の境界
Provider は外部LLM/Embedding/RAG 実行境界です。`IModelVectorRouter` が選定した経路を、`IProvider`/`IModelProvider` 系が実行し、課金・利用率・健全性指標を `IProvider*` 群で観測可能にします。

## 2. 関連ユースケース
- `UC-03` モデルベクトルルーティング
- `UC-19` マルチモデル並列推論
- `UC-22` 動的キャパシティ制御
- `UC-23` AIクレジット管理

## 3. 関連仕様
- `docs/specs/04.MODEL_ROUTING_SPEC-jp.md`
- `docs/specs/06.REPLAY_DUMP_SPEC-jp.md`

## ドキュメント一覧
- IProvider-jp.md
- IModelProvider-jp.md
- IModelMessage-jp.md
- IEmbeddingProvider-jp.md
- IRagProvider-jp.md
- IEventBus-jp.md
- IScheduler-jp.md
- IProviderCapabilities-jp.md
- IProviderCostProfile-jp.md
- IProviderCreditInfo-jp.md
- IProviderBillingInfo-jp.md
- IProviderUsageStats-jp.md
- IProviderResourceProfile-jp.md
- IProviderRouter-jp.md

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): Router/Capacity 境界と観測指標を追記
