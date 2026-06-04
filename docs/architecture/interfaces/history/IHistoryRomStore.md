---
title: "IHistoryRomStore"
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

Japanese version: [IHistoryRomStore-jp.md](IHistoryRomStore-jp.md)

# IHistoryRomStore

## Responsibility
Persists and loads History ROM artifacts through caller-provided Vfs sessions.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `SaveHistoryAsRomAsync(...)` | `Task<HistoryRomMetadata>` | Converts records to History ROM and saves them through Vfs. |
| `SaveMarkdownAsRomAsync(...)` | `Task<HistoryRomMetadata>` | Saves already generated History ROM Markdown. |
| `LoadHistoryRomAsync(...)` | `Task<HistoryRomMetadata>` | Loads and optionally verifies a History ROM hash. |

## Boundary Rules
- The caller owns Vfs session lifetime and write/read permissions.
- Hash mismatch must fail closed in implementations.
