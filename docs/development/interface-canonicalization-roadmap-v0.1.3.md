---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Interface Canonicalization Roadmap v0.1.3

[Japanese](interface-canonicalization-roadmap-v0.1.3-ja.md)

This roadmap describes how the 0.1.3 line promotes the GPU and cognition
surfaces from Doom/Demo pilots into canonical package interfaces.

## Scope

The 0.1.3 canonicalization work covers:

- GPU execution identity, capability metadata, and zero-copy readiness.
- WebGPU, Dawn, and CUDA provider families as sibling GPU provider paths.
- GPU HUD and GPU Aisthesis DTOs as canonical browser/runtime surfaces.
- Control-plane arbitration metadata for GPU, CPU, and fallback execution.
- Bilingual documentation requirements for public .NET members.

## Promotion Rule

Implementation experiments may live in Demo or Doom while they are unstable.
Once a surface becomes reusable across providers or tools, promote the contract
shape into the package that owns the boundary:

| Surface | Canonical owner |
|---|---|
| Public interface, DTO, enum, or comment contract | `AIKernel.NET` |
| Runtime implementation | `AIKernel.Core` or `AIKernel.Wasm` |
| Provider-specific binding | `AIKernel.Providers`, `AIKernel.Cuda13.0`, or Dawn/WebGPU provider package |
| Control arbitration | `AIKernel.Control` |
| Developer verification | `AIKernel.Tools` |
| Scenario validation | `AIKernel.Demo` and `AIKernel.Doom` |

## Documentation Rule

Every promoted public member must have bilingual XML documentation. Developer
guides should keep English and Japanese Markdown files paired when a document is
part of the public documentation path.

## Exit Criteria

- Public names no longer carry development-only suffixes such as `rev3`.
- CLI commands use canonical names.
- Provider manifests expose canonical capability metadata.
- Demo and Doom consume canonical DTOs rather than private copies.
- Documentation source links resolve before site generation.
