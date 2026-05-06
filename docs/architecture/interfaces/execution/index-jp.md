---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "execution Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# execution Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Execution は推論実行の中核境界です。`IThoughtProcess` が構造推論、`IOutputPolisher` が表現整形、`IComputeShapeAdvisor` と `ITokenizer` が計算制約を管理し、二段階実行と再現性を支えます。

## 2. 関連ユースケース (Related UCs)
- `UC-02` Structure フェーズ実行
- `UC-04` 生成と出力整形
- `UC-30` トークン・ベクトル推定

## 3. 関連仕様 (Related Specs)
- `01.EXECUTION_PIPELINE_SPEC-jp.md`
- `04.MODEL_ROUTING_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos`, `AIKernel.Enums`, `AIKernel.Contracts`
- Called by: `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Routing`

## ドキュメント一覧
- IComputeShapeAdvisor-jp.md
- IOutputPolisher-jp.md
- IThoughtProcess-jp.md
- ITokenizer-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
