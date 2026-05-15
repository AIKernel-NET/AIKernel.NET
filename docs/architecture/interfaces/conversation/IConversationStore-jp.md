---
id: iconversationstore
title: "IConversationStore"
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

英語版: [IConversationStore](architecture/interfaces/conversation/IConversationStore.md)

# IConversationStore

## 1. 概要
`IConversationStore` は、AIKernel.NET における会話履歴（メッセージ群）および実行状態の永続化を担う抽象化レイヤーです。  
単なるストレージインターフェースではなく、RDS（Replay/Resource Data Spec）に基づき、後日「決定論的再現（Deterministic Replay）」を行うために必要なメタデータ一式を保存する責務を持ちます。

## 2. 設計原則
- Immutability（MRS連携）: 保存されたメッセージリソースは改ざん不可とし、一意IDで追跡可能にする。
- Deterministic Traceability: メッセージ本体だけでなく、`Seed`、`Temperature`、`RCS-ID`（使用ツールや契約バージョン）をセットで保持する。
- Fail-Closed Retrieval: 取得データのチェックサム不一致、または署名チェーン不整合時はロード拒否し実行を停止する。

## 3. Signature
| Member | Type | 説明 |
| --- | --- | --- |
| `SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default)` | `Task` | Persist conversation snapshot. |
| `GetSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task<IConversationSnapshot?>` | Load snapshot by id. |
| `ListBranchesAsync(CancellationToken ct = default)` | `Task<IReadOnlyList<IConversationBranch>>` | Enumerate branches. |
| `DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task` | Delete snapshot by id. |

## 4. 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IConversationStore 参照箇所を基準とする。

## 5. Spec Links
- [04.MODEL_ROUTING_SPEC-jp.md](../../../specs/04.MODEL_ROUTING_SPEC-jp.md) / `MRS-001`, `MRS-004`  
  各メッセージの一意性（ID体系）と、選定根拠の監査可能性を維持する前提を満たす。
- [02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md](../../../specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md) / `SGS-006`  
  履歴ロード時の信頼チェーン検証（署名者・鍵失効状態）と整合すること。
- [06.REPLAY_DUMP_SPEC-jp.md](../../../specs/06.REPLAY_DUMP_SPEC-jp.md) / `RDS-001`, `RDS-002`  
  リプレイに必要なメタデータ保持と、ハッシュ解決可能性の前提を満たすこと。

## 6. Constraints
- 保存されるメッセージは、`IRomDocument` 同様にセマンティック一貫性とハッシュ不変性を満たすこと。
- 取得時に1ビットでも不整合があれば `DeterministicReplayException` 相当で中断すること。
- 同一入力・同一順序では同一取得順序を返し、決定論的リプレイを阻害しないこと。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
