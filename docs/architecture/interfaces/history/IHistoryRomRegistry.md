---
title: "IHistoryRomRegistry"
created: 2026-06-04
updated: 2026-06-04
published: 2026-06-04
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - history
  - english
---

Japanese version: [IHistoryRomRegistry-jp.md](IHistoryRomRegistry-jp.md)

# IHistoryRomRegistry

## Responsibility
Registers and resolves immutable History ROM snapshots.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `RegisterAsync(HistoryRomSnapshot snapshot, CancellationToken cancellationToken = default)` | `Task<HistoryRomMetadata>` | Registers a History ROM snapshot and returns metadata. |
| `Contains(string romId)` | `bool` | Checks whether a History ROM id is registered. |
| `ResolveAsync(string romId, CancellationToken cancellationToken = default)` | `Task<HistoryRomSnapshot>` | Resolves a registered History ROM snapshot. |

## Boundary Rules
- Registry entries are immutable once accepted.
- Hash identity must be preserved across resolve calls.
