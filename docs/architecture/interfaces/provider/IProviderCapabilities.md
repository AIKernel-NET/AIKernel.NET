---
id: iprovidercapabilities
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCapabilities"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IProviderCapabilities-jp.md.

# IProviderCapabilities

## Responsibility
Define the contract boundary for IProviderCapabilities within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `SupportedOperations` | `IReadOnlyList<string>` | Supported operation set. |
| `SupportedDataTypes` | `IReadOnlyList<string>` | Supported data types. |
| `MaxConcurrentConnections` | `int` | Maximum concurrent execution channels. |
| `RateLimit` | `RateLimitInfo?` | Provider rate-limit metadata. |
| `Vector` | `ModelCapacityVector` | Static capability vector. |
| `GetDynamicCapacities(IExecutionConstraints constraints)` | `IDictionary<string, float>?` | Dynamic capacity map under runtime constraints. |
| `GetCapabilityProfile()` | `ICapabilityProfile?` | Capacity profile curve by cardinality/constraints. |
| `SupportsOperation(string operation)` | `bool` | Check operation support. |
| `SupportsDataType(string dataType)` | `bool` | Check data type support. |
| `SupportsQuantization(string quantizationLevel)` | `bool` | Check quantization support. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IProviderCapabilities appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



