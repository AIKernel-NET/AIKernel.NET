---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "vfs Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# vfs Interfaces

## 1. Responsibility Boundary
VFS abstracts the persistence boundary for intelligence assets. `IVfsProvider` exposes only contracts for path resolution, integrity checks, and read/write operations, while concrete data carriers stay in the DTO layer.

## 2. Related Use Cases
- `UC-01` ROM Loading and Parsing
- `UC-09` Execution State Persistence and Restore
- `UC-20` Deterministic Replay and Audit Trail

## 3. Related Specs
- `03.ROM_CORE_SPEC.md`
- `06.REPLAY_DUMP_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos.Vfs`
- Called by: `AIKernel.Abstractions.Rom`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Execution`

## Boundary Rule
- VFS package keeps interface contracts only; concrete data carriers are defined in `AIKernel.Dtos.Vfs`.

## Documents
- IVfsProvider.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
