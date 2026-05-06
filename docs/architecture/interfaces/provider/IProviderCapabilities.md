---
id: iprovidercapabilities
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCapabilities"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IProviderCapabilities-jp.md](./IProviderCapabilities-jp.md).

# IProviderCapabilities (Interface Specification)

## 1. Responsibility Boundary
`IProviderCapabilities` is the capability specification sheet used by routing/governance to evaluate what a provider can do and under which constraints.

- Role:
  Expose supported operations/data types, concurrency ceilings, rate limits, static capacity vector, and dynamic capacity views.
- Non-role:
  It does not execute inference; it declares capability metadata only.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

using AIKernel.Abstractions.Models;

public interface IProviderCapabilities
{
    IReadOnlyList<string> SupportedOperations { get; }
    IReadOnlyList<string> SupportedDataTypes { get; }
    int MaxConcurrentConnections { get; }
    RateLimitInfo? RateLimit { get; }
    ModelCapacityVector Vector { get; }
    IDictionary<string, float>? GetDynamicCapacities(IExecutionConstraints constraints);
    ICapabilityProfile? GetCapabilityProfile();
    bool SupportsOperation(string operation);
    bool SupportsDataType(string dataType);
    bool SupportsQuantization(string quantizationLevel);
}
```

## 3. Related Use Cases
- `UC-03` Model vector routing:
  Uses `Vector` and dynamic capacities for candidate matching.
- `UC-22` Dynamic capacity control:
  Uses `RateLimit` and runtime capacities for throttling and route weighting.

## 4. Governance & Determinism
- Capability accuracy:
  If declared operations are not actually executable, mark provider unhealthy and fail closed.
- Replay integrity:
  Snapshot dynamic capacity values at execution time for deterministic audit/replay reasoning.
- Backend transparency:
  Return comparable metrics regardless of cloud API vs local runtime backend.

## 5. Implementation Notes
- Vector dimension discipline:
  Keep `ModelCapacityVector` dimensions consistent for fair comparison.
- Cache strategy:
  If dynamic probes are cached, enforce explicit TTL to balance freshness and stability.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
