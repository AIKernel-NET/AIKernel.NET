---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IModelVectorRouter'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
updated: 2026-05-06
---

For Japanese version, see IModelVectorRouter-jp.md.

# IModelVectorRouter (Interface Specification)

## 1. Responsibility Boundary
`IModelVectorRouter` is the routing boundary interface that selects an optimal model/provider based on required capability vectors and execution constraints.

- Role:
  Perform multi-dimensional capability matching, apply rule/constraint-based filtering, and produce deterministic final routing decisions.
- Non-role:
  Actual inference execution belongs to the selected implementation. Capability registration and lifecycle management belong to `ICapabilityRegistry`.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Routing;

using AIKernel.Abstractions.Models;

public interface IModelVectorRouter
{
    Task<ModelRoutingDecision> RouteAsync(
        ModelCapacityVector requiredCapacity,
        RuleEvaluationContext ruleEvaluationContext,
        IExecutionConstraints executionConstraints,
        CancellationToken cancellationToken = default);

    ModelType SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates);

    IEnumerable<(ModelType Model, float Score)> RankModels(
        ModelCapacityVector requirement,
        IEnumerable<ModelType> candidates);

    bool VerifyDeterministicRouting(ModelRoutingDecision decision1, ModelRoutingDecision decision2);
}
```

## 3. Related Use Cases
- `UC-03` Model vector routing:
  Core path for selecting execution units from requirement vectors.
- `UC-22` Dynamic capacity control and model routing:
  Optimizes routing under changing budget, load, and capability conditions.
- `UC-30` Token/vector estimation:
  Evaluates executability against estimated task vectors.

## 4. Governance & Determinism
- Deterministic routing:
  Identical capability requirements, rule context, and execution constraints must yield identical `ModelRoutingDecision` outputs.
- Fail-Closed:
  If no candidate satisfies mandatory capabilities, the implementation must terminate as deny/failure rather than silently degrading to a weaker route.

## 5. Exception Contract
This interface does not hard-code specific exception types. Implementations should explicitly handle:

- No viable route:
  No candidates exist, or all candidates are excluded by constraints.
- Constraint violations:
  `IExecutionConstraints` (budget, region, latency, etc.) makes execution impossible.

## 6. Implementation Notes
- Multi-axis evaluation:
  Evaluate multiple `ModelCapacityVector` axes in an explainable way instead of collapsing everything into a single opaque metric.
- Auditability:
  Keep routing rationale (scores, exclusion reasons, tie-break basis) traceable in `ModelRoutingDecision`.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
