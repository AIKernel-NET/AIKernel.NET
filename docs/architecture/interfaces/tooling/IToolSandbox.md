---
id: itoolsandbox
title: "IToolSandbox"
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

Japanese version: $(System.Collections.Hashtable.Name)

# IToolSandbox

## Responsibility
Define the contract boundary for IToolSandbox within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `SandboxId` | `string` | Sandbox identifier. |
| `ExecuteToolAsync(string toolName, IReadOnlyDictionary<string, string> parameters, IToolPermission permissions)` | `Task<SandboxExecutionResult>` | Execute tool within sandbox. |
| `UploadFileAsync(string fileName, byte[] content)` | `Task<bool>` | Upload file into sandbox. |
| `DownloadFileAsync(string fileName)` | `Task<byte[]?>` | Download file from sandbox. |
| `CleanupAsync()` | `Task` | Cleanup sandbox resources. |
| `GetResourceUsageAsync()` | `Task<SandboxResourceUsage>` | Get sandbox resource usage. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
