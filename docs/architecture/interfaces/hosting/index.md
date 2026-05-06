---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "hosting Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# hosting Interfaces

## 1. Responsibility Boundary
Hosting manages kernel startup, module registration, and lifecycle transitions. Through `IKernelHost`, `IKernelModule`, and `IServiceRegistrar`, it ensures all required components are composed before execution begins.

## 2. Related Use Cases
- `UC-08` Kernel Initialization
- `UC-09` Execution State Restore
- `UC-29` Task Pipeline Management

## 3. Related Specs
- `01.EXECUTION_PIPELINE_SPEC.md`
- `16.SEMANTIC_CONTEXT_OS_VISION.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Abstractions`, `AIKernel.Contracts`, `AIKernel.Dtos`
- Called by: `AIKernel.Core` (implementation layer), `Host Applications`

## Documents
- IKernelContext.md
- IKernelHost.md
- IKernelModule.md
- IProviderRegistrar.md
- IServiceRegistrar.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
