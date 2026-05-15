---
title: "rom Interfaces"
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
- [IRomCanonicalizer (ROM Canonicalization Interface Specification)](architecture/interfaces/rom/IRomCanonicalizer.md)
- [ISemanticHasher (Semantic Hash Interface Specification)](architecture/interfaces/rom/ISemanticHasher.md)
- [IRomDocument (ROM Document Specification)](architecture/interfaces/rom/IRomDocument.md)
- [IRomValidator (ROM Validator Specification)](architecture/interfaces/rom/IRomValidator.md)
- [IRelationResolver (Relation Resolution Interface Specification)](architecture/interfaces/rom/IRelationResolver.md)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
