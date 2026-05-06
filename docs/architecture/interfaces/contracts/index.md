---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "contracts Interfaces"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# contracts Interfaces

## 1. Responsibility Boundary
Contracts serve as the cross-module ABI for AIKernel. Through Orchestration, Expression, Material, and UnifiedContext contracts, they define strict boundary conditions between reasoning, expression, and external material.

## 2. Related Use Cases
- `UC-02` Structure Phase
- `UC-04` Output Polishing
- `UC-06` Three-Layer Buffer Isolation

## 3. Related Specs
- `01.EXECUTION_PIPELINE_SPEC.md`
- `16.SEMANTIC_CONTEXT_OS_VISION.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Context`, `AIKernel.Abstractions.Governance`

## Documents
- IExpressionContract.md
- IMaterialContract.md
- IOrchestrationContract.md
- IKernelContextContract.md
- IMessageContract.md
- ITokenizerProfile.md
- IUnifiedContextContract.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
