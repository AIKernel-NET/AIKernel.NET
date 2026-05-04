---
id: imodelvectorrouter
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IModelVectorRouter"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IModelVectorRouter-jp.md.

# IModelVectorRouter

## Responsibility
Define the contract boundary for IModelVectorRouter within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates)` | `ModelType` | Select nearest or minimal satisfying model for requirement vector. |
| `RankModels(ModelCapacityVector requirement, IEnumerable<ModelType> candidates)` | `IEnumerable<(ModelType Model, float Score)>` | Return score-ranked candidate models. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IModelVectorRouter appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



