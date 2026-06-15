---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Pre-coding"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel Concept Elevation Guidelines

## Purpose

Concept Elevation Refactoring promotes technical responsibilities into stable concept-layer names.
It aligns AIKernel's philosophy, responsibility boundaries, type system, and implementation structure.

Concept Elevation Refactoring は、単なるクラス名変更ではなく、
技術的責務を安定した概念層の名前へ昇格するためのリファクタリングである。
AIKernel の思想、責務境界、型システム、実装構造を一致させることを目的とする。

## Non-goals

This refactoring must not change:

- CTG-ROM
- GateInput
- CouncilVoteValue
- GateDecisionKind
- TrajectoryGateDecisionKind
- RejectReasonKind
- CanonReference
- Decision Gate logic
- Trajectory Gate logic

この refactoring は上記の canonical governance contract、ROM、gate logic を変更しない。

## Concept Elevation Is Not Rename

Concept Elevation is not a broad rename campaign.
It is an explicit design step that promotes a stable responsibility into a concept-layer name only when the name carries semantic weight.

Concept Elevation は広範な rename 作業ではない。
安定した責務が意味論的な重みを持つ場合に限り、概念層の名前へ昇格する設計手順である。

## Core Rules

Rule 1: Philosophical terms are only for concept layers.

Rule 2: DTO / Request / Result types must not use philosophical prefixes.

Rule 3: Mapper / Adapter / Serializer / Converter types must not use philosophical prefixes.

Rule 4: Provider implementation types must not use philosophical prefixes.

Rule 5: Concept names must carry conceptual weight.

Rule 6: Every philosophical term must be registered in the Canonical Language Dictionary.

Rule 7: Naming rules must be enforced by architecture tests.

## Allowed Layers

- Governance
- Trajectory
- Perception
- Intent
- Latent
- Stability
- Canonical
- Concept facade
- Viewer / Inspector upper-level concept names

## Forbidden Layers

- DTO
- Request
- Result
- Mapper
- Adapter
- Serializer
- Converter
- HttpClient
- JSInterop
- NativeBridge
- Provider implementation
- low-level I/O

## Concept Weight Rule

A type with a philosophical name must represent a meaningful concept with state, behavior, or semantic responsibility.
A philosophical name must not be used for a thin boolean flag, trivial DTO, or mechanical wrapper.

哲学語を持つ型は、状態・振る舞い・意味論的責務のいずれかを持つ概念型でなければならない。
単なる bool、薄い DTO、機械的 wrapper に哲学語を使ってはならない。

## CTG-ROM Safety Rule

Concept Elevation must not alter CTG-ROM, Monolith-ROM, council vote values, decision gate truth tables, trajectory gate aggregation, rejection taxonomy, or canon reference structure.

Concept Elevation は CTG-ROM、Monolith-ROM、council vote value、decision gate truth table、trajectory gate aggregation、rejection taxonomy、canon reference structure を変更しない。

## XML Documentation Rule

Public concept-layer members that use philosophical terms must explain the term in bilingual documentation.
The documentation must identify the concept layer, old technical name, and forbidden usage boundary.

Example:

```csharp
/// <summary>
/// 【知覚層 - Aisthesis】
/// GUI / sensor / runtime surface からの raw observation を扱う概念層。
/// Old technical name: Observation.
/// DTO / Mapper / Provider implementation にはこの語を使用しない。
/// </summary>
public interface IAisthesisObservationSource
{
}
```

## Architecture Test Rule

Architecture tests must fail if philosophical prefixes appear on DTO, Request, Result, Mapper, Adapter, Serializer, Converter, HttpClient, JSInterop, NativeBridge, or provider implementation classes.

Architecture tests should also verify that every philosophical prefix used in code is registered in the Canonical Language Dictionary.

## Repository Application Scope

The common vocabulary is maintained in AIKernel.NET because it is the canonical contract repository.
Repository-specific migration notes and architecture tests belong to each implementation repository.

Initial implementation repositories:

- AIKernel.Core
- AIKernel.Control
- AIKernel.Providers
- AIKernel.Wasm
- AIKernel.Doom
- AIKernel.Tools

AIKernel.NET is not a breaking-change target for Concept Elevation.
It may reference CTG canonical terms such as Ethos, Pathos, and Logos, but existing contracts must remain stable.
