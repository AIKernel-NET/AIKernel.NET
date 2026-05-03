---
id: iragprovider
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IRagProvider"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IRagProvider

## Responsibility
Define the contract boundary for IRagProvider within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default)` | `Task<IReadOnlyList<MaterialContextDto>>` | Search relevant material entries. |
| `IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default)` | `Task` | Index a document into retrieval storage. |
| `DeleteAsync(string documentId, CancellationToken cancellationToken = default)` | `Task` | Delete indexed document. |
| `ClearAsync(CancellationToken cancellationToken = default)` | `Task` | Clear index entries. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
