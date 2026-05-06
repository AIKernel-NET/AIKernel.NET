---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "routing Interfaces"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# routing Interfaces

## 1. Responsibility Boundary
Routing is the boundary for model/provider selection based on required capability vectors, execution constraints, and runtime conditions. `IModelVectorRouter` owns the decision process, while `ICapabilityRegistry` resolves candidate facts. Replay mode prioritizes locked conditions over dynamic routing.

## 2. Related Use Cases
- `UC-03` Model Vector Routing
- `UC-22` Dynamic Capacity Control and Model Routing
- `UC-30` Token/Vector Estimation

## 3. Related Specs
- `04.MODEL_ROUTING_SPEC.md`
- `06.REPLAY_DUMP_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`

## Documents
- ICapabilityRegistry.md
- IModelVectorRouter.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
