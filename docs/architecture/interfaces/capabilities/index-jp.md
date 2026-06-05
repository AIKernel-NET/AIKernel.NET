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
  - japanese
---

English version: [Index](index.md)

# Capabilities Interfaces

## 1. Responsibility Boundary
Capabilities は、直接呼び出し、sandboxed CLI executable、managed assembly reference、native ABI、DSL ROM、remote endpoint として呼び出される再利用可能な外部 module の契約境界を定義します。

`ICapabilityModuleRegistry` は admission 済み module descriptor の登録と lookup を担います。`ICapabilityModuleInvoker` は抽象的な invocation boundary を担います。Runtime loading、sandboxing、assembly binding、native invocation、remote transport は Core / Tools / provider package の責務です。

## 2. Dependency Boundary
- Depends on: `AIKernel.Dtos.Capabilities`, `AIKernel.Enums`
- Called by: Core, Tools, DSL compiler/runtime, provider packages, host applications

## Documents
- [ICapabilityModuleRegistry](ICapabilityModuleRegistry-jp.md)
- [ICapabilityModuleInvoker](ICapabilityModuleInvoker-jp.md)
---

# Changelog
- v0.0.5 (2026-06-05): external Capability module contract boundary を追加。
