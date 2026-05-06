---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IMaterialScanner"
created: 2026-05-06
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IMaterialScanner-jp.md](./IMaterialScanner-jp.md).

# IMaterialScanner

## 1. Responsibility Boundary
$n defines: Pre-quarantine scanner contract for raw material risk detection.

## 2. Related Use Cases
- UC-07, UC-21

## 3. Related Specs
- 05.MATERIAL_QUARANTINE_SPEC

## 4. Deterministic and Fail-Closed Notes
- The implementation should preserve deterministic behavior for identical inputs.
- Any indeterminate or invalid state should be handled fail-closed.

## 5. Source of Truth
- src/AIKernel.Abstractions (or sibling canonical contract project) is the source of truth for signatures.

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added from source-alignment finalization board
