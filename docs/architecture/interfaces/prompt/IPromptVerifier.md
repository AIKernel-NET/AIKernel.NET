---
id: ipromptverifier
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IPromptVerifier"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IPromptVerifier-jp.md.

# IPromptVerifier

## Responsibility
Define the contract boundary for IPromptVerifier within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `VerifyAsync(string promptContent, string signature, CancellationToken ct = default)` | `Task<bool>` | Verify signature validity. |
| `VerifyWithKeyAsync(string promptContent, string signature, string keyId, CancellationToken ct = default)` | `Task<bool>` | Verify with explicit key id. |
| `FailClosed` | `bool` | Verification failure must stop execution. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IPromptVerifier appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.



