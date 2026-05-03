---
id: iprovidercostprofile
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCostProfile"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - cost
  - english
---

For Japanese version, see `IProviderCostProfile-jp.md`.

# IProviderCostProfile

## Responsibility
Describe normalized cost characteristics per provider and model tier for routing-time economic optimization.

## Properties
| Property | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Provider identifier. |
| `ModelClass` | `string` | Capability class (logic-heavy, balanced, fast). |
| `InputTokenUnitCost` | `decimal` | Cost per input token unit. |
| `OutputTokenUnitCost` | `decimal` | Cost per output token unit. |
| `ComputeMinuteCost` | `decimal` | Cost per compute minute. |
| `StorageUnitCost` | `decimal` | Cost per persisted snapshot unit. |
| `EffectiveFromUtc` | `DateTimeOffset` | Cost profile start time. |

## Use Cases
- UC-23 Provider Credit Management
- UC-03 Model Vector Routing

## Integration with `IModelVectorRouter`
Router computes a total estimated cost per candidate route and combines it with capability and latency scores.

## Pie-Chart UI Data
- input-cost share: `InputTokenUnitCost`
- output-cost share: `OutputTokenUnitCost`
- compute-cost share: `ComputeMinuteCost`
- storage-cost share: `StorageUnitCost`
- labels: `ProviderId`, `ModelClass`, `EffectiveFromUtc`




