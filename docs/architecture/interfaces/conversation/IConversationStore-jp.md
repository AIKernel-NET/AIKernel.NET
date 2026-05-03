---
id: iconversationstore
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IConversationStore"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IConversationStore.md を参照。

# IConversationStore

## Responsibility
IConversationStore が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default)` | `Task` | Persist conversation snapshot. |
| `GetSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task<IConversationSnapshot?>` | Load snapshot by id. |
| `ListBranchesAsync(CancellationToken ct = default)` | `Task<IReadOnlyList<IConversationBranch>>` | Enumerate branches. |
| `DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task` | Delete snapshot by id. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IConversationStore 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



