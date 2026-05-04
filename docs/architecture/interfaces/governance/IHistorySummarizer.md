---
id: ihistorysummarizer
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IHistorySummarizer"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IHistorySummarizer

## Responsibility
Define the contract boundary for IHistorySummarizer within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `SummarizeAsync(IEnumerable<string> history, CancellationToken ct = default)` | `Task<string>` | Summarize long history into compact context. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
