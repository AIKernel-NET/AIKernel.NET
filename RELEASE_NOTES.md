# AIKernel.NET Release Notes

[日本語](RELEASE_NOTES-ja.md)

## 0.1.1

**June 10th, 2026 - Aligning the Semantic OS boundary.**
**2026年6月10日--Semantic OS の境界を整列する。**

Aligning the Semantic OS boundary: abstractions, contracts, and identifiers
converge into the unified 0.1.1 surface. Semantic OS の境界整列--抽象・契約・
識別子が 0.1.1 の統一面へ収束する。

AIKernel.NET 0.1.1 completes the synchronized contract boundary for the
Semantic OS package family.

- Freeze the public contract boundary for Abstractions, DTOs, Enums, and
  contract-only surfaces.
- Promote Control execution requests, execution graphs, snapshots, results,
  routing DTOs, memory abstractions, DSL, History ROM, Capability ROM,
  DynamicSLM, SeedSLM, HATL, and governance vocabulary into the shared contract
  family where appropriate.
- Preserve the interface-only rule for `AIKernel.Abstractions` and
  `AIKernel.Contracts`.
- Keep implementation behavior outside AIKernel.NET; runtime packages live in
  AIKernel.Core, AIKernel.Control, AIKernel.Tools, AIKernel.Cuda13.0, and
  AIKernel.Demo.
- Keep AIKernel.NET under MIT because it contains no implementation and carries
  no patent surface. Papers and research documents remain governed by the
  license attached to each paper.

This release marks the synchronized 0.1.1 boundary for semantic visibility:
determinism, contract boundaries, semantic state, observability, and governed
circuits are named as stable public concepts across the ecosystem.
