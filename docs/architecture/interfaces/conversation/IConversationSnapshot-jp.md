---
id: iconversationsnapshot
title: "IConversationSnapshot"
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

英語版: [IConversationSnapshot](architecture/interfaces/conversation/IConversationSnapshot.md)

# IConversationSnapshot

## Responsibility
IConversationSnapshot が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `SnapshotId` | `string` | Conversation snapshot id. |
| `BranchId` | `string` | Owning branch id. |
| `TimestampUtc` | `DateTimeOffset` | Snapshot creation timestamp. |
| `MessageCount` | `int` | Number of messages in snapshot. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IConversationSnapshot 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
