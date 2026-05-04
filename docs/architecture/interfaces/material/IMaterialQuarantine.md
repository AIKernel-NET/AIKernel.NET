---
id: imaterialquarantine
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IMaterialQuarantine"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IMaterialQuarantine-jp.md.

# IMaterialQuarantine

## Responsibility
Define the contract boundary for IMaterialQuarantine within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default)` | `Task<IStructuredMaterial>` | Validate and normalize raw fragment or fail with quarantine exception. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IMaterialQuarantine appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



