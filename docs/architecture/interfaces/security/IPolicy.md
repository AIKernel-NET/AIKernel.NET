---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IPolicy"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IPolicy-jp.md](./IPolicy-jp.md).

# IPolicy

## 1. Responsibility Boundary
$n defines: Policy abstraction evaluated by guard/PDP.

## 2. Related Use Cases
- UC-11, UC-21

## 3. Related Specs
- 02.SIGNED_PROMPT_GOVERNANCE_SPEC

## 4. Deterministic and Fail-Closed Notes
- The implementation should preserve deterministic behavior for identical inputs.
- Any indeterminate or invalid state should be handled fail-closed.

## 5. Source of Truth
- src/AIKernel.Abstractions (or sibling canonical contract project) is the source of truth for signatures.

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added from source-alignment finalization board
