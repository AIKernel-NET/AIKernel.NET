---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel Repository Alignment v0.1.1.1

This document is the cross-repository alignment note for the AIKernel 0.1.1.1
development line. Repository-specific documents may describe local build,
package, and implementation details, but this page owns the shared boundary
rules.

## Shared Version Policy

- The public baseline is the 0.1.1 package family.
- The current development update line is 0.1.1.1.
- Local development packages use `0.1.1.1-dev{build-number}`.
- The 0.1.1.1 line is a local validation line and is NuGet-only.
- Python wrapper documents are reference material for 0.1.1.1. Do not build,
  publish, or require PyPI packages for 0.1.1.1 validation.
- The next official release line is the v0.1.2 canonical series. That line is
  expected to publish synchronized NuGet and PyPI package families.

## Documentation Ownership

- AIKernel.NET owns common theory, contract policy, repository alignment,
  concept vocabulary, migration policy, and cross-package documentation rules.
- Implementation repositories own local setup, package usage, diagnostics,
  tests, and implementation-specific developer notes.
- Demo and scenario repositories own runnable examples and scenario mappings,
  not shared runtime semantics.

## Repository Roles

| Repository | Role | Must not own |
| --- | --- | --- |
| `AIKernel.NET` | Contracts, DTOs, enums, canonical documentation, concept vocabulary. | Runtime implementation, provider SDK wrappers, scenario logic. |
| `AIKernel.Core` | Deterministic kernel runtime, monads, CTG evaluators, hosting, VFS/runtime primitives. | Provider endpoint behavior, browser/WASM runtime, scenario mappings. |
| `AIKernel.Providers` | Provider substrate, manifests, descriptors, deterministic router, runtime-configurable providers. | Gate logic, WASM/JSInterop, fixed native SDK dependencies, Doom semantics. |
| `AIKernel.Cuda13.0` | Explicit opt-in CUDA 13.0 + LibTorch 2.12 Windows backend package. | Core runtime policy, generic provider routing, non-CUDA backends. |
| `AIKernel.Control` | Orchestration, policy application, Core gate invocation, execution coordination. | Gate truth tables, provider semantics, browser runtime implementation. |
| `AIKernel.Tools` | CLI, inspectors, replay, instrumentation, canonical formatting. | Kernel runtime ownership, provider execution, scenario runtime. |
| `AIKernel.Wasm` | Browser/WebAssembly runtime, WebGPU/WebAudio/display/input execution surfaces. | Doom-specific semantics, Providers substrate ownership, Gate/CTG decisions. |
| `AIKernel.Demo` | Runnable examples that consume the package family. | Runtime contracts, package ownership, production scenario semantics. |
| `AIKernel.Doom` | Scenario-specific demo mapping and browser sample for DOOM. | Shared contracts, generic WASM semantics, Core/Control gate logic. |

## Decision Boundaries

- Control calls Core gate services; it does not reimplement Decision Gate or
  Trajectory Gate logic.
- Providers produce semantic material and diagnostics; they do not emit
  `GateDecisionKind`, `TrajectoryGateDecisionKind`, `RejectReasonKind`, or
  `GateInput`.
- Wasm executes browser-bound perception, spatial, HUD, WebGPU, WebAudio,
  framebuffer, and input surfaces; it does not depend on Doom.
- Doom maps scenario-specific visual, audio, HUD, and input semantics onto the
  generic surfaces.
- CUDA packages may know their target runtime, but the generic provider layer
  must remain descriptor-driven and free of compile-time CUDA runtime coupling.

## Thin Surface Rule For 0.1.2 Promotion

Some perception, spatial, HUD, overlay, and browser runtime surfaces are still
thin implementation or substrate surfaces in 0.1.1.1. Keep them additive and
non-breaking so they can be promoted into AIKernel.NET contracts during the
0.1.2 canonical contract update.

Do not move these thin surfaces into AIKernel.NET during 0.1.1.1 unless the
contract promotion plan is explicitly opened.

## Local Validation Order

Validate from the lowest shared surface to the most scenario-specific surface:

1. `AIKernel.NET`
2. `AIKernel.Core`
3. `AIKernel.Providers`
4. `AIKernel.Cuda13.0`
5. `AIKernel.Control`
6. `AIKernel.Tools`
7. `AIKernel.Wasm`
8. `AIKernel.Demo`
9. `AIKernel.Doom`

When a repository consumes another repository's current development work, use
the matching local NuGet package version from the same `0.1.1.1-dev{build}`
family.
