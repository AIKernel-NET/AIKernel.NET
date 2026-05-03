---
id: iproviderbillinginfo
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderBillingInfo"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - billing
  - english
---

For Japanese version, see `IProviderBillingInfo-jp.md`.

# IProviderBillingInfo

## Responsibility
Provide billing-cycle and invoicing metadata required for compliance, forecasting, and chargeback.

## Properties
| Property | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Provider identifier. |
| `BillingAccountId` | `string` | Account identifier at provider side. |
| `BillingCycle` | `string` | Billing cadence (monthly, prepaid, postpaid). |
| `CycleStartUtc` | `DateTimeOffset` | Current cycle start. |
| `CycleEndUtc` | `DateTimeOffset` | Current cycle end. |
| `AccumulatedCost` | `decimal` | Cost accumulated in cycle. |
| `ForecastCost` | `decimal` | End-of-cycle forecast cost. |
| `PaymentStatus` | `string` | Settlement state (active, due, overdue). |

## Use Cases
- UC-23 Provider Credit Management
- UC-18 Chat Persistence

## Integration with `IModelVectorRouter`
Router can enforce policy boundaries from billing state:
- avoid routing to providers in `overdue`
- prefer providers with lower `ForecastCost` under equal capability

## Pie-Chart UI Data
- paid/active share: `AccumulatedCost` within active status
- forecast share: `ForecastCost - AccumulatedCost`
- risk share: cost mapped to `PaymentStatus=overdue`
- labels: `ProviderId`, `BillingCycle`, `CycleEndUtc`




