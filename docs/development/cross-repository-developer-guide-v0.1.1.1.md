---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Cross-Repository Developer Guide v0.1.1.1

[日本語](cross-repository-developer-guide-v0.1.1.1-ja.md)

This guide is the first stop when a change crosses AIKernel repositories. It
does not replace repository-specific docs. It explains where a responsibility
belongs so developers do not reimplement logic in the wrong layer.

## Reading Order

1. Read this guide to choose the owning repository.
2. Read [Repository Alignment v0.1.1.1](repository-alignment-v0.1.1.1.md) for
   versioning, package, and release-line rules.
3. Read [Interface Canonicalization Roadmap v0.1.2](interface-canonicalization-roadmap-v0.1.2.md)
   before promoting a local carrier into AIKernel.NET contracts.
4. Read [Concept Elevation Guidelines](../guidelines/concept-elevation-guidelines.md)
   before adding a philosophical concept name.
5. Read the target repository's `docs/README*.md` for build and test commands.

## Repository Ownership

| Repository | Owns | Must Not Own |
| --- | --- | --- |
| `AIKernel.NET` | Contracts, DTOs, enums, canonical docs, ROM layout, CTG contract model | Implementation classes, provider SDK wrappers, browser/runtime code |
| `AIKernel.Core` | Deterministic CTG evaluators, Core runtime services, VFS implementation, hosting integration | Provider endpoint behavior, Control orchestration, browser/WASM execution, scenario mapping |
| `AIKernel.Control` | Orchestration, Apply Policy phase, Core Gate invocation, runtime control, pipeline selection | Decision Gate truth tables, provider semantic evaluation, WebGPU/WebAudio implementation, scenario semantics |
| `AIKernel.Providers` | Provider substrate, manifests, descriptors, deterministic router, provider-neutral perception/audio/compute substrate | WASM/JS/browser runtime, native SDK implementation, Gate decisions, scenario logic |
| `AIKernel.Wasm` | Browser/WASM execution, WebGPU/WebAudio, display/input, perception execution, spatial cognition, HUD signal generation | Providers substrate ownership, Doom semantics, CTG/Gate decisions |
| `AIKernel.Cuda13.0` | Opt-in CUDA native runtime package and CUDA-specific module boundary | Generic compute contracts, Core policy, non-CUDA provider routing |
| `AIKernel.Tools` | CLI, inspectors, replay, diagnostics, canonical formatting, operator instrumentation | Runtime implementation, provider execution, scenario runtime |
| `AIKernel.Demo` | Runnable examples that consume packages | Shared contracts, production runtime behavior |
| `AIKernel.Doom` | Doom-specific scenario mapping, web demo glue, HUD/input semantics for the sample | Shared contracts, generic WASM semantics, Core/Control Gate logic |

## Package and Release Rules

- The v0.1.1.1 line is NuGet-only.
- Do not create or publish PyPI packages for this local validation line.
- The next official release is the v0.1.2 canonical series. Treat v0.1.2 as the
  next synchronized NuGet + PyPI package line.
- Local development package versions use `0.1.1.1-dev{build-number}`.
- Keep existing public APIs stable. Add optional DTO properties or side-by-side
  interfaces only when required.
- `AIKernel.NET` is the contract source of truth; implementation repositories
  may carry local mirrors only as temporary extraction candidates.

## CTG and Control Boundary

Decision Gate and Trajectory Gate logic belongs to Core.

Control may:

- normalize provider outputs into council votes,
- call Core CTG evaluators,
- attach diagnostics and retry intent outside `GateInput`,
- choose an execution pipeline from the returned decision envelope.

Control must not:

- count approvals,
- derive Ethos veto,
- create Gate decisions,
- copy Trajectory Gate halt logic,
- pass continuous values such as confidence, score, or risk into `GateInput`.

