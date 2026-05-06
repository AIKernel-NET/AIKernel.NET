---
id: ipromptsignatureprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IPromptSignatureProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IPromptSignatureProvider-jp.md.

# IPromptSignatureProvider

## Responsibility
Define the contract boundary for IPromptSignatureProvider within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `Name` | `string` | Logical identifier of this contract instance. |
| `Version` | `string` | Contract version for compatibility checks. |
| `Metadata` | `IReadOnlyDictionary<string, string>` | Extension metadata for implementation-specific details. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IPromptSignatureProvider appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
