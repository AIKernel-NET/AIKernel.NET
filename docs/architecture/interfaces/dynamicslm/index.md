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
| `IDynamicSlmCapabilityGraphResolver` | Resolve the minimum capability subgraph required for a task. |
| `IDynamicSlmLineageVerifier` | Verify lineage, artifact hashes, and admission metadata before payload use. |
| `IDynamicSlmPayloadLoader` | Materialize and unload payload descriptors without exposing runtime implementation types. |
| `IDynamicSlmScheduler` | Produce accelerator placement and prefetch plans from execution profiles. |
| `IDynamicSlmCapabilityGapDetector` | Detect capability gaps from verified ReplayLog traces. |
| `IDynamicSlmDistillationPlanner` | Create differential distillation plans for targeted capability modules. |
| `IDynamicSlmArtifactPublisher` | Publish validated distilled artifacts through the registry boundary. |

## DTO Ownership

DynamicSLM data records are owned by `AIKernel.Dtos.DynamicSlm`.
Shared enum primitives are owned by `AIKernel.Enums`.
Runtime implementations, verification logic, payload handles, and result pipelines belong to Core or Provider packages, not to `AIKernel.Abstractions`.

---

# Changelog
- v0.0.5 (2026-06-05): Added DynamicSLM Model ABI contract index.
