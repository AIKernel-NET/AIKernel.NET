---
id: ivfsprovider
title: "IVfsProvider"
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

Japanese version: [IVfsProvider](architecture/interfaces/vfs/IVfsProvider-jp.md)

# IVfsProvider

## Responsibility
Define the provider boundary that opens authenticated Vfs sessions within AIKernel orchestration and governance flows.

`IVfsProvider` does not itself imply read, write, delete, navigation, or query authority. Those authorities are represented by the capability interfaces implemented by the returned session.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Vfs provider identifier. |
| `Name` | `string` | Vfs provider display name. |
| `OpenSessionAsync(IVfsCredentials credentials)` | `Task<IVfsSession>` | Open authenticated Vfs session. |
| `IsAvailableAsync()` | `Task<bool>` | Check provider availability. |
| `GetHealthAsync()` | `Task<VfsProviderHealth>` | Return health status for diagnostics. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IVfsProvider appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.
- Concrete Vfs data carriers (for example `VfsProviderHealth`) are defined in `AIKernel.Dtos.Vfs`.
- Missing capabilities must be detected before execution by checking the required capability interface. Providers should not expose unsupported write/delete/query members that fail late.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.2 (2026-05-09): Clarified session capability boundary
