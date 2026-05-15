---
title: "conversation Interfaces"
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
- [IConversationBranch](architecture/interfaces/conversation/IConversationBranch.md)
- [IConversationCheckpoint](architecture/interfaces/conversation/IConversationCheckpoint.md)
- [IConversationDiff](architecture/interfaces/conversation/IConversationDiff.md)
- [IConversationSnapshot](architecture/interfaces/conversation/IConversationSnapshot.md)
- [IConversationStore](architecture/interfaces/conversation/IConversationStore.md)
- [IConversationTimeline](architecture/interfaces/conversation/IConversationTimeline.md)
- [IDiffFormatter](architecture/interfaces/conversation/IDiffFormatter.md)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
