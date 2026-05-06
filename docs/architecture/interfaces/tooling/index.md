---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "tooling Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# tooling Interfaces

## 1. Responsibility Boundary
Tooling is the safety boundary for external tool invocation. `IToolAccessValidator` decides authorization, `IToolPermission` defines policy scope, and `IToolSandbox` enforces runtime isolation to prevent side effects from escaping controlled execution.

## 2. Related Use Cases
- `UC-10` Tool Invocation Control
- `UC-21` Policy Enforcement

## 3. Related Specs
- `01.EXECUTION_PIPELINE_SPEC.md`
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Security`, `AIKernel.Abstractions.Hosting`

## Documents
- IToolAccessValidator.md
- IToolPermission.md
- IToolSandbox.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
