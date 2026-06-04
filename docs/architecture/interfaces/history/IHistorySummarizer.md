---
id: ihistorysummarizer
title: "IHistorySummarizer"
created: 2026-05-03
updated: 2026-06-04
published: 2026-05-16
version: "0.0.4"
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

Japanese version: [IHistorySummarizer-jp.md](IHistorySummarizer-jp.md)

# IHistorySummarizer

## Responsibility
Defines the boundary for projecting chat or execution history into reusable material and context. It belongs to `AIKernel.Abstractions.History`; governance code may consume the result, but the interface itself is not a governance contract.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `SummarizeAsMaterialAsync(IEnumerable<ContextFragment> history, CancellationToken ct = default)` | `Task<IEnumerable<IStructuredMaterial>>` | Summarize history fragments into normalized material. |
| `ProjectAsContextAsync(IEnumerable<ContextFragment> history, HistoryPolicy policy, CancellationToken ct = default)` | `Task<IContextCollection>` | Project history fragments into a governed context collection. |

## Related Use Cases
- UC-32 history summarization and projection.
- History ROM publication flows.

## Notes
- Implementations must not mutate source conversation storage.
- Deterministic projection policies should be supplied explicitly through `HistoryPolicy`.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.4 (2026-06-04): Moved from governance docs to history docs and aligned signatures with source.
