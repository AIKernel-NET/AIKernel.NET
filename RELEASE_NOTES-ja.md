# AIKernel.NET リリースノート

[English](RELEASE_NOTES.md)

## 0.1.0

> [EN] Crossing the 0.1.0 event horizon: the semantic runtime becomes observable, deterministic, and contract-led.
>
> [JA] 0.1.0 の事象の地平を越える──意味的ランタイムは可観測・決定論・契約駆動へと収束する。

AIKernel.NET 0.1.0 は、Semantic Runtime の Phase-1 contract baseline を完了します。

- Abstractions、DTO、Enum、contract-only surface の public contract boundary を固定します。
- Control execution request、execution graph、snapshot、result、routing DTO、memory abstraction、DSL、History ROM、Capability ROM、DynamicSLM、SeedSLM、HATL、governance vocabulary を、必要な範囲で shared contract family へ昇格します。
- `AIKernel.Abstractions` と `AIKernel.Contracts` の interface-only 原則を維持します。
- 実装挙動は AIKernel.NET に置かず、AIKernel.Core、AIKernel.Control、AIKernel.Tools、AIKernel.Cuda13.0、AIKernel.Demo が runtime / tooling / demo 側を担います。
- AIKernel.NET は実装を含まないため特許面のリスクがなく、MIT により標準化と相互運用性を最大化します。論文および研究文書は各 paper に明示された license に従います。

このリリースは「意味論の可視化フェーズ」の完成点です。決定論性、契約境界、Semantic State、可観測性、Governed Circuit が stable public concept として名前を持ちます。
