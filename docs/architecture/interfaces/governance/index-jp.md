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
v0.0.5 では、Core/runtime package が fail-closed な pre-inference evidence を ReplayLog へ接続できるように、admission replay record と Semantic IR slot vocabulary も contract package 側で公開します。ただし実装挙動は AIKernel.NET には置きません。

## 2. 関連ユースケース (Related UCs)
- `UC-13` 実行時署名検証とガバナンス
- `UC-20` 決定論的リプレイと監査
- `UC-21` ポリシー実行

## 3. 関連仕様 (Related Specs)
- [署名付きプロンプトガバナンス仕様](../../../specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md)
- [Semantic Context OS Vision](../../16.SEMANTIC_CONTEXT_OS_VISION-jp.md)

## 4. 依存境界 (Dependency Boundary)
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Prompt`

## 5. ドキュメント一覧
- [ISignatureTrustStore](ISignatureTrustStore-jp.md)
- [IAttentionGuard](IAttentionGuard-jp.md)
- [IAttentionObserver](IAttentionObserver-jp.md)
- [IAuditEvent](IAuditEvent-jp.md)
- [IAuditLogger](IAuditLogger-jp.md)
- [IAuditEventContract](IAuditEventContract-jp.md)
- [IContextLifecycleManager](IContextLifecycleManager-jp.md)
- [IChatTurn HashChain Contracts](IChatTurnHashChainContracts-jp.md)

## 6. Shared DTO / Enum Vocabulary
- `AdmissibilityReplayRecord`: pre-inference admission gate が出力する ReplayLog-compatible evidence。
- `AdmissibilityGateKind`: prompt override、capability admission、critical operation、computational complexity、policy decision、context integrity、runtime invariant の gate vocabulary。
- `AdmissibilityDecisionKind`: admit、deny、suspend for approval、clarify、read-only、delegate、quarantine の decision vocabulary。
- `SemanticIrSlot`: semantic compilation と DSL admission が共有する G/T/C/B Semantic IR slot vocabulary。

`AdmissibilityReplayRecord.Metadata` は、validator version、budget、complexity profile、attached requirement、delegated solver identity、timestamp、trace identifier など、論文レベルの field を運ぶ拡張点です。Runtime package は ReplayLog へ接続する前に、これらの metadata を正準化・hash 化してください。

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.4 (2026-06-04): IHistorySummarizer documentation を history interface category へ移動。
- v0.0.4 (2026-06-04): ChatChain governance contract documentation を追加。
- v0.0.4 (2026-06-04): IAuditLogger を governance interface index に追加。
- v0.0.5 (2026-06-05): admission replay と Semantic IR slot vocabulary の説明を追加。
