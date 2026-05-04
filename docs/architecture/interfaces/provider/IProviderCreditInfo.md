---
id: iprovidercreditinfo
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCreditInfo"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - credit
  - english
---

For Japanese version, see `IProviderCreditInfo-jp.md`.

# IProviderCreditInfo

## Responsibility
Expose current credit and budget boundaries for a provider so orchestration can enforce cost-aware execution.

## Properties
| Property | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Logical provider identifier. |
| `CurrencyCode` | `string` | Billing currency (ISO 4217). |
| `CurrentBalance` | `decimal` | Remaining spendable credit. |
| `ReservedBalance` | `decimal` | Amount reserved by running jobs. |
| `HardLimit` | `decimal` | Absolute spend ceiling. |
| `SoftLimit` | `decimal` | Alert threshold before hard limit. |
| `LastUpdatedUtc` | `DateTimeOffset` | Last refresh timestamp. |

## Use Cases
- UC-23 Provider Credit Management
- UC-19 Parallel Multi-Model Execution

## Integration with `IModelVectorRouter`
Router scoring can apply credit gating:
- deny providers below minimum balance
- penalize providers near soft limit
- force fallback routing when hard limit is reached

## Pie-Chart UI Data
- available slice: `CurrentBalance - ReservedBalance`
- reserved slice: `ReservedBalance`
- consumed slice: `HardLimit - CurrentBalance`
- labels: `ProviderId`, `CurrencyCode`, `LastUpdatedUtc`




