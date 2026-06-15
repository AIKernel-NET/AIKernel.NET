---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Implementation Notes"
status: "Add-only implementation complete"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Concept Elevation Refactoring Migration Notes for v0.1.1.1

## Scope

This document prepares AIKernel v0.2.x Concept Elevation Refactoring while preserving the v0.1.1.1 compatibility boundary.
It records the add-only implementation completed for concept facades, repository-specific notes, CLI aliases, and architecture naming tests.

This document is ecosystem-wide, but the common vocabulary is maintained in AIKernel.NET as the canonical contract repository.

## Compatibility Policy

This migration is add-only in v0.1.1.1.
Existing public APIs must not be removed.
Existing method signatures must not change.
Existing DTO / enum / contract types must not be renamed.
Old technical names may remain as compatibility wrappers.

## What Changes

- Common concept vocabulary is documented in the Canonical Language Dictionary.
- Concept Elevation usage rules are documented before coding begins.
- Repository-by-repository migration ownership is recorded.
- Architecture naming tests prevent misuse of philosophical names on low-level technical types.
- Repository-specific concept notes are linked from each implementation repository.
- AIKernel.Tools exposes additive CLI aliases for ROM / Canon and timeline inspection.

## What Does Not Change

- CTG-ROM
- GateInput
- CouncilVoteValue
- GateDecisionKind
- TrajectoryGateDecisionKind
- RejectReasonKind
- CanonReference
- Decision Gate logic
- Trajectory Gate logic
- Existing DTO / enum / contract type names
- Existing public method signatures

## Repository-by-Repository Plan

### AIKernel.Core

Add concept facade / wrappers for:

- Telos
- Nomos
- Dike
- Ethos / Pathos / Logos council concepts

Do not rename GateInput, RejectReasonKind, DecisionGateResult, or any CTG contract.

### AIKernel.Control

Add concept facade / wrappers for:

- Kairos
- Nous

Do not rename ProviderVoteAdapter, CouncilDecisionBuilder, ControlRuntime, or ControlCoordinator.

### AIKernel.Providers

Use Ethos / Pathos / Logos only for council concept documentation or concept facade.
Do not rename ProviderManifest, ProviderRouter, ProviderRegistry, or concrete provider implementations.

### AIKernel.Wasm

Add concept facade / wrappers for:

- Aisthesis
- Phantasia
- Chronos
- Kairos

Do not rename WasmRuntime, WasmRuntimeContext, IWebAudioJsInterop, WebGpuComputeProvider, WasmAudioProvider, or WasmInputProvider.
AIKernel.Wasm may add Audio, Display, and Input boundary packages, but those packages must keep browser/WebAssembly concerns out of Core, Control, and Providers.
`AIKernel.Wasm.Compute` is the canonical WebGPU namespace; the former `AIKernel.Wasm.Comput` namespace remains only as a compatibility surface.

### AIKernel.Doom

Add concept facade / wrappers for:

- PhantasiaDoomScene
- KairosAutoPlayTrigger
- ChronosReplayWindow

Do not move Doom-specific providers into AIKernel.Providers.

### AIKernel.Tools

Add upper-level viewer names:

- NomosViewer
- ChronosViewer
- PhantasiaViewer

Do not rename low-level parser, serializer, DTO, or CLI infrastructure types.
Add CLI aliases without renaming command infrastructure:

- `aik rom view`
- `aik nomos view`
- `aik chronos timeline`
- `aik replay timeline`

`RomCommand` and `ClockCommand` remain the implementation class names.
`RomCommand` may use `NomosViewer` internally for alias rendering, but the command infrastructure name remains unchanged.

## CTG-ROM Safety Checklist

- [x] GateInput remains Logos / Ethos / Pathos vote-only carrier.
- [x] CouncilVoteValue remains Unknown / Approve / Abstain / Reject.
- [x] GateDecisionKind remains Allow / Deny.
- [x] TrajectoryGateDecisionKind remains Continue / Halt.
- [x] RejectReasonKind taxonomy is unchanged.
- [x] CanonReference structure is unchanged.
- [x] Decision Gate truth table is unchanged.
- [x] Trajectory Gate aggregation is unchanged.
- [x] No continuous values are introduced into GateInput.

## Obsolete Candidate Inventory

No `[Obsolete]` attributes are applied in v0.1.1.1.
The following names remain active compatibility surfaces and may be reviewed in a later migration:

| Repository | Compatibility surface | Candidate concept surface | v0.1.1.1 action |
| --- | --- | --- | --- |
| AIKernel.Core | Goal / Safety / Policy technical names | Telos / Dike / Nomos facades | Keep active |
| AIKernel.Control | ControlCoordinator / ControlRuntime / ProviderVoteAdapter / CouncilDecisionBuilder | Kairos / Nous facades where appropriate | Keep active |
| AIKernel.Providers | `EthosSemanticEvaluationProvider`, `PathosSemanticEvaluationProvider`, `LogosSemanticEvaluationProvider` | Council concept surfaces | Keep active as documented compatibility exceptions |
| AIKernel.Wasm | WasmRuntime / WasmRuntimeContext / WebGPU and JS interop names | Aisthesis / Phantasia / Chronos / Kairos facades | Keep active |
| AIKernel.Doom | DoomProvider / DoomWasm / Doom input and DTO names | Phantasia / Kairos / Chronos facades | Keep active |
| AIKernel.Tools | RomCommand / ClockCommand / parser / serializer names | Nomos / Chronos / Phantasia viewers | Keep active; add CLI aliases |

## Internal Adoption Notes

Internal adoption is intentionally minimal in v0.1.1.1.
Only low-risk call sites may use concept facades while preserving public names.
The initial internal adoption is AIKernel.Tools `RomCommand` using `NomosViewer`
to render additive aliases.
No Core Gate logic, CTG contract, provider implementation, DTO, mapper, adapter,
serializer, converter, or native bridge is migrated to philosophical naming.

## Future Removal Consideration

Compatibility-name removal is explicitly out of scope for v0.1.1.1.
The project may consider removal only in a later v1.x or higher compatibility
window, and only after all of the following are true:

- the old technical name has an active replacement documented in the canonical
  language dictionary or repository-specific concept notes
- migration examples exist for each affected repository
- architecture naming tests enforce the replacement boundary
- CTG-ROM, GateInput, governance DTOs, enums, and gate logic remain unchanged
- users have had a documented sunset period

Until those conditions are met, compatibility names remain valid public
surfaces. No deletion, rename, or `[Obsolete]` attribute is applied by this
v0.1.1.1 work.

## Migration Phases

### P0 Documentation Baseline

Create common ecosystem documentation in AIKernel.NET and link it from the canonical README.

### P1 Repository Inventory

Each implementation repository lists candidate concept facades and forbidden rename targets.

### P2 Architecture Test Plan

Each implementation repository adds architecture test plans that reject philosophical prefixes on DTO, Request, Result, Mapper, Adapter, Serializer, Converter, HttpClient, JSInterop, NativeBridge, and provider implementation classes.

### P3 Add-only Concept Facades

Concept facades may be added only after the repository-specific plan is reviewed.
Existing names remain available.

### P4 Compatibility Wrappers

Old technical names may remain as wrappers where required for v0.1.x compatibility.

### P5 v0.2.x Review Gate

Before v0.2.x implementation begins, all repositories must confirm that CTG-ROM and canonical governance contracts remain unchanged.
