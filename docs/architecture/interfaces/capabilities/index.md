---
title: "Capabilities Interfaces"
created: 2026-06-05
updated: 2026-06-05
published: 2026-06-05
version: "0.0.5"
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

# Capabilities Interfaces

## 1. Responsibility Boundary
Capabilities define the contract boundary for reusable external modules that may be invoked directly, through a sandboxed CLI executable, as a managed assembly reference, through a native ABI, as DSL ROM, or as a remote endpoint.

`ICapabilityModuleRegistry` owns registration and lookup of admitted module descriptors. `ICapabilityModuleInvoker` owns the abstract invocation boundary. Runtime loading, sandboxing, assembly binding, native invocation, and remote transport remain Core/Tools/provider responsibilities.

## 2. Dependency Boundary
- Depends on: `AIKernel.Dtos.Capabilities`, `AIKernel.Enums`
- Called by: Core, Tools, DSL compiler/runtime, provider packages, and host applications

## Documents
- [ICapabilityModuleRegistry](ICapabilityModuleRegistry.md)
- [ICapabilityModuleInvoker](ICapabilityModuleInvoker.md)
---

# Changelog
- v0.0.5 (2026-06-05): Added external Capability module contract boundary.
