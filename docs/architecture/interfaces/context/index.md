---
title: "context Interfaces"
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

# context Interfaces

## 1. Responsibility Boundary
Context manages working memory within a single inference cycle. `IContextCollection` defines buffer boundaries, and `IContextSnapshot` provides immutable checkpoints for audit and replay. Together they enforce layer separation and deterministic reproducibility.

## 2. Related Use Cases
- `UC-06` Three-Layer Buffer Isolation
- `UC-09` Execution State Persistence and Restore
- `UC-20` Deterministic Replay and Audit Trail

## 3. Related Specs
- `01.EXECUTION_PIPELINE_SPEC.md`
- `06.REPLAY_DUMP_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos.Context`, `AIKernel.Dtos.Kernel`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Conversation`

## Documents
- [IContextCollection (Interface Specification)](architecture/interfaces/context/IContextCollection.md)
- [IContextSnapshot (Interface Specification)](architecture/interfaces/context/IContextSnapshot.md)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
