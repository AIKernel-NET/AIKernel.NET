---
id: itoolaccessvalidator
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IToolAccessValidator"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IToolAccessValidator

## Responsibility
Define the contract boundary for IToolAccessValidator within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `CanExecuteTool(IToolPermission permission, string toolName)` | `bool` | Validate tool execution permission. |
| `CanReadFile(IToolPermission permission, string filePath)` | `bool` | Validate file read permission. |
| `CanWriteFile(IToolPermission permission, string filePath)` | `bool` | Validate file write permission. |
| `CanAccessNetwork(IToolPermission permission, string host)` | `bool` | Validate network access permission. |
| `CanAccessEnvironment(IToolPermission permission, string variableName)` | `bool` | Validate environment access permission. |
| `CanExecuteSystemCommand(IToolPermission permission, string commandName)` | `bool` | Validate system command permission. |
| `IsPermissionValid(IToolPermission permission)` | `bool` | Check permission validity period. |
| `ValidateConstraints(IToolPermission permission, IReadOnlyDictionary<string, string> context)` | `bool` | Validate runtime constraints. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
