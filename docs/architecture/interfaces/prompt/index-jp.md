---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "prompt Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# prompt Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Prompt は署名済み入力を実行可能状態へ昇格させる境界です。`IPromptVerifier`、`IPromptValidator`、`ISignatureTrustStore` が整合性・信頼連鎖・実行スコープを検証し、失敗時は必ず拒否します。

## 2. 関連ユースケース (Related UCs)
- `UC-11` プロンプト静的検証
- `UC-13` 実行時署名検証
- `UC-20` 決定論的リプレイ

## 3. 関連仕様 (Related Specs)
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md`
- `06.REPLAY_DUMP_SPEC-jp.md`

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Governance`, `AIKernel.Abstractions.Execution`

## ドキュメント一覧
- IPromptRepository-jp.md
- IPromptSignatureProvider-jp.md
- ISignatureTrustStore-jp.md
- IPromptValidator-jp.md
- IPromptVerifier-jp.md
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新

