---
id: iproviderregistrar
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderRegistrar"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IProviderRegistrar-jp.md.

# IProviderRegistrar

## Responsibility
Define the contract boundary for IProviderRegistrar within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `Name` | `string` | Logical identifier of this contract instance. |
| `Version` | `string` | Contract version for compatibility checks. |
| `Metadata` | `IReadOnlyDictionary<string, string>` | Extension metadata for implementation-specific details. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IProviderRegistrar appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



