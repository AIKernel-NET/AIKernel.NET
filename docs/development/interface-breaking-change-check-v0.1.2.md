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

This document fixes the v0.1.2 canonical interface review result before the
0.1.2 package line is published. The review covered AIKernel.Core,
AIKernel.Control, AIKernel.Providers, AIKernel.Tools, AIKernel.Wasm, and
AIKernel.Doom as source repositories, but only contract-level surfaces were
eligible for AIKernel.NET.

## Result

No breaking change is required for the stable v0.1.1 AIKernel.NET public API.

The v0.1.2 canonical surface is added laterally:

- Existing v0.1.1 public type names remain present.
- Existing v0.1.1 method signatures are not intentionally changed by this
  review.
- New cognition, Topos, CTG carrier, runtime, provider, and scenario contracts
  are new public types.
- Doom-specific and browser-specific implementation contracts stay outside the
  canonical AIKernel.NET surface.

One pre-release naming consolidation was applied before publication:

- `ICTGCanon` -> `ICtgCanon`
- `ICTGRuleset` -> `ICtgRuleset`
- `ICTGDecisionGate` -> `ICtgDecisionGate`

This is not a stable v0.1.1 breaking change because the all-caps names existed
only in the local v0.1.2 development surface.

## Review Method

- Compared the current AIKernel.NET public type set against the `v0.1.1` tag.
- Verified that candidate removals from the mechanical scan were parser
  artifacts caused by positional record formatting; the corresponding source
  records are still present.
- Reviewed cross-repository implementation-specific interfaces and mapped them
  to canonical abstractions only when the vocabulary was scenario-neutral.
- Kept implementation logic, old inventory Category C logic, WebGPU/WebAudio
  details, Doom route names, and provider implementation details out of
  AIKernel.NET.

## Interface Decision List

### Cognition Pipeline

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IAisthesis` | No | New lateral interface for sensory capture. | Implementations may opt in without changing existing APIs. |
| `IPhantasia` | No | New lateral interface for representation. | No existing caller is forced to migrate. |
| `INous` | No | New lateral interface for cognition labels and hints. | Does not replace any existing evaluator. |
| `ITelos` | No | New lateral interface for TELOS/OBJECTIVE/PRIORITY proposals. | Existing policy interfaces remain intact. |
| `IKairosScheduler` | No | New lateral interface for timing windows. | Does not own gate or action logic. |
| `IKinesisActuator` | No | New lateral interface for abstract action emission. | Scenario-specific input emitters remain local adapters. |
| `IChronosRecorder` | No | New lateral interface for chronological traces. | Existing replay interfaces remain intact. |
| `ISemanticMemory` | No | New lateral interface for semantic memory snapshots. | Implementations can bridge existing memory stores. |
| `IPhaseInference` | No | New lateral interface for phase inference. | Scenario-specific phase rules stay outside AIKernel.NET. |
| `IObjectiveInference` | No | New lateral interface for objective inference. | Existing Control policies are not renamed. |

### Topos / Triadic Vectors

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `ILogosVector` | No | New lateral vector contribution interface. | No existing vector API is removed. |
| `IPathosVector` | No | New lateral vector contribution interface. | No gate or reject reason logic is duplicated. |
| `IEthosVector` | No | New lateral vector contribution interface. | Purpose scoring stays carrier-level. |
| `IDecisionVector` | No | New lateral vector composition interface. | It composes observed carriers and does not replace CTG gates. |
| `IToposEvaluator` | No | New lateral interface for Topos carrier evaluation. | Implementations adapt rather than changing existing Control APIs. |

### CTG Carrier Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `ICouncilVote` | No | New lateral interface for vote carrier production. | It does not generate gate decisions. |
| `ICtgCanon` | No | New lateral interface; casing aligned with existing `Ctg*` DTOs before publication. | Pre-release users of `ICTGCanon` should rename. |
| `ICtgRuleset` | No | New lateral interface; casing aligned with existing `Ctg*` DTOs before publication. | Pre-release users of `ICTGRuleset` should rename. |
| `ICtgDecisionGate` | No | New lateral interface; casing aligned with existing `Ctg*` DTOs before publication. | Pre-release users of `ICTGDecisionGate` should rename. |

### Provider Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IModelProvider` | No | Existing interface preserved. | No migration required. |
| `IEmbeddingProvider` | No | Existing interface preserved. | No migration required. |
| `IQueryAugmentor` | No | Existing interface preserved. | No migration required. |
| `IQueryDecomposer` | No | Existing interface preserved. | No migration required. |
| `IQueryRouter` | No | Existing interface preserved. | No migration required. |
| `IVisionProvider` | No | New lateral modality provider. | Implementations can wrap existing perception providers. |
| `IAudioProvider` | No | New lateral modality provider. | Implementations can wrap existing audio providers. |

