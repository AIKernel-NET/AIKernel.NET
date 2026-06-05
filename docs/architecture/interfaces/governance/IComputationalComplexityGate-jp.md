---
id: icomputationalcomplexitygate-jp
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
  - japanese
---

English version: [IComputationalComplexityGate](../governance/IComputationalComplexityGate.md)

# IComputationalComplexityGate

## Responsibility
task が現在の model execution budget に収まるか、または delegate / decompose / clarify / deny すべきかを、推論開始前に deterministic に判定する境界を定義する。

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `EvaluateAsync` | `ValueTask<ComplexityGateResult>` | deterministic な `TaskComplexityProfile` を `ModelExecutionBudget` に照らして評価する。 |

## Related Use Cases
Admission-control / routing の参照は ../../use-cases/AIKernel_UseCaseCatalog-jp.md を参照する。

## Notes
- complexity extraction は deterministic かつ replayable でなければならない。
- model budget 外の task を stochastic inference へ楽観的に渡してはならない。
---

# Changelog
- v0.0.5 (2026-06-05): pre-inference computational-complexity gate contract を追加。
