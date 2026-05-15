---
title: "provider Interfaces"
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

# provider Interfaces

## 1. 責務の境界
Provider は外部LLM/Embedding/RAG 実行境界です。`IModelVectorRouter` が選定した経路を、`IProvider`/`IModelProvider` 系が実行し、課金・利用率・健全性指標・query-processing support・embedding metadata を `IProvider*` 群で観測可能にします。

## 2. 関連ユースケース
- `UC-03` モデルベクトルルーティング
- `UC-19` マルチモデル並列推論
- `UC-22` 動的キャパシティ制御
- `UC-23` AIクレジット管理
- Phase 1 Query Processing

## 3. 関連仕様
- `docs/specs/04.MODEL_ROUTING_SPEC-jp.md`
- `docs/specs/06.REPLAY_DUMP_SPEC-jp.md`
- `docs/specs/01.EXECUTION_PIPELINE_SPEC-jp.md`
- `docs/architecture/17.QUERY_PROCESSING_PHASE1-jp.md`

## ドキュメント一覧
- [IProvider (インターフェース仕様)](architecture/interfaces/provider/IProvider-jp.md)
- [IModelProvider (インターフェース仕様)](architecture/interfaces/provider/IModelProvider-jp.md)
- [IModelMessage (インターフェース仕様)](architecture/interfaces/provider/IModelMessage-jp.md)
- [IEmbeddingProvider (インターフェース仕様)](architecture/interfaces/provider/IEmbeddingProvider-jp.md)
- [IRagProvider (インターフェース仕様)](architecture/interfaces/provider/IRagProvider-jp.md)
- [IEventBus (インターフェース仕様)](architecture/interfaces/provider/IEventBus-jp.md)
- [IScheduler (インターフェース仕様)](architecture/interfaces/provider/IScheduler-jp.md)
- [IProviderCapabilities (インターフェース仕様)](architecture/interfaces/provider/IProviderCapabilities-jp.md)
- [IProviderCostProfile (インターフェース仕様)](architecture/interfaces/provider/IProviderCostProfile-jp.md)
- [IProviderCreditInfo (インターフェース仕様)](architecture/interfaces/provider/IProviderCreditInfo-jp.md)
- [IProviderBillingInfo (インターフェース仕様)](architecture/interfaces/provider/IProviderBillingInfo-jp.md)
- [IProviderUsageStats (利用統計インターフェース仕様)](architecture/interfaces/provider/IProviderUsageStats-jp.md)
- [IProviderResourceProfile (統合リソースプロファイル仕様)](architecture/interfaces/provider/IProviderResourceProfile-jp.md)
- [IProviderRouter](architecture/interfaces/provider/IProviderRouter-jp.md)

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): Router/Capacity 境界と観測指標を追記
- v0.0.1 (2026-05-09): query-processing capability boundary を追加
