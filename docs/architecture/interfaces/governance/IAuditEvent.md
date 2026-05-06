---
id: iauditevent
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IAuditEvent"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IAuditEvent

## Responsibility
Define the contract boundary for IAuditEvent within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `EventId` | `string` | Unique audit event id. |
| `Category` | `string` | Audit category. |
| `Timestamp` | `DateTimeOffset` | Event timestamp. |
| `Metadata` | `IReadOnlyDictionary<string, object>` | Structured audit metadata. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