Providers, Wasm, Doom, and Tools must not emit `GateDecisionKind`,
`TrajectoryGateDecisionKind`, or `RejectReasonKind` as sensor or perception
outputs.

## Sensor OS and Triadic Concepts

Sensor OS carriers use a map, not fixed arrays:

```text
sensorInputs: { [sensorName: string]: SensorState }
```

The current v0.1.1.1 implementation keeps these carriers outside AIKernel.NET
contracts so they can be consolidated in the v0.1.2 canonical update.

| Sensor Name | Concept Name | Owner Today | Meaning |
| --- | --- | --- | --- |
| `visual` | `Aisthesis` | Providers/Wasm/Doom local carriers | Direct visual sensory evidence |
| `audio` | `Aisthesis` | Providers/Wasm/Doom local carriers | Direct stereo auditory evidence |
| `health` | `Aisthesis` | Providers/Wasm/Doom local carriers | Direct life/death evidence from HUD or face-like quantization |
| `motor` | `Kinesis` | Providers/Wasm/Doom local carriers | Movement intent and motion vector input |
| `movement` | `Kinesis` | Providers/Wasm/Doom local carriers | Derived relative movement vector fused from visual, audio, and motor evidence |
| `compass` | `Phantasia` | Providers/Wasm/Doom local carriers | Relative heading representation |
| `spatial` | `Phantasia` | Providers/Wasm/Doom local carriers | Fused spatial representation / world model |

Legacy names `Hodos`, `Zoe`, and `Topos` were intermediate sensor labels. New
code and docs should use the triadic model above unless preserving old metadata
for compatibility.

Canonical concept flow:

```text
Aisthesis -> Phantasia -> Nous -> Telos -> Ethos/Logos/Pathos
  -> Kairos -> Kinesis/Praxis/Kratos -> Energeia -> Chronos
```

## Promotion to AIKernel.NET v0.1.2

Before extracting a local implementation surface into AIKernel.NET:

- confirm it is provider-neutral and scenario-neutral,
- confirm it does not carry Gate decisions or reject reasons,
- confirm DTOs are immutable and collections are non-null,
- confirm public members have bilingual XML documentation,
- document old API to new API migration if any breaking change is proposed.

Current extraction candidates include:

- sensor input map carrier,
- spatial fusion vector carrier,
- retry intent carrier,
- sensor normalizer abstraction,
- spatial sensor fusion abstraction,
- retry intent resolver abstraction.

## Validation Matrix

Run the smallest relevant command first:

```powershell
dotnet test AIKernel.Core\AIKernel.Core.slnx -c Release --no-restore
dotnet test AIKernel.Control\tests\AIKernel.Control.Tests\AIKernel.Control.Tests.csproj -c Release --no-restore
dotnet test AIKernel.Providers\tests\Perception\AIKernel.Providers.Perception.Tests\AIKernel.Providers.Perception.Tests.csproj -c Release --no-restore
dotnet test AIKernel.Wasm\AIKernel.Wasm.slnx -c Release --no-restore
dotnet test AIKernel.Doom\AIKernel.Doom.slnx -c Release --no-restore
```

For browser-facing changes, also run JS syntax checks and sync the development
site:

```powershell
node --check AIKernel.Doom\src\DoomWeb\wwwroot\js\doom.js
WebSite\script\sync_dev_wwwroot.ps1
```

When using browser automation, verify that no Node.js debug process remains
after the check.

## Common Mistakes

- Putting a shared contract into an implementation repository.
- Letting Control reproduce Core Gate logic.
- Letting Providers become SDK wrappers instead of capability adapters.
- Letting Wasm depend on Providers perception substrate directly.
- Letting Doom-specific event names leak into Wasm or Providers.
- Using philosophical names on DTOs, mappers, adapters, serializers, or provider
  implementation classes.
- Reintroducing PyPI packaging into the v0.1.1.1 validation line instead of
  preparing it for the v0.1.2 canonical release line.
