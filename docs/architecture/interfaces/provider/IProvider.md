---
id: iprovider
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProvider"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IProvider-jp.md.

# IProvider

## Responsibility
Define the contract boundary for IProvider within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `ProviderId` | `string` | Unique provider identifier. |
| `Name` | `string` | Provider display name. |
| `Version` | `string` | Provider version string. |
| `GetCapabilities()` | `IProviderCapabilities` | Return static and dynamic capability metadata. |
| `IsAvailableAsync()` | `Task<bool>` | Check provider availability. |
| `InitializeAsync()` | `Task` | Initialize provider runtime resources. |
| `ShutdownAsync()` | `Task` | Shutdown and release resources. |
| `GetHealthAsync()` | `Task<ProviderHealthStatus>` | Execute provider health check. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IProvider appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



