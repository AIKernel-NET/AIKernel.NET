---
title: "rules Interfaces"
created: 2026-05-06
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

Japanese version: [Specification Index](specs/index-jp.md)

# rules Interfaces

## 1. Responsibility Boundary
The Rules category is AIKernel's governance decision layer. Centered on `IRuleEngine`, it deterministically evaluates whether inputs, intermediate states, and outputs satisfy policy constraints, and always falls back to fail-closed behavior when the decision is indeterminate.

## 2. Related Use Cases
- `UC-11` Static Prompt Validation
- `UC-13` Runtime Signature Verification and Governance
- `UC-21` Material Quarantine and Policy Enforcement

## 3. Related Specs
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC.md`
- `01.EXECUTION_PIPELINE_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos.Rules`, `AIKernel.Contracts`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Security`, `AIKernel.Abstractions.Governance`

## Documents
- [IRuleEngine (Rule Engine Specification)](architecture/interfaces/rules/IRuleEngine.md)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
