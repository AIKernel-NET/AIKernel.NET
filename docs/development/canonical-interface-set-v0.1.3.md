---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Canonical Interface Set v0.1.3

[Japanese](canonical-interface-set-v0.1.3-ja.md)

This document summarizes the public interface families that are treated as
canonical in the 0.1.3 line.

## Canonical Families

| Family | Developer meaning |
|---|---|
| Contracts and DTOs | Stable shapes for requests, responses, evidence, and policy exchange. |
| Runtime and hosting | Kernel, VFS, process, memory, ROM, and execution boundaries. |
| Control | Intent, objective, action, governance, arbitration, and fallback evidence. |
| Providers | Standard, chat, compute, local LLM, Microsoft AI, CUDA, WebGPU, and Dawn paths. |
| WASM | Browser runtime, sandbox, WebGPU bridge, WebAudio, display, HUD, and Aisthesis. |
| Tools | CLI, inspectors, formatting, verification, and package-integrity checks. |
| Demo and Doom | Scenario validation for canonical runtime, Control, GPU HUD, and Aisthesis surfaces. |

## GPU Interface Set

The 0.1.3 GPU interface set is intentionally provider-neutral:

- WebGPU is the browser/WASM provider path.
- Dawn is the native WebGPU provider path.
- CUDA 13.0 is the platform capability provider path.

All three paths report capability, readiness, zero-copy state, and fallback
metadata through canonical names.

## Documentation Interface

The documentation interface is also canonical:

- Markdown source files should be paired as English and Japanese when they are
  part of the public developer path.
- Public .NET members should use bilingual XML documentation comments or paired
  include files.
- Generated HTML and reference pages are downstream outputs, not the source of
  truth.
