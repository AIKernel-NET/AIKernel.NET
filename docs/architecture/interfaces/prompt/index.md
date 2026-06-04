---
title: "prompt Interfaces"
created: 2026-05-03
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

Japanese version: [Index](index-jp.md)

# prompt Interfaces

## 1. Responsibility Boundary
Prompt is the boundary that elevates signed input artifacts into executable context. `IPromptVerifier`, `IPromptValidator`, and `ISignatureTrustStore` validate integrity, trust chain, and runtime scope, and must reject execution on any failure path.

## 2. Related Use Cases
- `UC-11` Static Prompt Validation
- `UC-13` Runtime Signature Verification
- `UC-20` Deterministic Replay

## 3. Related Specs
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC.md`
- `06.REPLAY_DUMP_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Governance`, `AIKernel.Abstractions.Execution`

## Documents
- [IPromptRepository](../prompt/IPromptRepository.md)
- [IPromptSignatureProvider](../prompt/IPromptSignatureProvider.md)
- [ISignatureTrustStore (Interface Specification)](../governance/ISignatureTrustStore.md)
- [IPromptValidator](../prompt/IPromptValidator.md)
- [IPromptVerifier (Interface Specification)](../prompt/IPromptVerifier.md)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines

