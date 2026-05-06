---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "material Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# material Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Material は外部由来データの取り込み境界です。`IMaterialQuarantine` と `IStructuredMaterial` を通じて、生素材を検疫・構造化し、推論入力に直接混入させないことを保証します。

## 2. 関連ユースケース (Related UCs)
- `UC-05` 素材の関連性評価
- `UC-07` 素材検疫
- `UC-21` マテリアル検疫とポリシー実行

## 3. 関連仕様 (Related Specs)
- `01.EXECUTION_PIPELINE_SPEC-jp.md`
- `03.ROM_CORE_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos.Context`, `AIKernel.Dtos.Rom`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Providers`

## ドキュメント一覧
- IMaterialQuarantine-jp.md
- IStructuredMaterial-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
