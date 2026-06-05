---
title: "dsl Interfaces"
created: 2026-06-04
updated: 2026-06-04
published: 2026-06-04
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - dsl
  - english
---

Japanese version: [dsl/index-jp.md](index-jp.md)

# dsl Interfaces

## 1. Responsibility Boundary
DSL contracts describe deterministic Semantic IR and the host boundary for compiling
AI-generated JSON plans into governed pipelines. They are contracts only; parsing,
validation, ResultStep expansion, and provider execution remain implementation
responsibilities.

## 2. Public Contracts
- [IDslPipelineCompiler](IDslPipelineCompiler.md)
- [IDslCapabilityRegistry](IDslCapabilityRegistry.md)
- [IKernelPipeline](IKernelPipeline.md)
- [IDslRomRegistry](IDslRomRegistry.md)
- [IDslRomStore](IDslRomStore.md)

## 3. DTO Surface
- `DslDocument`
- `PipelineNode` and concrete node records
- `DslPipelineValue`
- `DslPipelineState`
- `DslPipelineExecutionContext`
- `DslPipelineExecutionResult`
- `DslRomMetadata`
- `DslRomSnapshot`

## 4. Related Specs
- `docs/architecture/18.DSL_PIPELINE_AND_ROM_SPEC.md`
- `docs/operations/MIGRATION_GUIDE.md`

## Boundary Rule
- `AIKernel.Abstractions.Dsl` must not depend on `AIKernel.Core` or `AIKernel.Common`.
- Core may adapt internal `Result<T>` / `ResultStep<TState,TValue>` values to these DTO contracts at the package boundary.
- DSL ROM publication must use caller-provided Vfs sessions; runtime implementations must not hide writable global state behind the contract.
- `DslNodeTypes` defines canonical serialized node names. Parser aliases such as `CapabilityCall` and `SuspendForApproval` are compatibility vocabulary and should normalize to `CallCapability` and `Suspend`.

---

# Changelog
- v0.0.4 (2026-06-04): Added DSL interface category for package-public contracts.
