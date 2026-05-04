---
id: ioutputpolisher
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IOutputPolisher"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IOutputPolisher-jp.md.

# IOutputPolisher

## Responsibility
Define the contract boundary for IOutputPolisher within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `RequiredCapacity` | `ModelCapacityVector` | Required capacity vector for output polishing. |
| `RenderAsync(RawLogic logic, ExpressionContext expressionContext, CancellationToken ct = default)` | `Task<string>` | Render final output from intermediate logic and expression context. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IOutputPolisher appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



