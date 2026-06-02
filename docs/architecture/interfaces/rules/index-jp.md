---
title: "rules Interfaces"
created: 2026-05-06
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

# rules Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Rules は AIKernel の統治判定層です。`IRuleEngine` を中心に、入力・中間状態・出力が組織ポリシーへ適合するかを決定論的に評価し、判定不能時は常に Fail-Closed 側へ倒します。

## 2. 関連ユースケース (Related UCs)
- `UC-11` プロンプト静的検証
- `UC-13` 実行時署名検証とガバナンス
- `UC-21` マテリアル検疫とポリシー実行

## 3. 関連仕様 (Related Specs)
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md`
- `01.EXECUTION_PIPELINE_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos.Rules`, `AIKernel.Contracts`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Security`, `AIKernel.Abstractions.Governance`

## ドキュメント一覧
- [IRuleEngine (ルールエンジン仕様)](architecture/interfaces/rules/IRuleEngine-jp.md)
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
