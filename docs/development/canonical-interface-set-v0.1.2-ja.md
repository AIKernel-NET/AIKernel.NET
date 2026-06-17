---
updated: 2026-06-16
published: 2026-06-16
version: "0.1.2-dev0"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# 正典 Interface Set v0.1.2

この note は、AIKernel.NET に追加した v0.1.2 正典 Interface 抽出結果を記録します。
対象は `src/AIKernel.Abstractions`、`src/AIKernel.Dtos`、
`src/AIKernel.Enums` の契約ファイルです。

## 全体構造

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
- `AIKernel.Abstractions.Governance.ICtgCanon`
- `AIKernel.Abstractions.Governance.ICtgRuleset`
- `AIKernel.Abstractions.Governance.ICtgDecisionGate`

### Provider Surface

既存の provider / query contract は正典として維持します。

- `AIKernel.Abstractions.Providers.IModelProvider`
- `AIKernel.Abstractions.Providers.IEmbeddingProvider`
- `AIKernel.Abstractions.Query.IQueryAugmentor`
- `AIKernel.Abstractions.Query.IQueryDecomposer`
- `AIKernel.Abstractions.Query.IQueryRouter`

v0.1.2 では modality carrier を追加します。

- `AIKernel.Abstractions.Providers.IVisionProvider`
- `AIKernel.Abstractions.Providers.IAudioProvider`

### Runtime Surface

- `AIKernel.Abstractions.Runtime.IWasmRuntime`
- `AIKernel.Abstractions.Runtime.IWasmBuffer`
- `AIKernel.Abstractions.Runtime.IWasmExecutionContext`

これらは portable WebAssembly execution boundary を記述します。browser、
JavaScript、WebGPU、host 実装型は公開しません。

### Scenario Surface

prompt 例では Doom 固有名が使われていましたが、正典 package では scenario-neutral に
抽象化します。

- `IDoomPerception` は `AIKernel.Abstractions.Scenarios.IScenarioPerception` に写像します。
- `IDoomActionEmitter` は `AIKernel.Abstractions.Scenarios.IScenarioActionEmitter` に写像します。
- `IDoomRuntimeStatus` は `AIKernel.Abstractions.Scenarios.IScenarioRuntimeStatus` に写像します。
- `IDoomHudState` は `AIKernel.Abstractions.Scenarios.IScenarioHudState` に写像します。

door 名、corridor score、window、enemy、map route landmark などの Doom 固有 symbol は
AIKernel.Doom に閉じます。

## DTO / Snapshot / Carrier

- `AIKernel.Dtos.Cognition.CognitiveContracts`
- `AIKernel.Dtos.Runtime.WasmRuntimeContracts`
- `AIKernel.Dtos.Scenarios.ScenarioContracts`

主な v0.1.2 carrier:

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

Result として使われる snapshot / carrier は optional failure envelope を持ちます。

- `bool? Succeeded`
- `string? ErrorCode`
- `string? ErrorMessage`
- `DiagnosticInfo? Diagnostics`

## Enum

- `AIKernel.Enums.Cognition.CognitionEnums`

追加 enum はすべて `Unknown = 0` を持ちます。

## 境界ルール

- Aisthesis は感覚状態だけを取得します。
- Phantasia は表象だけを構築します。
- Nous は状況ラベルだけを検出します。
- Telos は goal / objective / priority carrier だけを提案します。
- Topos は観測ベクトルを合成しますが、CTG Gate を置き換えません。
- CTG interface は vote、canon reference、gate result だけを保持します。
- Kairos は timing window だけをスケジュールします。
- Kinesis は抽象 action だけを発行します。
- Chronos は trace だけを記録します。
- Scenario interface は scenario-specific vocabulary を持ちません。

## v0.1.1.1 から v0.1.2 への差分

- 正典 cognition pipeline surface を追加しました。
- Topos triadic vector interface と carrier を追加しました。
- 既存 v0.1.1.1 CTG DTO の横に CTG carrier interface を追加しました。
- vision / audio provider abstraction を追加しました。
- portable WebAssembly runtime abstraction を追加しました。
- Doom 固有の正典名ではなく scenario-neutral demo abstraction を追加しました。
- 既存 public API signature は変更していません。
- CTG GateInput の vote-only semantics は維持しています。
