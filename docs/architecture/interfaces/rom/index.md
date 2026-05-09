---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "rom Interfaces"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# rom Interfaces

## 1. Responsibility Boundary
ROM is the boundary for canonical intelligence artifacts and validation. Around `IRomDocument`, `IRomCanonicalizer`, `ISemanticHasher`, `IRomValidator`, and `IRelationResolver` handle normalization, integrity checks, and relation resolution.

## 2. Related Use Cases
- `UC-01` ROM Loading and Parsing
- `UC-15` Context Hydration
- `UC-20` Deterministic Replay

## 3. Related Specs
- `03.ROM_CORE_SPEC.md`
- `06.REPLAY_DUMP_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos.Rom`, `AIKernel.Dtos.Context`
- Called by: `AIKernel.Abstractions.Prompt`, `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Governance`

## Documents
- IRomCanonicalizer.md
- ISemanticHasher.md
- IRomDocument.md
- IRomValidator.md
- IRelationResolver.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
