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
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

Japanese version: [IConversationSnapshot](architecture/interfaces/conversation/IConversationSnapshot-jp.md)

# IConversationSnapshot

## Responsibility
Define the contract boundary for IConversationSnapshot within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `SnapshotId` | `string` | Conversation snapshot id. |
| `BranchId` | `string` | Owning branch id. |
| `TimestampUtc` | `DateTimeOffset` | Snapshot creation timestamp. |
| `MessageCount` | `int` | Number of messages in snapshot. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IConversationSnapshot appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
