---
version: 0.0.2
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "vfs Interfaces"
created: 2026-05-03
updated: 2026-05-09
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# vfs Interfaces

## 1. Responsibility Boundary
Vfs abstracts the persistence boundary for intelligence assets. `IVfsProvider` opens authenticated sessions, and session/file/directory capabilities expose only the operations that a provider actually supports. Concrete data carriers stay in the DTO layer.

Vfs permissions are expressed through capability interfaces rather than late runtime failure. A read-only provider should expose readable session/file contracts and must not be forced to implement write or delete operations.

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
- Vfs package keeps interface contracts only; concrete data carriers are defined in `AIKernel.Dtos.Vfs`.
- Capability availability must be represented by implemented interfaces, not by placeholder methods that throw `NotSupportedException`.
- `IVfsFile`, `IVfsDirectory`, and `IVfsSession` remain composite compatibility contracts for callers that require the legacy full surface.

## Documents
- IVfsProvider.md
- IVfsCapabilityContracts.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.2 (2026-05-09): Added capability-based Vfs interface segregation
