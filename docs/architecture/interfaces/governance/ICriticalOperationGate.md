---
id: icriticaloperationgate
title: "ICriticalOperationGate"
created: 2026-06-05
updated: 2026-06-05
published: 2026-06-05
version: "0.0.5"
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

Japanese version: [ICriticalOperationGate](../governance/ICriticalOperationGate-jp.md)

# ICriticalOperationGate

## Responsibility
Define the fail-closed pre-inference boundary for destructive, persistent, privileged, or external side-effect operations.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `EvaluateAsync` | `ValueTask<CriticalOperationGateResult>` | Evaluate a deterministic `CriticalOperationProfile` and return an admissibility decision plus required mitigations. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for governance and admission-control references.

## Notes
- Implementations must not execute side effects while evaluating the profile.
- Unsupported or unknown operations must terminate through deny, clarify, no-execution, or explicit mitigation requirements.
---

# Changelog
- v0.0.5 (2026-06-05): Added pre-inference critical-operation gate contract.
