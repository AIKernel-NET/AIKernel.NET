---
id: iprovidercreditinfo
title: "IProviderCreditInfo"
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
  - credit
  - english
---

For Japanese version, see [IProviderCreditInfo-jp.md](./IProviderCreditInfo-jp.md).

# IProviderCreditInfo (Interface Specification)

## 1. Responsibility Boundary
`IProviderCreditInfo` exposes provider-level balance, reservation, and limit data so orchestration can enforce cost-safe execution.

- Role:
  Provide spendable balance, reserved amount, hard/soft ceilings, and refresh timestamp.
- Non-role:
  Purchase/refund settlement workflows are outside this contract.

## 2. Properties
| Property | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Logical provider identifier. |
| `CurrencyCode` | `string` | Billing currency (ISO 4217). |
| `CurrentBalance` | `decimal` | Remaining spendable credit. |
| `ReservedBalance` | `decimal` | Amount reserved by running jobs. |
| `HardLimit` | `decimal` | Absolute spend ceiling. |
| `SoftLimit` | `decimal` | Alert threshold before hard limit. |
| `LastUpdatedUtc` | `DateTimeOffset` | Last refresh timestamp. |

## 3. Use Cases
- `UC-23` AI credit management:
  Trigger warnings, low-cost route shifts, or execution gating when balance is tight.
- `UC-19` Parallel multi-model execution:
  Use `ReservedBalance` to prevent double-spend under concurrency.

## 4. Integration with `IModelVectorRouter`
- Liveness check:
  Exclude candidates when estimated cost exceeds `CurrentBalance - ReservedBalance`.
- Soft throttling:
  Penalize candidates approaching `SoftLimit` and prefer healthier balances.
- Hard cutoff:
  Isolate candidates at `HardLimit` or depleted balance and force fallback routes.

## 5. Visualization Mapping (Pie Chart)
- Available share:
  `CurrentBalance - ReservedBalance`
- Reserved share:
  `ReservedBalance`
- Consumed share:
  `HardLimit - CurrentBalance`
- Labels:
  `ProviderId`, `CurrencyCode`, `LastUpdatedUtc`

## 6. Governance & Determinism
- Freshness guard:
  If `LastUpdatedUtc` is stale, apply safe-side restrictions to avoid uncertain spending decisions.
- Replay integrity:
  Snapshot runtime credit state for explainable deterministic replay audits.
- Reservation hygiene:
  Settle/release `ReservedBalance` promptly after completion to avoid resource deadlocks.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
