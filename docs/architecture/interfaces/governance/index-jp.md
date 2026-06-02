---
title: "governance Interfaces"
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

英語版: [Governance Interfaces](index.md)

# Governance Interfaces

## 1. 責務の境界 (Responsibility Boundary)
Governance は実行許可・監査・注意品質監視を担う境界です。`IAttentionGuard` と `IAttentionObserver` が推論品質を監視し、`IAuditEvent` 系が追跡可能な監査証跡を確立します。

## 2. 関連ユースケース (Related UCs)
- `UC-13` 実行時署名検証とガバナンス
- `UC-20` 決定論的リプレイと監査
- `UC-21` ポリシー実行

## 3. 関連仕様 (Related Specs)
- [署名付きプロンプトガバナンス仕様](../../02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md)
- [Semantic Context OS Vision](../../16.SEMANTIC_CONTEXT_OS_VISION-jp.md)

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Prompt`

## 5. ドキュメント一覧
- [ISignatureTrustStore](ISignatureTrustStore-jp.md)
- [IAttentionGuard](IAttentionGuard-jp.md)
- [IAttentionObserver](IAttentionObserver-jp.md)
- [IAuditEvent](IAuditEvent-jp.md)
- [IAuditEventContract](IAuditEventContract-jp.md)
- [IContextLifecycleManager](IContextLifecycleManager-jp.md)
- [IHistorySummarizer](IHistorySummarizer-jp.md)

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
