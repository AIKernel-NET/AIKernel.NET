---
id: imodelprovider
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IModelProvider"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IModelProvider

## Responsibility
Define the contract boundary for IModelProvider within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default)` | `Task<string>` | Execute text generation. |
| `StreamGenerateAsync(IReadOnlyList<IModelMessage> messages, Func<string, Task> onChunk, CancellationToken cancellationToken = default)` | `Task` | Stream generation chunks. |
| `AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default)` | `Task<string>` | Generate answer for a single question. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
