---
id: icriticaloperationgate-jp
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
  - japanese
---

English version: [ICriticalOperationGate](../governance/ICriticalOperationGate.md)

# ICriticalOperationGate

## Responsibility
破壊的・永続的・特権的・外部副作用を伴う operation を、推論開始前に fail-closed で境界化する。

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `EvaluateAsync` | `ValueTask<CriticalOperationGateResult>` | deterministic な `CriticalOperationProfile` を評価し、admissibility decision と必要な mitigation を返す。 |

## Related Use Cases
Governance / admission control の参照は ../../use-cases/AIKernel_UseCaseCatalog-jp.md を参照する。

## Notes
- 評価中に副作用を実行してはならない。
- 未知または未対応の operation は deny、clarify、no-execution、または明示的 mitigation requirement へ閉じること。
---

# Changelog
- v0.0.5 (2026-06-05): pre-inference critical-operation gate contract を追加。
