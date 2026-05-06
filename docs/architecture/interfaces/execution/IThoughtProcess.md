---
id: ithoughtprocess
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IThoughtProcess"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IThoughtProcess-jp.md.

# IThoughtProcess (Interface Specification)

## 1. Responsibility Boundary
`IThoughtProcess` is the boundary interface that owns the first stage of AIKernel's two-phase execution model: the Structure phase.

- Role:
  Analyze context and build intermediate logical structure (`RawLogic`) including task decomposition, constraint extraction, and solution planning.
- Non-role:
  Final user-facing expression generation belongs to `IOutputPolisher`.
  Implementations should not directly call provider APIs; reasoning must be handled through orchestration-layer abstractions.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Execution;

/// <summary>
/// Builds intermediate reasoning logic from contextual inputs.
/// </summary>
public interface IThoughtProcess
{
    /// <summary>
    /// Minimum model capability vector required by this thought process.
    /// </summary>
    ModelCapacityVector RequiredCapacity { get; }

    /// <summary>
    /// Builds intermediate logic from the orchestration context.
    /// </summary>
    /// <param name="orchestrationContext">Execution context including instruction, material, and history buffers.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Constructed intermediate logic (`RawLogic`).</returns>
    Task<RawLogic> BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default);
}
```

Note:
`LogicConstructionException` is a representative implementation-layer exception name. The current abstraction contract does not hard-code exception type names.

## 3. Related Use Cases
- `UC-02` Structure phase execution:
  Serves as the core for task decomposition and execution-plan construction.
- `UC-29` Task pipeline management:
  Used as an intelligence unit when building DAG-style task pipelines.

## 4. Governance & Determinism
- Maintain reasoning purity:
  `BuildLogicAsync` is expected to derive `RawLogic` from the input context with minimized side effects.
- Fail-Closed:
  If instruction and material contain irreconcilable contradictions, terminate on the deny side instead of generating an uncertain plan.

## 5. Implementation Notes
- Declare capacity explicitly:
  Properly defining `RequiredCapacity` allows `IModelVectorRouter` to select an optimal execution target.
- Respect context isolation:
  Preserve orchestration buffer boundaries (instruction/material/history) to prevent attention pollution.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
