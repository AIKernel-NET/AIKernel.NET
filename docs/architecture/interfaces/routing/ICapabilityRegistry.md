---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'ICapabilityRegistry'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
updated: 2026-05-06
---

For Japanese version, see ICapabilityRegistry-jp.md.

# ICapabilityRegistry (Interface Specification)

## 1. Responsibility Boundary
`ICapabilityRegistry` is the boundary interface that manages the inventory of available model/provider capabilities and supplies routing facts for decision-making.

- Role:
  Register, retrieve, and resolve candidates based on `ModelCapacityVector` data.
- Non-role:
  Final optimization/scoring and route selection are owned by `IModelVectorRouter`.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Routing;

public interface ICapabilityRegistry
{
    ValueTask RegisterCapabilityAsync(
        string providerId,
        ModelCapacityVector capacityVector,
        CancellationToken cancellationToken = default);

    ValueTask<ModelCapacityVector?> GetCapabilityAsync(
        string providerId,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<string>> ResolveCandidatesAsync(
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-03` Model vector routing:
  Provides the candidate universe consumed by the router.
- `UC-22` Dynamic capacity control and model routing:
  Supports candidate resolution under runtime changes and constraints.

## 4. Governance & Determinism
- Deterministic candidate resolution:
  For identical registry state and `RuleEvaluationContext`, `ResolveCandidatesAsync` must return the same candidates in the same order.
- Data integrity protection:
  `RegisterCapabilityAsync` should be restricted to trusted administration paths; unauthorized mutations must be rejected by design.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should explicitly handle:

- Unknown provider lookup:
  Failed retrieval for non-existent `providerId`.
- Registry conflicts:
  Conflicting capability registration for the same provider ID.

## 6. Implementation Notes
- Fast lookup:
  Use low-latency indexing/caching structures for frequent reads.
- Policy-aware filtering:
  `ResolveCandidatesAsync` should apply governance filters from `RuleEvaluationContext`, not only liveness checks.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
