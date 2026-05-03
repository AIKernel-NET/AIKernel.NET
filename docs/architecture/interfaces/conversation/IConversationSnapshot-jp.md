---
id: iconversationsnapshot
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IConversationSnapshot"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IConversationSnapshot.md を参照。

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



