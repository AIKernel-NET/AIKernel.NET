---
id: itokenizer
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ITokenizer"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# ITokenizer

## Responsibility
Define the contract boundary for ITokenizer within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `CountTokens(string text)` | `int` | Count token length for text input. |
| `Tokenize(string text)` | `IReadOnlyList<int>` | Tokenize text into token ids. |
| `Decode(IReadOnlyList<int> tokens)` | `string` | Decode token ids into text. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
