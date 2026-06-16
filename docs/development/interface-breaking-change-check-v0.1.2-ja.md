---
updated: 2026-06-16
published: 2026-06-16
version: "0.1.2-dev0"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Interface Breaking Change Check v0.1.2

この文書は、0.1.2 package line を公開する前に、v0.1.2 正典 interface の
破壊的変更判定を固定するためのものです。参照対象は AIKernel.Core、
AIKernel.Control、AIKernel.Providers、AIKernel.Tools、AIKernel.Wasm、
AIKernel.Doom ですが、AIKernel.NET に昇格する対象は contract-level surface
だけです。

## 結論

安定版 v0.1.1 の AIKernel.NET public API に対して、破壊的変更は不要です。

v0.1.2 の正典 surface は横追加です。

- 既存 v0.1.1 public type 名は維持します。
- 既存 v0.1.1 method signature はこの review では変更しません。
- cognition、Topos、CTG carrier、runtime、provider、scenario contract は新規 public type として追加します。
- Doom 固有、browser 固有の implementation contract は AIKernel.NET 正典 surface に入れません。

公開前の pre-release 命名整理として、次の統一だけを行いました。

- `ICTGCanon` -> `ICtgCanon`
- `ICTGRuleset` -> `ICtgRuleset`
- `ICTGDecisionGate` -> `ICtgDecisionGate`

これは all-caps 名が local v0.1.2 development surface にのみ存在していたため、
安定版 v0.1.1 に対する破壊的変更ではありません。

## 判定方法

- 現在の AIKernel.NET public type set を `v0.1.1` tag と比較しました。
- 機械 scan で出た削除候補は、positional record の整形に起因する parser artifact であり、該当 source record は現行 tree に残っていることを確認しました。
- 実装リポジトリ横断の implementation-specific interface を確認し、scenario-neutral な語彙だけを正典抽象へ写像しました。
- implementation logic、棚卸し Category C の旧 logic、WebGPU/WebAudio details、Doom route 名、provider 実装詳細は AIKernel.NET から除外しました。

## Interface ごとの判定

### Cognition Pipeline

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IAisthesis` | No | sensory capture 用の新規横追加 interface です。 | 既存 API を変えず opt-in 実装できます。 |
| `IPhantasia` | No | representation 用の新規横追加 interface です。 | 既存 caller に移行を強制しません。 |
| `INous` | No | cognition label / hint 用の新規横追加 interface です。 | 既存 evaluator を置き換えません。 |
| `ITelos` | No | TELOS/OBJECTIVE/PRIORITY proposal 用の新規横追加 interface です。 | 既存 policy interface は維持します。 |
| `IKairosScheduler` | No | timing window 用の新規横追加 interface です。 | gate や action logic を所有しません。 |
| `IKinesisActuator` | No | abstract action emission 用の新規横追加 interface です。 | scenario-specific input emitter は local adapter に残します。 |
| `IChronosRecorder` | No | chronological trace 用の新規横追加 interface です。 | 既存 replay interface は維持します。 |
| `ISemanticMemory` | No | semantic memory snapshot 用の新規横追加 interface です。 | 既存 memory store は adapter で接続できます。 |
| `IPhaseInference` | No | phase inference 用の新規横追加 interface です。 | scenario-specific phase rule は AIKernel.NET に入れません。 |
| `IObjectiveInference` | No | objective inference 用の新規横追加 interface です。 | 既存 Control policy は rename しません。 |

### Topos / Triadic Vector

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `ILogosVector` | No | vector contribution 用の新規横追加 interface です。 | 既存 vector API は削除しません。 |
| `IPathosVector` | No | vector contribution 用の新規横追加 interface です。 | gate や reject reason logic は複製しません。 |
| `IEthosVector` | No | vector contribution 用の新規横追加 interface です。 | purpose scoring は carrier-level に留めます。 |
| `IDecisionVector` | No | vector composition 用の新規横追加 interface です。 | 観測 carrier を合成し、CTG gate は置き換えません。 |
| `IToposEvaluator` | No | Topos carrier evaluation 用の新規横追加 interface です。 | 実装側は既存 Control API を変えず adapter で接続します。 |

### CTG Carrier Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `ICouncilVote` | No | vote carrier production 用の新規横追加 interface です。 | gate decision は生成しません。 |
| `ICtgCanon` | No | 公開前に既存 `Ctg*` DTO と casing を揃えた新規 interface です。 | pre-release の `ICTGCanon` 利用箇所だけ rename します。 |
| `ICtgRuleset` | No | 公開前に既存 `Ctg*` DTO と casing を揃えた新規 interface です。 | pre-release の `ICTGRuleset` 利用箇所だけ rename します。 |
| `ICtgDecisionGate` | No | 公開前に既存 `Ctg*` DTO と casing を揃えた新規 interface です。 | pre-release の `ICTGDecisionGate` 利用箇所だけ rename します。 |

### Provider Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IModelProvider` | No | 既存 interface を維持します。 | 移行不要です。 |
| `IEmbeddingProvider` | No | 既存 interface を維持します。 | 移行不要です。 |
| `IQueryAugmentor` | No | 既存 interface を維持します。 | 移行不要です。 |
| `IQueryDecomposer` | No | 既存 interface を維持します。 | 移行不要です。 |
| `IQueryRouter` | No | 既存 interface を維持します。 | 移行不要です。 |
| `IVisionProvider` | No | modality provider の新規横追加です。 | 既存 perception provider を wrapper で接続できます。 |
| `IAudioProvider` | No | modality provider の新規横追加です。 | 既存 audio provider を wrapper で接続できます。 |

