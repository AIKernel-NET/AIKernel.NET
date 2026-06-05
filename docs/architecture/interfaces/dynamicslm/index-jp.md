---
title: "DynamicSLM Interface Contracts"
created: 2026-06-05
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - interfaces
  - dynamicslm
  - japanese
---

English version: [Index](index.md)

# DynamicSLM Interface Contracts

DynamicSLM contract は、capability-modular SLM artifact を扱うための Interface-Led な境界を定義します。
DynamicSLM 論文で示された Model ABI、すなわち Semantic Profile、Capability Graph、Execution Profile、Lineage、Payload を前提にします。

## Contract Surface

| Contract | 責務 |
|---|---|
| `IDynamicSlmModelAbiProvider` | model id から Model ABI descriptor を読み取る。 |
| `IDynamicSlmModuleRegistry` | admission 済み DynamicSLM model artifact の登録、解決、列挙。 |
| `IDynamicSlmPipelineContextFactory` | モナド的 load flow の初期 immutable pipeline context を作る。 |
| `IDynamicSlmPipelineStep<TInput,TOutput>` | 同期 typed pipeline step 境界を表現する。 |
| `IDynamicSlmAsyncPipelineStep<TInput,TOutput>` | GPU/NPU 作業向けの非同期 typed pipeline step 境界を表現する。 |
| `IDynamicSlmAsyncPipeline` | `DynamicSlmPipelineContext` 上で合成済み DynamicSLM pipeline を実行する。 |
| `IDynamicSlmPipelineBuilder` | Common/Core 実装型を公開せず async pipeline step を合成する。 |
| `IDynamicSlmFailure` | 実装固有の失敗を共有 fail-closed 語彙へ投影する。 |
| `IDynamicSlmCapabilityGraphResolver` | task に必要な最小 capability subgraph を解決する。 |
| `IDynamicSlmCompatibilityVerifier` | payload loading 前に semantic profile と governance compatibility を検証する。 |
| `IDynamicSlmLineageVerifier` | payload 利用前に lineage、artifact hash、admission metadata を検証する。 |
| `IDynamicSlmPayloadLoader` | runtime implementation type を公開せず payload descriptor を materialize / unload する。 |
| `IDynamicSlmScheduler` | execution profile から accelerator placement と prefetch plan を作る。 |
| `IDynamicSlmCapabilityGapDetector` | 検証済み ReplayLog trace から capability gap を検出する。 |
| `IDynamicSlmCapabilityGraphEvolutionPlanner` | 繰り返し検証された gap から、governed Capability Graph update を提案する。 |
| `IDynamicSlmDistillationPlanner` | differential distillation plan だけを作る。重い蒸留処理は inline 実行しない。 |
| `IDynamicSlmDistillationJobScheduler` | offload された distillation job をスケジュールし、host/Core 境界から status を読む。 |
| `IDynamicSlmBackgroundDistillationService` | distillation offload request を受け取る background service 境界を表現する。 |
| `IDynamicSlmArtifactPublisher` | 検証済み distilled artifact を registry 境界から公開する。 |
| `ISeedSlmDisciplineVerifier` | SeedSLM の structural adherence、contract fidelity、fail-closed behavior、zero-slop output policy を検証する。 |
| `IDynamicSlmDelegationPlanner` | capability gap を Teacher / Solver / Remote target への fail-closed delegation request に変換する。 |
| `IDynamicSlmThoughtArtifactSink` | final output 前に SeedSLM thought artifact を ReplayLog-compatible entry として保存する。 |
| `IDynamicSlmMemoryPlacementPlanner` | runtime handle を公開せず、resident SeedSLM placement と paged CapabilitySLM swap を計画する。 |

## DTO Ownership

DynamicSLM data record は `AIKernel.Dtos.DynamicSlm` が所有します。
共有 enum primitive は `AIKernel.Enums` が所有します。
runtime implementation、検証ロジック、payload handle、result pipeline は `AIKernel.Abstractions` ではなく Core または Provider package が所有します。

## Pipeline / LINQ Composition Boundary

`AIKernel.NET` は `AIKernel.Common.Result<T>`、`Option<T>`、`Either<L,R>` を公開しません。
DynamicSLM pipeline DTO は、Core が内部 Result monad へ adapter できる package-boundary shape を提供します。
`DynamicSlmPipelineResult<T>` は contract package 内で monadic behavior を実装せず、success/failure、trace、metadata だけを運びます。
differential distillation は offload されます。load pipeline は plan と job descriptor を記録し、必要なら Teacher / remote / cached fallback に即時切り替え、training work の完了を待たずに継続します。
`DynamicSlmDistillationRequest` と `DynamicSlmDistillationPlan` は job descriptor、teacher fallback、ReplayLog 参照、validation policy hint のための metadata を運びます。inline training execution は表現しません。
`DynamicSlmPipelineStage` には `DistillationOffload` と `FallbackSelection` の専用 stage があり、Core 実装は offload / fallback 判断を決定論的 trace entry として記録できます。

## SeedSLM Contract Additions

SeedSLM は domain knowledge ではなく discipline を学習する neutral resident base model として扱います。
追加 contract は次の 4 つの要件を表現します。

- `SeedSlmStructuralConstraints` による structural adherence と contract fidelity。
- `SeedSlmOutputDisciplinePolicy` と `DynamicSlmStrictOutputMode` による zero-slop strict output。
- `DynamicSlmDelegationRequest`、`DynamicSlmDelegationKind`、`DynamicSlmDelegationReason` による即時 fail-closed delegation。
- `DynamicSlmThoughtArtifact`、`DynamicSlmReplayLogEntry`、`DynamicSlmTrajectoryMetadata` による ReplayLog-compatible thought artifact。

SeedSLM の memory 前提は runtime handle とは分離して表現します。
`DynamicSlmResidentModelDescriptor` は VRAM resident な seed base を記述します。
`DynamicSlmCapabilitySwapDescriptor` は CapabilitySLM の page-in / page-out material を記述します。
`DynamicSlmMemoryPlacementMetadata` は resident descriptor と swap descriptor を placement decision に結びます。
`DynamicSlmHotSwapPolicy` は Core 実装が prefetch、page-in、page-out、hot-swap のどれを意図したかを記録します。

`DynamicSlmModelAbi` は optional な `SeedSlmProfile` を運び、`DynamicSlmPipelineContext` は optional な delegation、thought-artifact、memory-placement state を運びます。`DynamicSlmPipelineMetadata` はそれらの stable identifier を mirror し、Core が runtime behavior を contract package に入れずに ResultStep metadata へ投影できるようにします。

テキストフロー:

```text
SeedSLM strict output
  -> DynamicSlmThoughtArtifact
  -> DynamicSlmReplayLogEntry
  -> DynamicSlmTrajectoryMetadata
  -> DynamicSlmDistillationRequest
  -> DynamicSlmDistillationPlan
  -> DynamicSlmDistillationOffloadRequest
```

Core 実装側の擬似コード:

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

# 変更履歴
- v0.0.5 (2026-06-05): DynamicSLM distillation offload contracts と metadata shape を追加。
- v0.0.5 (2026-06-05): DynamicSLM Model ABI contract index と distillation offload metadata を追加。
- v0.0.5 (2026-06-05): SeedSLM discipline、delegation、thought artifact、resident memory contract vocabulary を追加。
