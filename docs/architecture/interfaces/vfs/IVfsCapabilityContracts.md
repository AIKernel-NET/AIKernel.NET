---
id: ivfscapabilitycontracts
title: "Vfs Capability Contracts"
created: 2026-05-09
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
  - vfs
  - capability
  - english
---

Japanese version: [Vfs Capability Contracts](architecture/interfaces/vfs/IVfsCapabilityContracts-jp.md)

# Vfs Capability Contracts

## Responsibility
Vfs capability contracts express file-system authority at the type-system level. Implementations expose only the interfaces that correspond to operations they can perform.

## Capability Interfaces
| Interface | Responsibility |
| --- | --- |
| `IVfsEntryInfo` | Common Vfs entry identity and metadata. |
| `IReadableVfsFile` | Read file bytes or text. |
| `IWritableVfsFile` | Write file bytes or text when file-level mutation is supported. |
| `INavigableVfsDirectory` | Enumerate files, directories, entries, and subdirectories. |
| `IReadableVfsSession` | Read files and check path existence. |
| `IWritableVfsSession` | Write files through a session. |
| `IDeletableVfsSession` | Delete files or directories through a session. |
| `INavigableVfsSession` | Open navigable directories through a session. |
| `IQueryableVfsSession` | Execute provider-defined Vfs queries. |

## Compatibility Contracts
`IVfsFile`, `IVfsDirectory`, and `IVfsSession` remain as composite compatibility contracts.

- `IVfsFile` extends `IReadableVfsFile`.
- `IVfsDirectory` extends `INavigableVfsDirectory` and keeps legacy directory return types.
- `IVfsSession` composes readable, writable, deletable, navigable, queryable, and async-disposable session capabilities.

## Fail-Closed Rule
A caller must check the required capability interface before executing an operation. If the capability is absent, execution must be denied before side effects begin.

Unsupported capabilities must not be represented by methods that partially execute or fail late with `NotSupportedException`.

---

# Changelog
- v0.0.2 (2026-05-09): Initial capability-based Vfs contract definition
