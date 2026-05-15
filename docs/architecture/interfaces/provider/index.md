---
title: "provider Interfaces"
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

Japanese version: [Specification Index](specs/index-jp.md)

# provider Interfaces

## 1. Responsibility Boundary
Provider is the runtime boundary for external LLM/Embedding/RAG systems. Paths selected by routing are executed through `IProvider`/`IModelProvider` families, while cost, usage, health, query-processing support, and embedding metadata are exposed via `IProvider*` contracts.

## 2. Related Use Cases
- `UC-03` Model Vector Routing
- `UC-19` Multi-model Parallel Inference
- `UC-22` Dynamic Capacity Control
- `UC-23` AI Credit Governance
- Phase 1 Query Processing

## 3. Related Specs
- `docs/specs/04.MODEL_ROUTING_SPEC.md`
- `docs/specs/06.REPLAY_DUMP_SPEC.md`
- `docs/specs/01.EXECUTION_PIPELINE_SPEC.md`
- `docs/architecture/17.QUERY_PROCESSING_PHASE1.md`

## Documents
- [IProvider (Interface Specification)](architecture/interfaces/provider/IProvider.md)
- [IModelProvider (Interface Specification)](architecture/interfaces/provider/IModelProvider.md)
- [IModelMessage (Interface Specification)](architecture/interfaces/provider/IModelMessage.md)
- [IEmbeddingProvider (Interface Specification)](architecture/interfaces/provider/IEmbeddingProvider.md)
- [IRagProvider (Interface Specification)](architecture/interfaces/provider/IRagProvider.md)
- [IEventBus (Interface Specification)](architecture/interfaces/provider/IEventBus.md)
- [IScheduler (Interface Specification)](architecture/interfaces/provider/IScheduler.md)
- [IProviderCapabilities (Interface Specification)](architecture/interfaces/provider/IProviderCapabilities.md)
- [IProviderCostProfile (Interface Specification)](architecture/interfaces/provider/IProviderCostProfile.md)
- [IProviderCreditInfo (Interface Specification)](architecture/interfaces/provider/IProviderCreditInfo.md)
- [IProviderBillingInfo (Interface Specification)](architecture/interfaces/provider/IProviderBillingInfo.md)
- [IProviderUsageStats (Usage Telemetry Interface Specification)](architecture/interfaces/provider/IProviderUsageStats.md)
- [IProviderResourceProfile (Unified Resource Profile Specification)](architecture/interfaces/provider/IProviderResourceProfile.md)
- [IProviderRouter](architecture/interfaces/provider/IProviderRouter.md)

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added Router/Capacity boundaries and observability notes
- v0.0.1 (2026-05-09): Added query-processing capability boundary
