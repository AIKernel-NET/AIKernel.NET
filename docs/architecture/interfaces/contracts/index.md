---
title: "contracts Interfaces"
created: 2026-05-06
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
- [IExpressionContract (Contract Specification)](architecture/interfaces/contracts/IExpressionContract.md)
- [IMaterialContract](architecture/interfaces/contracts/IMaterialContract.md)
- [IOrchestrationContract (Contract Specification)](architecture/interfaces/contracts/IOrchestrationContract.md)
- [IKernelContextContract (Contract Specification)](architecture/interfaces/contracts/IKernelContextContract.md)
- [IMessageContract (Contract Specification)](architecture/interfaces/contracts/IMessageContract.md)
- [ITokenizerProfile (Contract Specification)](architecture/interfaces/contracts/ITokenizerProfile.md)
- [IUnifiedContextContract (Unified Contract Specification)](architecture/interfaces/contracts/IUnifiedContextContract.md)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
