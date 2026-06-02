---
id: iprovidercostprofile
title: "IProviderCostProfile"
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
  - provider
  - cost
  - english
---

For Japanese version, see [IProviderCostProfile-jp.md](./IProviderCostProfile-jp.md).

# IProviderCostProfile (Interface Specification)

## 1. Responsibility Boundary
`IProviderCostProfile` defines normalized pricing catalogs per provider and model tier, supplying static economic evidence for routing decisions.

- Role:
  Provide unit costs for input/output tokens, compute time, storage, and pricing effective timestamp.
- Non-role:
  Accumulated spending state is owned by `IProviderBillingInfo`.

## 2. Properties
| Property | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Provider identifier. |
| `ModelClass` | `string` | Capability class (logic-heavy, balanced, fast). |
| `InputTokenUnitCost` | `decimal` | Cost per input token unit. |
| `OutputTokenUnitCost` | `decimal` | Cost per output token unit. |
| `ComputeMinuteCost` | `decimal` | Cost per compute minute. |
| `StorageUnitCost` | `decimal` | Cost per persisted snapshot unit. |
| `EffectiveFromUtc` | `DateTimeOffset` | Cost profile start time. |

## 3. Use Cases
- `UC-23` AI credit management:
  Compare estimated cost against budget headroom to gate execution.
- `UC-03` Model vector routing:
  Blend cost with capability and latency scores during path selection.

## 4. Integration with `IModelVectorRouter`
1. Total-cost estimation:
   Predict per-route cost from expected token usage and unit pricing.
2. Multi-objective optimization:
   Combine capability, latency, and cost signals to choose the final route.

## 5. Visualization Mapping (UI)
- Input-cost share:
  `InputTokenUnitCost`
- Output-cost share:
  `OutputTokenUnitCost`
- Compute/storage share:
  `ComputeMinuteCost`, `StorageUnitCost`
- Labels:
  `ProviderId`, `ModelClass`, `EffectiveFromUtc`

## 6. Governance Constraints
- Immutability:
  Profiles tied to a specific `EffectiveFromUtc` should not be retroactively altered for audit integrity.
- Fail-Closed:
  If no valid cost profile is available, block routing to prevent unbounded billing risk.
- Replay integrity:
  Persist applied `EffectiveFromUtc` so economic conditions can be reconstructed during replay.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