### Runtime Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IWasmRuntime` | No | portable runtime abstraction の新規横追加です。 | AIKernel.Wasm の実装 local runtime は adapter 追加まで維持します。 |
| `IWasmBuffer` | No | portable buffer abstraction の新規横追加です。 | browser / WebGPU details は AIKernel.NET に出しません。 |
| `IWasmExecutionContext` | No | portable execution context abstraction の新規横追加です。 | host-specific context は AIKernel.Wasm に残します。 |

### Scenario Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IScenarioPerception` | No | prompt-level `IDoomPerception` の scenario-neutral replacement です。 | Doom-specific perception adapter は AIKernel.Doom に残します。 |
| `IScenarioActionEmitter` | No | prompt-level `IDoomActionEmitter` の scenario-neutral replacement です。 | Doom input mapping は AIKernel.Doom に残します。 |
| `IScenarioRuntimeStatus` | No | prompt-level `IDoomRuntimeStatus` の scenario-neutral replacement です。 | Doom runtime status は neutral DTO へ project します。 |
| `IScenarioHudState` | No | prompt-level `IDoomHudState` の scenario-neutral replacement です。 | Doom HUD details は scenario-local に残します。 |

## DTO / Snapshot / Carrier 判定

| Type Family | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| Cognition DTOs | No | 新規 `AIKernel.Dtos.Cognition` record です。 | 既存 DTO constructor は変更しません。 |
| Runtime DTOs | No | 新規 `AIKernel.Dtos.Runtime` WebAssembly record です。 | host-specific DTO は正典 surface 外に置きます。 |
| Scenario DTOs | No | 新規 `AIKernel.Dtos.Scenarios` record です。 | Doom 固有 field は昇格しません。 |
| Cognition enums | No | `Unknown = 0` を持つ新規 `AIKernel.Enums.Cognition` enum です。 | 既存 enum value は rename / delete しません。 |

## Migration Guide: pre-release CTG casing 統一

### Why

all-caps の `ICTG*` interface 名は、既存の `CtgDecisionGateRequest`、
`CtgDecisionGateResult`、`ICtgGovernanceService` などの `Ctg` naming と
一致していませんでした。両方を残すと正典 debt になるため、公開前に統一します。

### What Changed

| Before | After |
| --- | --- |
| `ICTGCanon` | `ICtgCanon` |
| `ICTGRuleset` | `ICtgRuleset` |
| `ICTGDecisionGate` | `ICtgDecisionGate` |

### Migration Steps

1. `ICTGCanon` を `ICtgCanon` に置換します。
2. `ICTGRuleset` を `ICtgRuleset` に置換します。
3. `ICTGDecisionGate` を `ICtgDecisionGate` に置換します。
4. method call と DTO usage は変更しません。

### Before / After

```csharp
// Before
public sealed class CanonReader : ICTGCanon
{
}

// After
public sealed class CanonReader : ICtgCanon
{
}
```

## Migration Guide: Doom prompt 名から scenario-neutral contract へ

### Why

v0.1.2 正典 interface package には Doom 固有名を入れません。
scenario-specific vocabulary は AIKernel.Doom の責務です。正典 surface は他の demo
でも実装できる scenario-neutral contract にします。

### What Changed

| Prompt Name | Canonical Name |
| --- | --- |
| `IDoomPerception` | `IScenarioPerception` |
| `IDoomActionEmitter` | `IScenarioActionEmitter` |
| `IDoomRuntimeStatus` | `IScenarioRuntimeStatus` |
| `IDoomHudState` | `IScenarioHudState` |

### Migration Steps

1. Doom-specific detection と route label は AIKernel.Doom に閉じます。
2. Doom state を `ScenarioPerceptionSnapshot`、`ScenarioActionRequest`、
   `ScenarioRuntimeStatus`、`ScenarioHudState` へ project します。
3. scenario-neutral interface は adapter boundary だけで実装します。

### Before / After

```csharp
// Before
public interface IDoomPerception
{
    ValueTask<DoomPerceptionSnapshot> SenseAsync(CancellationToken cancellationToken);
}

// After
public sealed class DoomScenarioPerceptionAdapter : IScenarioPerception
{
    public ValueTask<ScenarioPerceptionSnapshot> CaptureAsync(
        ScenarioPerceptionRequest request,
        CancellationToken cancellationToken);
}
```

## 安定理由

- 正典追加は opt-in であり、既存実装に member 追加を要求しません。
- result-like record の optional failure envelope は v0.1.2 の新規 carrier surface に閉じます。
- 新規 enum は `Unknown = 0` を持ち、既存 enum value を rename / delete しません。
- Provider は capability adapter として維持し、SDK wrapper や scenario runtime は AIKernel.NET に入れません。
- Core / Control の実装責務は維持し、AIKernel.NET は contract のみを定義します。

