---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Implementation Notes"
status: "Add-only implementation complete"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

English version: [Concept Elevation Refactoring Design](concept-elevation-refactoring-design.md)

# Concept Elevation Refactoring Design

## 目的

Concept Elevation Refactoring は、AIKernel ecosystem の concept layer を安定化
するための設計です。これは rename program ではありません。philosophy、
responsibility、type name、implementation boundary の対応を明示するために、
concept facade と documentation を追加します。

canonical contract repository は AIKernel.NET です。implementation repository は
語彙を再定義せず、この共通 docs を参照します。

## 非目的

この refactoring では次を変更しません。

- CTG-ROM
- GateInput
- CouncilVoteValue
- GateDecisionKind
- TrajectoryGateDecisionKind
- RejectReasonKind
- CanonReference
- Decision Gate logic
- Trajectory Gate logic
- RejectPolicy taxonomy
- 既存 public method signature

confidence、risk score、score、probability、diagnostics などの continuous value を
GateInput に追加してはいけません。

## Concept Vocabulary

canonical vocabulary は
[Canonical Language Dictionary](../canonical-language/index.md) で管理します。

主要な concept term:

- Ethos, Pathos, Logos
- Nomos, Dike, Kratos
- Aisthesis, Phantasia, Chronos, Kairos
- Dynamis, Energeia, Nous
- Telos
- Apatheia, Ataraxia
- Eidos

## Naming Rules

philosophical term は concept surface と上位 viewer / inspector 名にのみ使用できます。
DTO、request、result、mapper、adapter、serializer、converter、HTTP client、
JSInterop、NativeBridge、provider implementation、low-level I/O では禁止します。

詳細な rule set は
[Concept Elevation Guidelines](../guidelines/concept-elevation-guidelines.md) で管理します。

## Repository Responsibilities

| Repository | Concept surface | Boundary |
| --- | --- | --- |
| AIKernel.Core | Telos, Nomos, Dike, Ethos, Pathos, Logos | add-only runtime concept facade。CTG contract と gate logic は変更しない。 |
| AIKernel.Control | Kairos, Nous | orchestration concept facade のみ。Core gate logic を複製しない。 |
| AIKernel.Providers | Ethos, Pathos, Logos, Aisthesis, Phantasia | council semantic material と perception concept surface。provider implementation 名は technical name を維持する。 |
| AIKernel.Wasm | Aisthesis, Phantasia, Chronos, Kairos | interop より上位の WASM perception / scene / time / trigger concept facade。 |
| AIKernel.Doom | Phantasia, Kairos, Chronos | scenario-level visual semantics、autoplay timing、replay window。 |
| AIKernel.Tools | Nomos, Chronos, Phantasia | 上位 viewer と non-breaking CLI alias。parser と command infrastructure 名は technical name を維持する。 |

## Migration Strategy

### Add-Only Facades

各 implementation repository は既存名の横に concept facade を追加できます。
既存 public API は維持します。

### Minimal Internal Adoption

低リスクな内部 call site のみ concept facade を利用できます。初期 adoption は
AIKernel.Tools の `RomCommand` が alias rendering に `NomosViewer` を利用する形です。
command infrastructure 名は変更しません。

### Obsolete Candidate Review

v0.1.1.1 では `[Obsolete]` attribute を付与しません。候補 surface は migration
notes に記録し、将来変更前に review します。

### Future Removal

compatibility name の削除は v1.x 以降の議論であり、v0.1.1.1 scope 外です。
将来削除を検討する場合でも、replacement surface、migration example、
architecture test coverage、明示的な sunset period が先に必要です。

## Architecture Tests

各 implementation repository は、forbidden low-level type name に philosophical
prefix が使われた場合に失敗する architecture naming test を持ちます。
compatibility exception は明示的に document します。

## Related Docs

- [Canonical Language Dictionary](../canonical-language/index.md)
- [Concept Elevation Guidelines](../guidelines/concept-elevation-guidelines.md)
- [Migration Notes](../migration/concept-elevation-v0.1.1.1.md)
- [Refactoring TODO](../todo/concept-elevation-refactoring-todo.md)
