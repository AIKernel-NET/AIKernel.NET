---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "tooling Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# tooling Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Tooling は外部ツール呼び出しの安全境界です。`IToolAccessValidator` が可否判定を、`IToolPermission` が権限定義を、`IToolSandbox` が実行隔離を担い、実行プロセスから逸脱した副作用を防ぎます。

## 2. 関連ユースケース (Related UCs)
- `UC-10` ツール呼び出し制御
- `UC-21` ポリシー実行

## 3. 関連仕様 (Related Specs)
- `01.EXECUTION_PIPELINE_SPEC-jp.md`
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Security`, `AIKernel.Abstractions.Hosting`

## ドキュメント一覧
- IToolAccessValidator-jp.md
- IToolPermission-jp.md
- IToolSandbox-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
