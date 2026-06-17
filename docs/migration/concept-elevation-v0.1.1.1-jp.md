---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Implementation Notes"
status: "Add-only implementation complete"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
lang: ja
title: "Concept Elevation Refactoring Migration Notes for v0.1.1.1"
description: "AIKernel v0.1.1.1 の互換性境界を保ちながら Concept Elevation Refactoring を準備するための migration notes です。"
---

# Concept Elevation Refactoring Migration Notes for v0.1.1.1

## 範囲

この文書は、AIKernel v0.2.x の Concept Elevation Refactoring に備えつつ、v0.1.1.1 の互換性境界を維持するための記録です。
concept facades、リポジトリ固有の注意点、CLI aliases、architecture naming tests について、add-only implementation として完了した内容を整理します。

対象は ecosystem 全体ですが、共通語彙は canonical contract repository である AIKernel.NET に維持します。

## Compatibility Policy

v0.1.1.1 における migration は add-only です。
既存の public APIs は削除しません。
既存の method signatures は変更しません。
既存の DTO / enum / contract types は rename しません。
旧技術名は compatibility wrappers として残せます。

## 変更されること

- Common concept vocabulary を Canonical Language Dictionary に文書化します。
- coding 前に Concept Elevation の使用ルールを文書化します。
- repository-by-repository の migration ownership を記録します。
- Architecture naming tests により、low-level technical types への哲学語の誤用を防ぎます。
- 各 implementation repository から repository-specific concept notes へリンクします。
- AIKernel.Tools は ROM / Canon と timeline inspection の additive CLI aliases を公開します。

## 変更されないこと

- CTG-ROM
- GateInput
- CouncilVoteValue
- GateDecisionKind
- TrajectoryGateDecisionKind
- RejectReasonKind
- CanonReference
- Decision Gate logic
- Trajectory Gate logic
- 既存 DTO / enum / contract type names
- 既存 public method signatures

## Repository-by-Repository Plan

### AIKernel.Core

次の concept facade / wrappers を追加します。

- Telos
- Nomos
- Dike
- Ethos / Pathos / Logos council concepts

GateInput、RejectReasonKind、DecisionGateResult、その他 CTG contract は rename しません。

### AIKernel.Control

次の concept facade / wrappers を追加します。

- Kairos
- Nous

ProviderVoteAdapter、CouncilDecisionBuilder、ControlRuntime、ControlCoordinator は rename しません。

### AIKernel.Providers

Ethos / Pathos / Logos は council concept documentation または concept facade の用途に限定します。
ProviderManifest、ProviderRouter、ProviderRegistry、concrete provider implementations は rename しません。

### AIKernel.Wasm

次の concept facade / wrappers を追加します。

- Aisthesis
- Phantasia
- Chronos
- Kairos

WasmRuntime、WasmRuntimeContext、IWebAudioJsInterop、WebGpuComputeProvider、WasmAudioProvider、WasmInputProvider は rename しません。
AIKernel.Wasm は Audio、Display、Input boundary packages を追加できますが、それらの browser/WebAssembly concern を Core、Control、Providers に持ち込みません。
`AIKernel.Wasm.Compute` が canonical WebGPU namespace です。旧 `AIKernel.Wasm.Comput` namespace は compatibility surface としてのみ残します。

### AIKernel.Doom

次の concept facade / wrappers を追加します。

- PhantasiaDoomScene
- KairosAutoPlayTrigger
- ChronosReplayWindow

Doom-specific providers は AIKernel.Providers に移動しません。

### AIKernel.Tools

次の upper-level viewer names を追加します。

- NomosViewer
- ChronosViewer
- PhantasiaViewer

low-level parser、serializer、DTO、CLI infrastructure types は rename しません。
command infrastructure を rename せず、次の CLI aliases を追加します。

- `aik rom view`
- `aik nomos view`
- `aik chronos timeline`
- `aik replay timeline`

`RomCommand` と `ClockCommand` は implementation class names として残します。
`RomCommand` は alias rendering の内部で `NomosViewer` を使えますが、command infrastructure name は変えません。

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

v0.1.1.1 では `[Obsolete]` attributes を適用しません。
次の名前は active compatibility surfaces として残り、後続 migration で見直す候補です。

| Repository | Compatibility surface | Candidate concept surface | v0.1.1.1 action |
| --- | --- | --- | --- |
| AIKernel.Core | Goal / Safety / Policy technical names | Telos / Dike / Nomos facades | Keep active |
| AIKernel.Control | ControlCoordinator / ControlRuntime / ProviderVoteAdapter / CouncilDecisionBuilder | Kairos / Nous facades where appropriate | Keep active |
| AIKernel.Providers | `EthosSemanticEvaluationProvider`, `PathosSemanticEvaluationProvider`, `LogosSemanticEvaluationProvider` | Council concept surfaces | Keep active as documented compatibility exceptions |
| AIKernel.Wasm | WasmRuntime / WasmRuntimeContext / WebGPU and JS interop names | Aisthesis / Phantasia / Chronos / Kairos facades | Keep active |
| AIKernel.Doom | DoomProvider / DoomWasm / Doom input and DTO names | Phantasia / Kairos / Chronos facades | Keep active |
| AIKernel.Tools | RomCommand / ClockCommand / parser / serializer names | Nomos / Chronos / Phantasia viewers | Keep active; add CLI aliases |

## Internal Adoption Notes

v0.1.1.1 では internal adoption を意図的に最小限にします。
public names を維持したまま、低リスクな call sites だけが concept facades を使用できます。
初期の internal adoption は、AIKernel.Tools の `RomCommand` が additive aliases の rendering に `NomosViewer` を使用する範囲です。

Core Gate logic、CTG contract、provider implementation、DTO、mapper、adapter、serializer、converter、native bridge は哲学語 naming へ移行しません。

## Future Removal Consideration

Compatibility-name removal は v0.1.1.1 の範囲外です。
削除を検討できるのは、将来の v1.x 以上の compatibility window において、次の条件がすべて満たされた後に限ります。

- old technical name の active replacement が canonical language dictionary または repository-specific concept notes に記録されている
- 影響を受ける各 repository について migration examples がある
- architecture naming tests が replacement boundary を強制している
- CTG-ROM、GateInput、governance DTOs、enums、gate logic が変わっていない
- users に documented sunset period が提供されている

条件が満たされるまで、compatibility names は有効な public surfaces として残ります。
この v0.1.1.1 作業では、削除、rename、`[Obsolete]` attribute の適用はいずれも行いません。

## Migration Phases

### P0 Documentation Baseline

AIKernel.NET に common ecosystem documentation を作成し、canonical README からリンクします。

### P1 Repository Inventory

各 implementation repository は、candidate concept facades と forbidden rename targets を列挙します。

### P2 Architecture Test Plan

各 implementation repository は、DTO、Request、Result、Mapper、Adapter、Serializer、Converter、HttpClient、JSInterop、NativeBridge、provider implementation classes に哲学語 prefix が出た場合に拒否する architecture test plan を追加します。

### P3 Add-only Concept Facades

Concept facades は、repository-specific plan の review 後にのみ追加できます。
既存名は引き続き利用できます。

### P4 Compatibility Wrappers

v0.1.x compatibility に必要な場合、旧技術名は wrappers として残せます。

### P5 v0.2.x Review Gate

v0.2.x implementation を始める前に、すべての repository は CTG-ROM と canonical governance contracts が変更されていないことを確認します。
