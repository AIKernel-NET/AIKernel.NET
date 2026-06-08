# AIKernel.NET Release Notes

[日本語](RELEASE_NOTES-ja.md)

## 0.1.0

> [EN] Crossing the 0.1.0 event horizon: the semantic runtime becomes observable, deterministic, and contract-led.
>
> [JA] 0.1.0 の事象の地平を越える──意味的ランタイムは可観測・決定論・契約駆動へと収束する。

AIKernel.NET 0.1.0 completes the Phase-1 contract baseline for the semantic
runtime.

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

This release marks the completion point of the semantic visibility phase:
determinism, contract boundaries, semantic state, observability, and governed
circuits are now named as stable public concepts.
