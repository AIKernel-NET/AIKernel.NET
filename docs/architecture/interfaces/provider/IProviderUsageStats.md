---
id: iproviderusagestats
title: "IProviderUsageStats"
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
  - usage
  - english
---

For Japanese version, see [IProviderUsageStats-jp.md](./IProviderUsageStats-jp.md).

# IProviderUsageStats (Usage Telemetry Interface Specification)

## 1. Responsibility Boundary
`IProviderUsageStats` exposes near-real-time throughput, token consumption, and rate-limit pressure to drive dynamic routing decisions.

- Role:
  Provide short-window usage and performance signals for operational balancing.
- Non-role:
  Long-term archival/audit retention is outside this interface scope.

## 2. Properties
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

## 3. Use Cases
- `UC-19` Parallel multi-model execution:
  Uses latency/pressure signals to rebalance traffic across providers.
- `UC-23` AI credit management:
  Uses token telemetry to monitor live budget burn rate.

## 4. Integration with `IModelVectorRouter`
- Congestion avoidance:
  Down-rank providers when `RateLimitUtilization` rises or `AvgLatencyMs` degrades.
- Allocation efficiency:
  Temporarily avoid high-pressure routes to preserve system-wide availability.

## 5. Visualization Mapping (Dashboard/Pie)
- Request share:
  `RequestsCount`
- Token throughput:
  `InputTokens`, `OutputTokens`
- Rate-limit pressure:
  `RateLimitUtilization`
- Labels:
  `ProviderId`, `WindowStartUtc`, `WindowEndUtc`

## 6. Governance & Determinism
- Observation accuracy:
  Include error paths (e.g., 429s) in pressure/latency interpretation to avoid optimistic bias.
- Replay integrity:
  Persist referenced usage snapshots so congestion context is reconstructable during replay.
- Window consistency:
  Align comparison windows or define interpolation rules before cross-provider scoring.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
