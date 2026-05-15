---
title: "prompt Interfaces"
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
- [IPromptRepository](architecture/interfaces/prompt/IPromptRepository-jp.md)
- [IPromptSignatureProvider](architecture/interfaces/prompt/IPromptSignatureProvider-jp.md)
- [ISignatureTrustStore (インターフェース仕様)](architecture/interfaces/governance/ISignatureTrustStore-jp.md)
- [IPromptValidator](architecture/interfaces/prompt/IPromptValidator-jp.md)
- [IPromptVerifier (インターフェース仕様)](architecture/interfaces/prompt/IPromptVerifier-jp.md)
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新

