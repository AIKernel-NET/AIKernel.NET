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
| `IDynamicSlmFailure` | Project implementation-specific failures into the shared fail-closed vocabulary. |
| `IDynamicSlmCapabilityGraphResolver` | Resolve the minimum capability subgraph required for a task. |
| `IDynamicSlmCompatibilityVerifier` | Verify semantic profile and governance compatibility before payload loading. |
| `IDynamicSlmLineageVerifier` | Verify lineage, artifact hashes, and admission metadata before payload use. |
| `IDynamicSlmPayloadLoader` | Materialize and unload payload descriptors without exposing runtime implementation types. |
| `IDynamicSlmScheduler` | Produce accelerator placement and prefetch plans from execution profiles. |
| `IDynamicSlmCapabilityGapDetector` | Detect capability gaps from verified ReplayLog traces. |
| `IDynamicSlmCapabilityGraphEvolutionPlanner` | Propose governed Capability Graph updates from recurring verified gaps. |
| `IDynamicSlmDistillationPlanner` | Create differential distillation plans only; it must not execute heavy distillation inline. |
| `IDynamicSlmDistillationJobScheduler` | Schedule offloaded distillation jobs and read job status through a host/Core boundary. |
| `IDynamicSlmBackgroundDistillationService` | Represent the background service boundary that accepts distillation offload requests. |
| `IDynamicSlmArtifactPublisher` | Publish validated distilled artifacts through the registry boundary. |
| `ISeedSlmDisciplineVerifier` | Verify SeedSLM structural adherence, contract fidelity, fail-closed behavior, and zero-slop output policy. |
| `IDynamicSlmDelegationPlanner` | Convert capability gaps into fail-closed delegation requests for Teacher, Solver, or Remote targets. |
| `IDynamicSlmThoughtArtifactSink` | Persist SeedSLM thought artifacts as ReplayLog-compatible entries before final output. |
| `IDynamicSlmMemoryPlacementPlanner` | Plan resident SeedSLM placement and paged CapabilitySLM swaps without exposing runtime handles. |

## DTO Ownership

DynamicSLM data records are owned by `AIKernel.Dtos.DynamicSlm`.
Shared enum primitives are owned by `AIKernel.Enums`.
Runtime implementations, verification logic, payload handles, and result pipelines belong to Core or Provider packages, not to `AIKernel.Abstractions`.

## Pipeline / LINQ Composition Boundary

`AIKernel.NET` does not expose `AIKernel.Common.Result<T>`, `Option<T>`, or `Either<L,R>`.
The DynamicSLM pipeline DTOs provide a package-boundary shape that Core can adapt into its Result monad.
`DynamicSlmPipelineResult<T>` carries success/failure, trace, and metadata without implementing monadic behavior in the contract package.
Differential distillation is offloaded: the load pipeline records a plan and job descriptor, falls back to a Teacher/remote/cached strategy when needed, and continues without waiting for training work.
`DynamicSlmDistillationRequest` and `DynamicSlmDistillationPlan` carry metadata for job descriptors, teacher fallback, ReplayLog references, and validation policy hints; they do not represent inline training execution.
`DynamicSlmPipelineStage` includes dedicated `DistillationOffload` and `FallbackSelection` stages so Core implementations can record deterministic trace entries for offload and fallback decisions.

## SeedSLM Contract Additions

SeedSLM is modeled as a neutral, resident base model that learns discipline rather than domain knowledge.
The contract additions express four requirements:

- Structural adherence and contract fidelity through `SeedSlmStructuralConstraints`.
- Zero-slop strict output through `SeedSlmOutputDisciplinePolicy` and `DynamicSlmStrictOutputMode`.
- Immediate fail-closed delegation through `DynamicSlmDelegationRequest`, `DynamicSlmDelegationKind`, and `DynamicSlmDelegationReason`.
- ReplayLog-compatible thought artifacts through `DynamicSlmThoughtArtifact`, `DynamicSlmReplayLogEntry`, and `DynamicSlmTrajectoryMetadata`.

SeedSLM memory assumptions are represented separately from runtime handles.
`DynamicSlmResidentModelDescriptor` describes the VRAM-resident seed base.
`DynamicSlmCapabilitySwapDescriptor` describes CapabilitySLM page-in/page-out material.
`DynamicSlmMemoryPlacementMetadata` ties resident and swap descriptors to placement decisions.
`DynamicSlmHotSwapPolicy` records whether a Core implementation intends prefetch, page-in, page-out, or hot-swap behavior.

`DynamicSlmModelAbi` carries an optional `SeedSlmProfile`, and `DynamicSlmPipelineContext` carries optional delegation, thought-artifact, and memory-placement state. `DynamicSlmPipelineMetadata` mirrors their stable identifiers so Core can project them into ResultStep metadata without putting runtime behavior into the contract packages.

Text flow:

```text
SeedSLM strict output
  -> DynamicSlmThoughtArtifact
  -> DynamicSlmReplayLogEntry
  -> DynamicSlmTrajectoryMetadata
  -> DynamicSlmDistillationRequest
  -> DynamicSlmDistillationPlan
  -> DynamicSlmDistillationOffloadRequest
```

Pseudo-code for a Core implementation:

```csharp
var result =
    from compatibility in VerifyCompatibility(context)
    from lineage in VerifyLineage(compatibility)
    from graph in ResolveCapabilityGraph(lineage)
    from gaps in DetectCapabilityGaps(graph)
    from evolution in PlanGraphEvolution(gaps)
    from distillPlan in PlanDistillation(evolution)
    from offload in OffloadDistillation(distillPlan)
    from fallback in SelectFallbackStrategy(offload)
    from discipline in VerifySeedDiscipline(fallback)
    from delegation in PlanDelegationIfNeeded(discipline)
    from thought in DumpThoughtArtifact(delegation)
    from placement in PlanPlacement(evolution)
    from memory in PlanResidentSeedAndCapabilitySwaps(placement)
    from admission in Admit(placement)
    from payloads in LoadPayloads(admission)
    select payloads;
```

---

# Changelog
- v0.0.5 (2026-06-05): Added DynamicSLM distillation offload contracts and metadata shape.
- v0.0.5 (2026-06-05): Added DynamicSLM Model ABI contract index with distillation offload metadata.
- v0.0.5 (2026-06-05): Added SeedSLM discipline, delegation, thought artifact, and resident memory contract vocabulary.
