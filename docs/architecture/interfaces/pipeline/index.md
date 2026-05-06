---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "pipeline Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# pipeline Interfaces

## 1. Responsibility Boundary
Pipeline controls stateful execution transitions. `IPipelineOrchestrator` and `IPipelineStep` fix transition order, while `IStructurePlanner` and `ITaskManager` isolate phase-level responsibilities.

## 2. Related Use Cases
- `UC-02` Structure Phase
- `UC-29` Task Pipeline Management
- `UC-30` Token/Vector Estimation

## 3. Related Specs
- `docs/specs/01.EXECUTION_PIPELINE_SPEC.md`
- `docs/specs/04.MODEL_ROUTING_SPEC.md`

## Documents
- IPipelineOrchestrator.md
- IPipelineStep.md
- IStructurePlanner.md
- ITaskManager.md
- ITaskVectorEstimator.md

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added state transition and governance guidance
