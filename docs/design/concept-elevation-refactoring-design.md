---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Implementation Notes"
status: "Add-only implementation complete"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

Japanese version: [Concept Elevation Refactoring Design](concept-elevation-refactoring-design-jp.md)

# Concept Elevation Refactoring Design

## Purpose

Concept Elevation Refactoring defines a stable concept layer for the AIKernel
ecosystem. It is not a rename program. It adds concept facades and documentation
so the relationship between philosophy, responsibility, type names, and
implementation boundaries is explicit.

The canonical contract repository is AIKernel.NET. Implementation repositories
must reference these common docs instead of redefining the vocabulary.

## Non-Goals

The following are not changed by this refactoring:

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
- existing public method signatures

Continuous values such as confidence, risk score, score, probability, and
diagnostics must not be added to GateInput.

## Concept Vocabulary

The canonical vocabulary is maintained in
[Canonical Language Dictionary](../canonical-language/index.md).

Core concept terms include:

- Ethos, Pathos, Logos
- Nomos, Dike, Kratos
- Aisthesis, Phantasia, Chronos, Kairos
- Dynamis, Energeia, Nous
- Telos
- Apatheia, Ataraxia
- Eidos

## Naming Rules

Philosophical terms are allowed only on concept surfaces and upper-level
viewer / inspector names. They are forbidden on DTO, request, result, mapper,
adapter, serializer, converter, HTTP client, JSInterop, NativeBridge, provider
implementation, and low-level I/O names.

The detailed rule set is maintained in
[Concept Elevation Guidelines](../guidelines/concept-elevation-guidelines.md).

## Repository Responsibilities

| Repository | Concept surface | Boundary |
| --- | --- | --- |
| AIKernel.Core | Telos, Nomos, Dike, Ethos, Pathos, Logos | Add-only runtime concept facades. CTG contracts and gate logic remain unchanged. |
| AIKernel.Control | Kairos, Nous | Orchestration concept facades only. Control does not duplicate Core gate logic. |
| AIKernel.Providers | Ethos, Pathos, Logos, Aisthesis, Phantasia | Council semantic material and perception concept surfaces. Provider implementation names remain technical. |
| AIKernel.Wasm | Aisthesis, Phantasia, Chronos, Kairos | WASM perception, scene, time, and trigger concept facades above interop. |
| AIKernel.Doom | Phantasia, Kairos, Chronos | Scenario-level visual semantics, autoplay timing, and replay windows. |
| AIKernel.Tools | Nomos, Chronos, Phantasia | Upper-level viewers and non-breaking CLI aliases. Parser and command infrastructure names remain technical. |

## Migration Strategy

### Add-Only Facades

Each implementation repository may add concept facades beside existing names.
Existing public APIs remain active.

### Minimal Internal Adoption

Only low-risk internal call sites may use concept facades. The initial adoption
is AIKernel.Tools `RomCommand` using `NomosViewer` for alias rendering while
keeping the command infrastructure name unchanged.

### Obsolete Candidate Review

No `[Obsolete]` attributes are applied in v0.1.1.1. Candidate surfaces are
recorded in the migration notes and must be reviewed before any later change.

### Future Removal

Removal of compatibility names is a v1.x or later discussion and is outside
the v0.1.1.1 scope.
Any future removal must be preceded by documented replacement surfaces,
migration examples, architecture-test coverage, and an explicit sunset period.

## Architecture Tests

Each implementation repository must contain architecture naming tests that fail
when philosophical prefixes are used on forbidden low-level type names.
Compatibility exceptions must be explicitly documented.

## Related Docs

- [Canonical Language Dictionary](../canonical-language/index.md)
- [Concept Elevation Guidelines](../guidelines/concept-elevation-guidelines.md)
- [Migration Notes](../migration/concept-elevation-v0.1.1.1.md)
- [Refactoring TODO](../todo/concept-elevation-refactoring-todo.md)
