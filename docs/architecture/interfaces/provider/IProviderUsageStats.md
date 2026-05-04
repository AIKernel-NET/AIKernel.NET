---
id: iproviderusagestats
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderUsageStats"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - usage
  - english
---

For Japanese version, see `IProviderUsageStats-jp.md`.

# IProviderUsageStats

## Responsibility
Expose near-real-time usage telemetry for throughput, token volume, and rate-limit pressure.

## Properties
| Property | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Provider identifier. |
| `WindowStartUtc` | `DateTimeOffset` | Usage aggregation window start. |
| `WindowEndUtc` | `DateTimeOffset` | Usage aggregation window end. |
| `RequestsCount` | `long` | Total requests in window. |
| `InputTokens` | `long` | Total input tokens in window. |
| `OutputTokens` | `long` | Total output tokens in window. |
| `AvgLatencyMs` | `double` | Average request latency. |
| `RateLimitUtilization` | `double` | Ratio between current usage and limit (0.0 to 1.0+). |

## Use Cases
- UC-19 Parallel Multi-Model Execution
- UC-23 Provider Credit Management

## Integration with `IModelVectorRouter`
Router can down-rank saturated providers based on `RateLimitUtilization` and `AvgLatencyMs` to avoid queue amplification.

## Pie-Chart UI Data
- request share: `RequestsCount`
- input-token share: `InputTokens`
- output-token share: `OutputTokens`
- rate-limit slice: `RateLimitUtilization`
- labels: `ProviderId`, `WindowStartUtc`, `WindowEndUtc`




