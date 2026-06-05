---
title: "DynamicSLM Interface Contracts"
created: 2026-06-05
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - interfaces
  - dynamicslm
  - english
---

Japanese version: [Index](index-jp.md)

# DynamicSLM Interface Contracts

DynamicSLM contracts define the interface-led boundary for capability-modular SLM artifacts.
They are based on the Model ABI described by the DynamicSLM paper: Semantic Profile, Capability Graph, Execution Profile, Lineage, and Payload.

## Contract Surface

| Contract | Responsibility |
|---|---|
| `IDynamicSlmModelAbiProvider` | Read a Model ABI descriptor by model id. |
| `IDynamicSlmModuleRegistry` | Register, resolve, and enumerate admitted DynamicSLM model artifacts. |
| `IDynamicSlmPipelineContextFactory` | Create the initial immutable pipeline context for monadic load flows. |
| `IDynamicSlmPipelineStep<TInput,TOutput>` | Describe a synchronous typed pipeline step boundary. |
| `IDynamicSlmAsyncPipelineStep<TInput,TOutput>` | Describe an asynchronous typed pipeline step boundary for GPU/NPU work. |
| `IDynamicSlmAsyncPipeline` | Execute a composed DynamicSLM pipeline over a `DynamicSlmPipelineContext`. |
| `IDynamicSlmPipelineBuilder` | Compose async pipeline steps without exposing Common/Core implementation types. |
| `IDynamicSlmCapabilityGraphResolver` | Resolve the minimum capability subgraph required for a task. |
| `IDynamicSlmCompatibilityVerifier` | Verify semantic profile and governance compatibility before payload loading. |
| `IDynamicSlmLineageVerifier` | Verify lineage, artifact hashes, and admission metadata before payload use. |
| `IDynamicSlmPayloadLoader` | Materialize and unload payload descriptors without exposing runtime implementation types. |
| `IDynamicSlmScheduler` | Produce accelerator placement and prefetch plans from execution profiles. |
| `IDynamicSlmCapabilityGapDetector` | Detect capability gaps from verified ReplayLog traces. |
| `IDynamicSlmCapabilityGraphEvolutionPlanner` | Propose governed Capability Graph updates from recurring verified gaps. |
| `IDynamicSlmDistillationPlanner` | Create differential distillation plans for targeted capability modules. |
| `IDynamicSlmArtifactPublisher` | Publish validated distilled artifacts through the registry boundary. |

## DTO Ownership

DynamicSLM data records are owned by `AIKernel.Dtos.DynamicSlm`.
Shared enum primitives are owned by `AIKernel.Enums`.
Runtime implementations, verification logic, payload handles, and result pipelines belong to Core or Provider packages, not to `AIKernel.Abstractions`.

## Pipeline / LINQ Composition Boundary

`AIKernel.NET` does not expose `AIKernel.Common.Result<T>`, `Option<T>`, or `Either<L,R>`.
The DynamicSLM pipeline DTOs provide a package-boundary shape that Core can adapt into its Result monad.
`DynamicSlmPipelineResult<T>` carries success/failure, trace, and metadata without implementing monadic behavior in the contract package.

Pseudo-code for a Core implementation:

```csharp
var result =
    from compatibility in VerifyCompatibility(context)
    from lineage in VerifyLineage(compatibility)
    from graph in ResolveCapabilityGraph(lineage)
    from gaps in DetectCapabilityGaps(graph)
    from evolution in PlanGraphEvolution(gaps)
    from distillation in PlanDistillation(evolution)
    from placement in PlanPlacement(distillation)
    from admission in Admit(placement)
    from payloads in LoadPayloads(admission)
    select payloads;
```

---

# Changelog
- v0.0.5 (2026-06-05): Added DynamicSLM Model ABI contract index.
