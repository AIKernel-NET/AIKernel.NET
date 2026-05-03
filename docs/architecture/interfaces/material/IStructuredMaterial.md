---
id: istructuredmaterial
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IStructuredMaterial"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IStructuredMaterial-jp.md.

# IStructuredMaterial

## Responsibility
Define the contract boundary for IStructuredMaterial within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `RawContent` | `string` | Original source content before normalization. |
| `NormalizedContent` | `string` | Sanitized and normalized content for inference. |
| `Weight` | `double` | Importance/trust weight between 0.0 and 1.0. |
| `SourceInfo` | `SourceInfo` | Source provenance metadata. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IStructuredMaterial appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



