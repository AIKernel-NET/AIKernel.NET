---
id: icontextcollection
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IContextCollection"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IContextCollection-jp.md.

# IContextCollection

## Responsibility
Define the contract boundary for IContextCollection within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `GetAll()` | `IEnumerable<ContextFragment>` | Return all fragments across categories. |
| `GetByCategory(ContextCategory category)` | `IEnumerable<ContextFragment>` | Return fragments in a single category. |
| `GetOrchestrationBuffer()` | `OrchestrationBuffer` | Return orchestration-phase read buffer. |
| `GetExpressionBuffer()` | `ExpressionBuffer` | Return expression-phase read buffer. |
| `GetMaterialBuffer()` | `MaterialBuffer` | Return material-phase read buffer. |
| `GetHistoryBuffer()` | `HistoryBuffer` | Return history-phase read buffer. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IContextCollection appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



