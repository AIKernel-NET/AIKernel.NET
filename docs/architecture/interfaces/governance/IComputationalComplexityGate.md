---
id: icomputationalcomplexitygate
title: "IComputationalComplexityGate"
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

Japanese version: [IComputationalComplexityGate](../governance/IComputationalComplexityGate-jp.md)

# IComputationalComplexityGate

## Responsibility
Define the deterministic pre-inference boundary that decides whether a task fits the current model execution budget or should be delegated, decomposed, clarified, or denied.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `EvaluateAsync` | `ValueTask<ComplexityGateResult>` | Evaluate a deterministic `TaskComplexityProfile` against a `ModelExecutionBudget`. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for admission-control and routing references.

## Notes
- Complexity extraction must be deterministic and replayable.
- Tasks outside the model budget must not be optimistically forwarded to stochastic inference.
---

# Changelog
- v0.0.5 (2026-06-05): Added pre-inference computational-complexity gate contract.
