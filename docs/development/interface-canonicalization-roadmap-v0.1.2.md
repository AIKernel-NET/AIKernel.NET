# Interface Canonicalization Roadmap for v0.1.2

This note records implementation surfaces that should be reviewed during the next canonical interface update. It is not a contract file. The current v0.1.1.1 packages keep these surfaces thin so they can be promoted, renamed, merged, or removed without changing CTG semantics.

## Candidate Domains

- Perception: frame perception, auditory perception, spatial cognition, HUD signal extraction, and overlay annotation DTO generation.
- Runtime model execution: descriptor-driven resident model execution, WebGPU buffer binding descriptors, and zero-copy capability metadata.
- Control orchestration: perception-derived vote carriers, CTG policy delegation, and dynamic pipeline selection carriers.
- Scenario mapping: scenario-specific HUD, overlay, and virtual input mapping.

## v0.1.1.1 Holding Pattern

- `AIKernel.Providers.Perception` contains provider substrate contracts only. It must not own WebGPU, WebAudio, WASM runtime, or scenario logic.
- `AIKernel.Wasm.*` packages own browser/WASM execution surfaces and may expose local DTOs until the canonical contracts are added.
- `AIKernel.Control.Core.Perception` owns adapter surfaces that convert perception-derived discrete vote candidates into the existing CTG Control pipeline.
- Scenario packages own scenario-specific mappings only.

## v0.1.2 Review Items

- Decide whether `IAuditoryPerceptionProvider` and `ISpatialCognitionProvider` belong in `AIKernel.Abstractions.Perception`.
- Decide whether spatial cognition DTOs belong in `AIKernel.Dtos.Perception` or a dedicated `AIKernel.Dtos.Spatial` namespace.
- Unify WASM-local auditory and spatial DTO names with canonical DTO names after contract promotion.
- Review whether resident model execution should use `AIKernel.Abstractions.Models` or a dedicated execution domain.
- Consolidate HUD/overlay request metadata keys and diagnostic keys.
- Preserve the rule that Control reads Core CTG results but does not implement Gate logic.

## Non-Negotiable Boundaries

- Providers remain substrate, manifest, router, registry, descriptor, and runtime-configurable provider surfaces.
- Wasm owns browser/WASM runtime, WebGPU, WebAudio, framebuffer, virtual input, and JS interop boundaries.
- Control owns orchestration and Core Gate invocation only.
- Scenario repositories own scenario-specific semantics, mappings, and benchmarks only.
- CTG GateInput remains vote-only; confidence, risk, score, diagnostics, and explanations do not flow into GateInput.
