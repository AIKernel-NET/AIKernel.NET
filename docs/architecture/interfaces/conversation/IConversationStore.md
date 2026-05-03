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
  - english
---

For Japanese version, see IConversationStore-jp.md.

# IConversationStore

## Responsibility
Define the contract boundary for IConversationStore within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default)` | `Task` | Persist conversation snapshot. |
| `GetSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task<IConversationSnapshot?>` | Load snapshot by id. |
| `ListBranchesAsync(CancellationToken ct = default)` | `Task<IReadOnlyList<IConversationBranch>>` | Enumerate branches. |
| `DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task` | Delete snapshot by id. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IConversationStore appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



