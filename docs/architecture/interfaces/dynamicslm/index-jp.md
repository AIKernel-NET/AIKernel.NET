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
| `IDynamicSlmCapabilityGraphResolver` | task に必要な最小 capability subgraph を解決する。 |
| `IDynamicSlmCompatibilityVerifier` | payload loading 前に semantic profile と governance compatibility を検証する。 |
| `IDynamicSlmLineageVerifier` | payload 利用前に lineage、artifact hash、admission metadata を検証する。 |
| `IDynamicSlmPayloadLoader` | runtime implementation type を公開せず payload descriptor を materialize / unload する。 |
| `IDynamicSlmScheduler` | execution profile から accelerator placement と prefetch plan を作る。 |
| `IDynamicSlmCapabilityGapDetector` | 検証済み ReplayLog trace から capability gap を検出する。 |
| `IDynamicSlmCapabilityGraphEvolutionPlanner` | 繰り返し検証された gap から、governed Capability Graph update を提案する。 |
| `IDynamicSlmDistillationPlanner` | 対象 capability module 向けの differential distillation plan を作る。 |
| `IDynamicSlmArtifactPublisher` | 検証済み distilled artifact を registry 境界から公開する。 |

## DTO Ownership

DynamicSLM data record は `AIKernel.Dtos.DynamicSlm` が所有します。
共有 enum primitive は `AIKernel.Enums` が所有します。
runtime implementation、検証ロジック、payload handle、result pipeline は `AIKernel.Abstractions` ではなく Core または Provider package が所有します。

## Pipeline / LINQ Composition Boundary

`AIKernel.NET` は `AIKernel.Common.Result<T>`、`Option<T>`、`Either<L,R>` を公開しません。
DynamicSLM pipeline DTO は、Core が内部 Result monad へ adapter できる package-boundary shape を提供します。
`DynamicSlmPipelineResult<T>` は contract package 内で monadic behavior を実装せず、success/failure、trace、metadata だけを運びます。

Core 実装側の擬似コード:

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

# 変更履歴
- v0.0.5 (2026-06-05): DynamicSLM Model ABI contract index を追加。
