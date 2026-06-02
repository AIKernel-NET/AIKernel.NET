---
title: "material Interfaces"
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

Japanese version: [Specification Index](specs/index-jp.md)

# material Interfaces

## 1. Responsibility Boundary
Material is the ingestion boundary for external data. Through `IMaterialQuarantine` and `IStructuredMaterial`, raw material is quarantined and normalized before it can enter inference, preventing direct contamination of reasoning context.

## 2. Related Use Cases
- `UC-05` Material Relevance Evaluation
- `UC-07` Material Quarantine
- `UC-21` Material Quarantine and Policy Enforcement

## 3. Related Specs
- `01.EXECUTION_PIPELINE_SPEC.md`
- `03.ROM_CORE_SPEC.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos.Context`, `AIKernel.Dtos.Rom`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Providers`

## Documents
- [IMaterialQuarantine (Interface Specification)](architecture/interfaces/material/IMaterialQuarantine.md)
- [IStructuredMaterial](architecture/interfaces/material/IStructuredMaterial.md)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
