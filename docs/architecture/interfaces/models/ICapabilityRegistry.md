---
id: icapabilityregistry
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ICapabilityRegistry"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see ICapabilityRegistry-jp.md.

# ICapabilityRegistry

## Responsibility
Define the contract boundary for ICapabilityRegistry within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `GetCapacity(ModelType modelType)` | `ModelCapacityVector` | Get default capacity vector for a model type. |
| `FindModelsAbove(ModelCapacityVector threshold)` | `IEnumerable<ModelType>` | Find models whose dimensions are above all thresholds. |
| `GetAllRegisteredModels()` | `IEnumerable<ModelType>` | Enumerate all registered models. |
| `RegisterCapacity(ModelType modelType, ModelCapacityVector capacity)` | `void` | Register or update model capacity vector. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where ICapabilityRegistry appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



