---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "provider Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# provider Interfaces

## 1. Responsibility Boundary
Provider is the runtime boundary for external LLM/Embedding/RAG systems. Paths selected by routing are executed through `IProvider`/`IModelProvider` families, while cost, usage, and health are exposed via `IProvider*` contracts.

## 2. Related Use Cases
- `UC-03` Model Vector Routing
- `UC-19` Multi-model Parallel Inference
- `UC-22` Dynamic Capacity Control
- `UC-23` AI Credit Governance

## 3. Related Specs
- `docs/specs/04.MODEL_ROUTING_SPEC.md`
- `docs/specs/06.REPLAY_DUMP_SPEC.md`

## Documents
- IProvider.md
- IModelProvider.md
- IModelMessage.md
- IEmbeddingProvider.md
- IRagProvider.md
- IEventBus.md
- IScheduler.md
- IProviderCapabilities.md
- IProviderCostProfile.md
- IProviderCreditInfo.md
- IProviderBillingInfo.md
- IProviderUsageStats.md
- IProviderResourceProfile.md
- IProviderRouter.md

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added Router/Capacity boundaries and observability notes
