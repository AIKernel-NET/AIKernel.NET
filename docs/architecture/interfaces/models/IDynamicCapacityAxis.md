---
title: "IDynamicCapacityAxis"
created: 2026-05-06
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
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

For Japanese version, see [IDynamicCapacityAxis-jp.md](./IDynamicCapacityAxis-jp.md).

# IDynamicCapacityAxis

## 1. Responsibility Boundary
$n defines: Runtime-updatable capability axis for live routing pressure.

## 2. Related Use Cases
- UC-22

## 3. Related Specs
- 04.MODEL_ROUTING_SPEC

## 4. Deterministic and Fail-Closed Notes
- The implementation should preserve deterministic behavior for identical inputs.
- Any indeterminate or invalid state should be handled fail-closed.

## 5. Source of Truth
- src/AIKernel.Abstractions (or sibling canonical contract project) is the source of truth for signatures.

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added from source-alignment finalization board
