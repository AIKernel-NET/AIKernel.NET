---
id: istructuredmaterial
title: "IStructuredMaterial"
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

Japanese version: [IStructuredMaterial](architecture/interfaces/material/IStructuredMaterial-jp.md)

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
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
