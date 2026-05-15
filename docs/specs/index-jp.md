---
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

英語版: [Specification Index](specs/index.md)

# Specification Index

## 1. 目的
`docs/specs` は AIKernel の規範仕様（Normative Specs）を定義します。実装は常に本仕様の MUST / MUST NOT に従い、判定不能時は Fail-Closed を原則とします。

## 2. 仕様群の関係
- RCS（ROM Core）: 知能資産の構造・正準化・ハッシュ不変性
- SGS（Signed Prompt Governance）: 実行前の信頼チェーンと非推論型PDP
- MRS（Model Routing）: 動的選定とリプレイ時の固定化
- RDS（Replay Dump）: 決定論的再現のための凍結コンテキスト

## 3. 相互依存の要点
- `RCS` の正準化結果を `SGS` が署名・検証に利用
- `MRS` の選定結果を `RDS` が `LockedProviderInfo` として固定
- `SGS` と `RDS` は実行前後の監査チェーンを連結

## 4. ドキュメント一覧
- [01.EXECUTION_PIPELINE_SPEC-jp.md](01.EXECUTION_PIPELINE_SPEC-jp.md)
- [02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md](02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md)
- [03.ROM_CORE_SPEC-jp.md](03.ROM_CORE_SPEC-jp.md)
- [04.MODEL_ROUTING_SPEC-jp.md](04.MODEL_ROUTING_SPEC-jp.md)
- [05.MATERIAL_QUARANTINE_SPEC-jp.md](05.MATERIAL_QUARANTINE_SPEC-jp.md)
- [06.REPLAY_DUMP_SPEC-jp.md](06.REPLAY_DUMP_SPEC-jp.md)

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): RCS/SGS/MRS/RDS の相互関係を明文化
