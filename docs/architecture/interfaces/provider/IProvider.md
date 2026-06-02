---
id: iprovider
title: "IProvider"
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
  - english
---

Japanese version: [IProvider (インターフェース仕様)](architecture/interfaces/provider/IProvider-jp.md)

# IProvider (Interface Specification)

## 1. Responsibility Boundary
`IProvider` is the abstraction boundary that normalizes concrete AI service differences and exposes a consistent compute-resource interface to the kernel.

- Role:
  Define shared lifecycle operations for identity, capabilities, availability, initialization/shutdown, and health diagnostics.
- Non-role:
  Routing decisions belong to `IModelVectorRouter`; higher-level reasoning orchestration is outside provider scope.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

public interface IProvider
{
    string ProviderId { get; }
    string Name { get; }
    string Version { get; }
    IProviderCapabilities GetCapabilities();
    Task<bool> IsAvailableAsync();
    Task InitializeAsync();
    Task ShutdownAsync();
    Task<ProviderHealthStatus> GetHealthAsync();
}
```

## 3. Related Use Cases
- `UC-03` Model vector routing:
  `GetCapabilities()` supplies prerequisite data for candidate selection.
- `UC-22` Dynamic capacity control and routing:
  `GetHealthAsync()` and `IsAvailableAsync()` feed dynamic weighting and exclusion decisions.
- `UC-23` Multi-provider failover:
  Supports safe fallback when provider availability changes.

## 4. Governance & Determinism
- Fail-Closed:
  If `IsAvailableAsync()` fails or `InitializeAsync()` cannot complete, exclude the provider from execution routes.
- State transparency:
  `GetCapabilities()` and `GetHealthAsync()` should reflect operational reality to preserve audit explainability.

## 5. Implementation Notes
- Resilience:
  Retries/circuit breakers are acceptable, but resulting state must remain observable via `GetHealthAsync()`.
- Secret handling:
  Keep credentials internal to implementations and never leak provider-specific secrets through contracts.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
