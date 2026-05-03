---
id: itoolpermission
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IToolPermission"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IToolPermission

## Responsibility
Define the contract boundary for IToolPermission within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `PermissionId` | `string` | Permission profile id. |
| `AllowedTools` | `IReadOnlyList<string>` | Allowed tool names. |
| `ExpiresAt` | `DateTimeOffset?` | Optional expiration time. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
