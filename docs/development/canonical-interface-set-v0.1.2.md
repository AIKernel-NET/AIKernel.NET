---
updated: 2026-06-16
published: 2026-06-16
version: "0.1.2-dev0"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Canonical Interface Set v0.1.2

This note records the v0.1.2 canonical interface extraction added to
AIKernel.NET. It is a developer map for the contract files under
`src/AIKernel.Abstractions`, `src/AIKernel.Dtos`, and `src/AIKernel.Enums`.

## Structure

### Cognition Pipeline

- `AIKernel.Abstractions.Cognition.IAisthesis`
- `AIKernel.Abstractions.Cognition.IPhantasia`
- `AIKernel.Abstractions.Cognition.INous`
- `AIKernel.Abstractions.Cognition.ITelos`
- `AIKernel.Abstractions.Cognition.IKairosScheduler`
- `AIKernel.Abstractions.Cognition.IKinesisActuator`
- `AIKernel.Abstractions.Cognition.IChronosRecorder`
- `AIKernel.Abstractions.Cognition.ISemanticMemory`
- `AIKernel.Abstractions.Cognition.IPhaseInference`
- `AIKernel.Abstractions.Cognition.IObjectiveInference`

### Topos / Triadic Vector Surface

- `AIKernel.Abstractions.Topos.ILogosVector`
- `AIKernel.Abstractions.Topos.IPathosVector`
- `AIKernel.Abstractions.Topos.IEthosVector`
- `AIKernel.Abstractions.Topos.IDecisionVector`
- `AIKernel.Abstractions.Topos.IToposEvaluator`

### CTG Carrier Surface

- `AIKernel.Abstractions.Governance.ICouncilVote`
- `AIKernel.Abstractions.Governance.ICTGCanon`
- `AIKernel.Abstractions.Governance.ICTGRuleset`
- `AIKernel.Abstractions.Governance.ICTGDecisionGate`

### Provider Surface

Existing provider/query contracts remain canonical:

- `AIKernel.Abstractions.Providers.IModelProvider`
- `AIKernel.Abstractions.Providers.IEmbeddingProvider`
- `AIKernel.Abstractions.Query.IQueryAugmentor`
- `AIKernel.Abstractions.Query.IQueryDecomposer`
- `AIKernel.Abstractions.Query.IQueryRouter`

v0.1.2 adds modality carriers:

- `AIKernel.Abstractions.Providers.IVisionProvider`
- `AIKernel.Abstractions.Providers.IAudioProvider`

### Runtime Surface

- `AIKernel.Abstractions.Runtime.IWasmRuntime`
- `AIKernel.Abstractions.Runtime.IWasmBuffer`
- `AIKernel.Abstractions.Runtime.IWasmExecutionContext`

These interfaces describe a portable WebAssembly execution boundary. They do
not expose browser, JavaScript, WebGPU, or host implementation types.

### Scenario Surface

The prompt examples used Doom-specific names. The canonical package keeps the
contract surface scenario-neutral:

- `IDoomPerception` maps to `AIKernel.Abstractions.Scenarios.IScenarioPerception`
- `IDoomActionEmitter` maps to `AIKernel.Abstractions.Scenarios.IScenarioActionEmitter`
- `IDoomRuntimeStatus` maps to `AIKernel.Abstractions.Scenarios.IScenarioRuntimeStatus`
- `IDoomHudState` maps to `AIKernel.Abstractions.Scenarios.IScenarioHudState`

Doom-specific symbols such as door names, corridor scores, windows, enemies, or
map route landmarks stay in AIKernel.Doom.

## DTO / Snapshot / Carrier Files

- `AIKernel.Dtos.Cognition.CognitiveContracts`
- `AIKernel.Dtos.Runtime.WasmRuntimeContracts`
- `AIKernel.Dtos.Scenarios.ScenarioContracts`

The main v0.1.2 carriers are:

- `AisthesisSnapshot`
- `PhantasiaSnapshot`
- `NousSnapshot`
- `TelosProposal`
- `ToposCarrier`
- `KairosState`
- `KinesisAction`
- `ChronosTrace`
- `SemanticMemorySnapshot`
- `CouncilVoteSnapshot`

Result-like snapshots include the optional failure envelope:

- `bool? Succeeded`
- `string? ErrorCode`
- `string? ErrorMessage`
- `DiagnosticInfo? Diagnostics`

## Enum Files

- `AIKernel.Enums.Cognition.CognitionEnums`

All added enums include `Unknown = 0`.

## Boundary Rules

- Aisthesis captures sensory state only.
- Phantasia builds representation only.
- Nous detects situation labels only.
- Telos proposes goal/objective/priority carriers only.
- Topos composes observed vectors but does not replace CTG gates.
- CTG interfaces carry votes, canon references, and gate results only.
- Kairos schedules timing windows only.
- Kinesis emits abstract actions only.
- Chronos records traces only.
- Scenario interfaces do not contain scenario-specific vocabulary.

## v0.1.1.1 to v0.1.2 Delta

- Added a canonical cognition pipeline surface.
- Added Topos triadic vector interfaces and carriers.
- Added CTG carrier interfaces beside the existing v0.1.1.1 CTG DTOs.
- Added vision/audio provider abstractions.
- Added portable WebAssembly runtime abstractions.
- Added scenario-neutral demo abstractions instead of Doom-specific canonical names.
- Preserved existing public API signatures.
- Preserved vote-only CTG GateInput semantics.
