---
id: iproviderbillinginfo
title: "IProviderBillingInfo"
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
  - billing
  - english
---

For Japanese version, see [IProviderBillingInfo-jp.md](./IProviderBillingInfo-jp.md).

# IProviderBillingInfo (Interface Specification)

## 1. Responsibility Boundary
`IProviderBillingInfo` provides billing-state metadata required for economic governance, budget protection, and chargeback accountability.

- Role:
  Expose billing-cycle windows, accumulated cost, forecast cost, and payment status for governance decisions.
- Non-role:
  Payment execution and settlement collection workflows are out of scope.

## 2. Properties
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

## 3. Use Cases
- `UC-23` AI credit management:
  Drive routing throttles or low-cost fallback paths based on budget pressure.
- `UC-18` Chat persistence and chargeback:
  Support context-level cost attribution for internal accounting.

## 4. Integration with `IModelVectorRouter`
- Hard limit:
  Exclude providers in `overdue` to reduce execution-failure risk.
- Soft limit:
  Under equal capability, prefer providers with lower `ForecastCost` and higher budget headroom.

## 5. Visualization (Pie Chart) Mapping
- Active share:
  `AccumulatedCost`
- Forecast increment:
  `ForecastCost - AccumulatedCost`
- Risk share:
  Cost associated with `due` / `overdue` statuses
- Labels:
  `ProviderId`, `BillingCycle`, `CycleEndUtc`

## 6. Governance Constraints
- Fail-Closed:
  If billing data cannot be retrieved, prefer safe-side throttling of high-cost execution paths.
- Replay integrity:
  Preserve historical billing state in snapshot metadata to keep audit replay explainable.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
