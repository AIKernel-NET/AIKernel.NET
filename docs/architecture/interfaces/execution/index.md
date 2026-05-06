---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "execution Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# execution Interfaces

## 1. Responsibility Boundary
Execution is the core boundary of inference runtime. `IThoughtProcess` handles structural reasoning, `IOutputPolisher` handles expression rendering, and `IComputeShapeAdvisor` plus `ITokenizer` control compute/token constraints to preserve two-phase execution and reproducibility.

## 2. Related Use Cases
- `UC-02` Structure Phase Execution
- `UC-04` Generation and Output Polishing
- `UC-30` Token/Vector Estimation

## 3. Related Specs
- `01.EXECUTION_PIPELINE_SPEC.md`
- `04.MODEL_ROUTING_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Enums`, `AIKernel.Contracts`
- Called by: `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Routing`

## Documents
- IComputeShapeAdvisor.md
- IOutputPolisher.md
- IThoughtProcess.md
- ITokenizer.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
