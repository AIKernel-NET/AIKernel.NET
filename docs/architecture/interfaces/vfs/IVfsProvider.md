---
id: ivfsprovider
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IVfsProvider"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IVfsProvider-jp.md.

# IVfsProvider

## Responsibility
Define the contract boundary for IVfsProvider within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | VFS provider identifier. |
| `Name` | `string` | VFS provider display name. |
| `OpenSessionAsync(IVfsCredentials credentials)` | `Task<IVfsSession>` | Open authenticated VFS session. |
| `IsAvailableAsync()` | `Task<bool>` | Check provider availability. |
| `GetHealthAsync()` | `Task<VfsProviderHealth>` | Return health status for diagnostics. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IVfsProvider appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.
- Concrete VFS data carriers (for example `VfsProviderHealth`) are defined in `AIKernel.Dtos.Vfs`.



