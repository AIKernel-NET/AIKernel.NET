---
id: ithoughtprocess
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IThoughtProcess"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IThoughtProcess-jp.md.

# IThoughtProcess

## Responsibility
Define the contract boundary for IThoughtProcess within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `RequiredCapacity` | `ModelCapacityVector` | Required capacity vector for this thought process. |
| `BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default)` | `Task<RawLogic>` | Build intermediate reasoning logic from orchestration context. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IThoughtProcess appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



