---
id: repo-dependency-rules
title: "AIKernel.NET Repository Dependency Rules"
created: 2026-04-30
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
- aikernel
- repository
- dependency
- architecture
- governance
- english
---

## Overview

This document defines the **directional dependency (reference) rules between projects** in AIKernel.NET.
The goals are:

- Preserve the **purity of abstraction layers** and prevent implementation dependencies from leaking into Core
- Prevent **reference cycles and boundary collapse**
- Reflect OS-like integrity (Kernel / Drivers / Adapters / Ops) in code structure

This rule set is an OS rule to "first create layers, then fix dependency directions" (based on Core partitioning and OS modularization).

---

## 1. Fundamental Principle of Dependency Direction (Most Important)

- Dependencies must always flow **higher layer → lower layer**
- **Core is the fixed point**; Core must not depend on Kernel/Providers/Server/Hosting/Enterprise
- **Circular dependencies are forbidden** (A → B → A is fully prohibited)

---

## 2. Layer Definitions

- Core (syscall): Abstractions / Contracts / Dtos / Enums
- Kernel (implementation): Scheduler / Router / Controller / Pipeline / RagEngine / Rules
- Providers (drivers): Capability implementations
- VfsProviders (external data): Git and other data sources
- Server (adapter): External API compatibility
- Hosting (integration): DI / default pipelines / configuration
- Enterprise (operations): SIEM / multi-tenant / SLO

---

## 3. Core Internal Dependency Rules (AIKernel.* composition)

### 3.1 Example Modules

- AIKernel.Abstractions  : IKernel / IProvider / IGuard / IPdp / Vfs contract ownership
- AIKernel.Contracts     : OrchestrationContext / Contract Schema
- AIKernel.Dtos          : MaterialItem / TransferTrace / Purpose
- AIKernel.Enums         : RejectCode / PdpDecision

---

## 4. Dependency Table (Fixed)

The following dependency table is **fixed as policy**.
Dependencies not listed here are generally forbidden; exceptions must be documented in an Issue/ADR with rationale.

### 4.1 Allowed Dependencies

| Project | Allowed References |
|---|---|
| AIKernel.Enums | none |
| AIKernel.Dtos | AIKernel.Enums |
| AIKernel.Contracts | AIKernel.Enums, AIKernel.Dtos |
| AIKernel.Abstractions | AIKernel.Dtos, AIKernel.Enums |
| Providers / VfsProviders | AIKernel.Abstractions, AIKernel.Core |
| Core | AIKernel.Abstractions |
| tests/* | free to reference (no reverse flow) |

### 4.2 Forbidden

- Circular dependencies (A → B → A)
- src referencing tests (reverse flow)
- Core referencing Kernel/Providers/Server/Hosting/Enterprise
- AIKernel.Abstractions referencing AIKernel.Core, Providers, or a separate Vfs package/project
- Concrete data carriers in Vfs interfaces (must be defined in AIKernel.Dtos)

### 4.3 v0.0.4 Vfs Contract Ownership

Vfs interface contracts are owned by `AIKernel.Abstractions`.
Their public namespace remains `AIKernel.Vfs` for source compatibility.
The separate `AIKernel.Vfs` compatibility package/project was removed in v0.0.4.
Downstream packages should reference `AIKernel.Abstractions` directly while keeping existing `using AIKernel.Vfs;` source imports when they consume Vfs contracts.

The required Phase-1 package graph is:

```text
AIKernel.Enums -> (none)
AIKernel.Dtos -> AIKernel.Enums
AIKernel.Contracts -> AIKernel.Enums, AIKernel.Dtos
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
```

### 4.4 v0.0.4 Contract Extraction Rule

DSL, DSL ROM, History ROM, and Kernel clock contracts are owned by `AIKernel.Abstractions` and `AIKernel.Dtos` as of v0.0.4.
Core implementations may adapt these contracts internally to `AIKernel.Common.Results`, but `AIKernel.Abstractions` must not reference `AIKernel.Common` until Common is published as a stable contract package.

### 4.5 v0.0.5 Contract Surface Purity Rule

`AIKernel.Abstractions` and `AIKernel.Contracts` must export public interfaces only.
DTOs must be owned by `AIKernel.Dtos`, and shared enums must be owned by `AIKernel.Enums`.
Runtime exception implementations and result/failure adapters belong to implementation packages such as `AIKernel.Core` or `AIKernel.Common`, not to contract packages.

---

## 5. Kernel / Providers / VfsProviders Dependency Rules (Summary)

- Kernel may only reference Core
- Providers / VfsProviders may depend only on Core (primarily Abstractions) and must not depend on Kernel concrete implementations
- External SDKs must be contained within Providers/VfsProviders and not leak into Core

(Details may be split into separate documents during implementation.)

---

## 6. CI Enforcement (Recommended)

- Detect reference cycles (fail build)
- Detect forbidden dependencies (static analysis fail)
- Detect breaking changes to public API (Abstractions/Contracts) via diff checks

---

## Conclusion

Dependency direction is design. AIKernel.NET, as an OS, fixes boundaries and dependency directions early and preserves them through future extensions.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.3 (2026-06-02): Corrected Phase-1 dependency graph and Vfs contract ownership/type-forwarding rule
- v0.0.4 (2026-06-04): Added DSL / History ROM / Kernel clock contract extraction dependency rule
- v0.0.4 (2026-06-04): Removed the separate AIKernel.Vfs compatibility facade from the package graph
- v0.0.5 (2026-06-05): Added contract-surface purity rule for interface-only packages
