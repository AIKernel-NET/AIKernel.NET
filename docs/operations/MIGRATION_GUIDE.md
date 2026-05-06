---
title: "Migration Guide"
status: "Planned"
version: 0.0.1
updated: 2026-05-06
---

# Migration Guide

This guide defines migration steps from the initial concept baseline (`v0.0.0`) to the canonical architecture baseline (`v0.0.1`).

## 1. Fundamental Changes
In `v0.0.1`, the architecture was rebuilt around `Determinism` and `Non-LLM Governance`.

- `Namespace hardening`:
  `AIKernel.Models` was removed and split into `Routing`, `Rom`, and `Rules`.
- `DTO purification`:
  business logic and custom exceptions were removed from the DTO layer.
- `Trust-chain enforcement`:
  ROM processing is now standardized as `IROMCanonicalizer` first, then `ISemanticHasher`.

## 2. Interface Replacement Mapping
Replacement rules from old terms to canonical terms:

| Legacy Interface (v0.0.0) | Canonical Interface (v0.0.1) | Migration Notes |
|---|---|---|
| `IPromptSigner` | `ISemanticHasher` + `IPromptSignatureProvider` | Move from signer-only flow to canonicalization + semantic hash + signature chain. |
| `IContextSerializer` | (Removed) | Responsibility moved to `IKernelContext` and `IContextSnapshot`. |
| `IRoutingDecisionEngine` | `IModelVectorRouter` | Move from model-name routing to capability-vector routing. |
| `IPromptRuleSet` | `IPolicy` / `IRuleEngine` | Replace loosely-defined rule sets with deterministic policy evaluation. |

## 3. Recommended Migration Steps
1. `Namespace updates`:
   align `using` directives with physical directory structure.
2. `Exception relocation`:
   remove DTO-layer exception assumptions and enforce fail-closed behavior in Provider/Kernel execution layers.
3. `ROM pipeline update`:
   always call `IROMCanonicalizer.Canonicalize()` before hash/signature verification.
4. `Test realignment`:
   remap use-case-driven tests to canonical interfaces and `UC-xx` definitions.

## 4. Verification Checklist
- `Abstractions` do not expose external SDK-specific types in signatures.
- `Dtos` do not contain business logic or exception contracts.
- `IRomDocument -> IROMCanonicalizer -> ISemanticHasher` order is enforced.
- `IPdp` remains deterministic with `Indeterminate => Deny` behavior.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
