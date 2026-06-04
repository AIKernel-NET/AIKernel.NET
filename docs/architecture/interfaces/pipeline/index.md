---
title: "pipeline Interfaces"
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

Japanese version: [Index](index-jp.md)

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
- [IPipelineOrchestrator](../pipeline/IPipelineOrchestrator.md)
- [IPipelineStep](../pipeline/IPipelineStep.md)
- [IStructurePlanner](../pipeline/IStructurePlanner.md)
- [ITaskManager](../pipeline/ITaskManager.md)
- [ITaskVectorEstimator](../pipeline/ITaskVectorEstimator.md)

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added state transition and governance guidance
