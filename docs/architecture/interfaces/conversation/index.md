---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "conversation Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# conversation Interfaces

## 1. Responsibility Boundary
Conversation covers branching, diffing, and timeline reconstruction of dialogue state. Snapshot-oriented interfaces preserve traceability and reproducibility across long-running sessions.

## 2. Related Use Cases
- `UC-17` Chat Diffing
- `UC-18` Conversation Persistence
- `UC-20` Deterministic Replay

## 3. Related Specs
- `01.EXECUTION_PIPELINE_SPEC.md`
- `06.REPLAY_DUMP_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos.Context`, `AIKernel.Dtos.Core`
- Called by: `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Vfs`

## Documents
- IConversationBranch.md
- IConversationCheckpoint.md
- IConversationDiff.md
- IConversationSnapshot.md
- IConversationStore.md
- IConversationTimeline.md
- IDiffFormatter.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
