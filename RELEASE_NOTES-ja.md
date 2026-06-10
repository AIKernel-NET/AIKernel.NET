# AIKernel.NET リリースノート

[English](RELEASE_NOTES.md)

## 0.1.1

**June 10th, 2026 - Aligning the Semantic OS boundary.**
**2026年6月10日--Semantic OS の境界を整列する。**

Aligning the Semantic OS boundary: abstractions, contracts, and identifiers
converge into the unified 0.1.1 surface. Semantic OS の境界整列--抽象・契約・
識別子が 0.1.1 の統一面へ収束する。

AIKernel.NET 0.1.1 は、Semantic OS package family の同期された契約境界を
確立します。

- Abstractions、DTO、Enum、contract-only surface の public contract boundary を固定します。
- Control execution request、execution graph、snapshot、result、routing DTO、memory abstraction、DSL、History ROM、Capability ROM、DynamicSLM、SeedSLM、HATL、governance vocabulary を、必要な範囲で shared contract family へ昇格します。
- `AIKernel.Abstractions` と `AIKernel.Contracts` の interface-only 原則を維持します。
- 実装挙動は AIKernel.NET に置かず、AIKernel.Core、AIKernel.Control、AIKernel.Tools、AIKernel.Cuda13.0、AIKernel.Demo が runtime / tooling / demo 側を担います。
- AIKernel.NET は実装を含まないため特許面のリスクがなく、MIT により標準化と相互運用性を最大化します。論文および研究文書は各 paper に明示された license に従います。

この release は 0.1.1 の semantic visibility boundary を同期します。決定論性、
契約境界、Semantic State、可観測性、Governed Circuit が ecosystem 全体で
stable public concept として名前を持ちます。
