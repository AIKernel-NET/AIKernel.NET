---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "context Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

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
- IContextCollection.md
- IContextSnapshot.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
