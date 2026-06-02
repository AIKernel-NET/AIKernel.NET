---
title: "pipeline Interfaces"
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

# pipeline Interfaces

## 1. 責務の境界
Pipeline はステートフル実行遷移を制御する境界です。`IPipelineOrchestrator` と `IPipelineStep` が遷移順序を固定し、`IStructurePlanner`/`ITaskManager` がフェーズ内責務を分離します。

## 2. 関連ユースケース
- `UC-02` Structure フェーズ
- `UC-29` タスクパイプライン管理
- `UC-30` トークン・ベクトル推定

## 3. 関連仕様
- `docs/specs/01.EXECUTION_PIPELINE_SPEC-jp.md`
- `docs/specs/04.MODEL_ROUTING_SPEC-jp.md`

## ドキュメント一覧
- [IPipelineOrchestrator](architecture/interfaces/pipeline/IPipelineOrchestrator-jp.md)
- [IPipelineStep](architecture/interfaces/pipeline/IPipelineStep-jp.md)
- [IStructurePlanner](architecture/interfaces/pipeline/IStructurePlanner-jp.md)
- [ITaskManager](architecture/interfaces/pipeline/ITaskManager-jp.md)
- [ITaskVectorEstimator](architecture/interfaces/pipeline/ITaskVectorEstimator-jp.md)

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ステート遷移とガバナンス観点を追加