### Runtime Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IWasmRuntime` | No | New portable runtime abstraction. | AIKernel.Wasm keeps its implementation-local runtime interface until adapters are added. |
| `IWasmBuffer` | No | New portable buffer abstraction. | Browser/WebGPU details remain outside AIKernel.NET. |
| `IWasmExecutionContext` | No | New portable execution context abstraction. | Host-specific context stays in AIKernel.Wasm. |

### Scenario Surface

| Interface | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| `IScenarioPerception` | No | New scenario-neutral replacement for prompt-level `IDoomPerception`. | Doom-specific perception adapters remain in AIKernel.Doom. |
| `IScenarioActionEmitter` | No | New scenario-neutral replacement for prompt-level `IDoomActionEmitter`. | Doom input mapping remains in AIKernel.Doom. |
| `IScenarioRuntimeStatus` | No | New scenario-neutral replacement for prompt-level `IDoomRuntimeStatus`. | Doom runtime status can be projected into the neutral DTO. |
| `IScenarioHudState` | No | New scenario-neutral replacement for prompt-level `IDoomHudState`. | Doom HUD details remain scenario-local. |

## DTO / Snapshot / Carrier Decision List

| Type Family | BreakingChange | Reason | Impact |
| --- | --- | --- | --- |
| Cognition DTOs | No | New `AIKernel.Dtos.Cognition` records. | No existing DTO constructor is changed. |
| Runtime DTOs | No | New `AIKernel.Dtos.Runtime` WebAssembly records. | Host-specific DTOs stay outside the canonical surface. |
| Scenario DTOs | No | New `AIKernel.Dtos.Scenarios` records. | Doom-specific fields are not promoted. |
| Cognition enums | No | New `AIKernel.Enums.Cognition` enums with `Unknown = 0`. | Existing enum values are not renamed or deleted. |

## Migration Guide: Pre-release CTG Casing Consolidation

### Why

The all-caps `ICTG*` interface names did not match the existing codebase style,
which uses `Ctg` for type names such as `CtgDecisionGateRequest`,
`CtgDecisionGateResult`, and `ICtgGovernanceService`. Keeping both spellings
would create needless canonical debt.

### What Changed

| Before | After |
| --- | --- |
| `ICTGCanon` | `ICtgCanon` |
| `ICTGRuleset` | `ICtgRuleset` |
| `ICTGDecisionGate` | `ICtgDecisionGate` |

### Migration Steps

1. Replace all `ICTGCanon` references with `ICtgCanon`.
2. Replace all `ICTGRuleset` references with `ICtgRuleset`.
3. Replace all `ICTGDecisionGate` references with `ICtgDecisionGate`.
4. Keep method calls and DTO usage unchanged.

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

## Migration Guide: Doom Prompt Names to Scenario-Neutral Contracts

### Why

The v0.1.2 canonical interface package must not contain Doom-specific names.
Scenario-specific vocabulary belongs in AIKernel.Doom. The canonical surface
uses scenario-neutral contracts that other demos can also implement.

### What Changed

| Prompt Name | Canonical Name |
| --- | --- |
| `IDoomPerception` | `IScenarioPerception` |
| `IDoomActionEmitter` | `IScenarioActionEmitter` |
| `IDoomRuntimeStatus` | `IScenarioRuntimeStatus` |
| `IDoomHudState` | `IScenarioHudState` |

### Migration Steps

1. Keep Doom-specific detection and route labels in AIKernel.Doom.
2. Project Doom state into `ScenarioPerceptionSnapshot`,
   `ScenarioActionRequest`, `ScenarioRuntimeStatus`, and `ScenarioHudState`.
3. Implement the scenario-neutral interfaces only at the adapter boundary.

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

## Stability Reasons

- The canonical additions are opt-in and do not require existing implementations
  to add members.
- Result-like records use optional failure envelope fields only in the new
  v0.1.2 carrier surface.
- New enums use `Unknown = 0` and do not rename or delete existing enum values.
- Providers remain capability adapters; SDK wrappers and scenario runtimes stay
  out of AIKernel.NET.
- Control and Core retain their implementation responsibility: AIKernel.NET
  defines contracts only.

