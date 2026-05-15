---
id: repo-dependency-rules
title: "AIKernel.NET Repository Dependency Rules"
created: 2026-04-30
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
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

- Core (syscall): Abstractions / Contracts / Dtos / Enums / Events / KernelContext / Vfs
- Kernel (implementation): Scheduler / Router / Controller / Pipeline / RagEngine / Rules
- Providers (drivers): Capability implementations
- VfsProviders (external data): Git and other data sources
- Server (adapter): External API compatibility
- Hosting (integration): DI / default pipelines / configuration
- Enterprise (operations): SIEM / multi-tenant / SLO

---

## 3. Core Internal Dependency Rules (AIKernel.* composition)

### 3.1 Example Modules

- AIKernel.Abstractions  : IKernel / IProvider / IGuard / IPdp
- AIKernel.Contracts     : OrchestrationContext / Contract Schema
- AIKernel.Dtos          : MaterialItem / TransferTrace / Purpose
- AIKernel.Enums         : RejectCode / PdpDecision
- AIKernel.Events        : AuditEvent / GuardEvent
- AIKernel.KernelContext : Identity / Permission / Budget / DataClassification
- AIKernel.Vfs           : Vfs abstractions (external data boundary)

---

## 4. Dependency Table (Fixed)

The following dependency table is **fixed as policy**.
Dependencies not listed here are generally forbidden; exceptions must be documented in an Issue/ADR with rationale.

### 4.1 Allowed Dependencies

| Project | Allowed References |
|---|---|
| AIKernel.Abstractions | AIKernel.Contracts, AIKernel.Enums |
| AIKernel.Contracts | AIKernel.Enums |
| AIKernel.Dtos | AIKernel.Enums |
| AIKernel.Events | AIKernel.Enums, AIKernel.Dtos |
| AIKernel.KernelContext | AIKernel.Enums |
| AIKernel.Vfs | AIKernel.Dtos |
| tests/* | free to reference (no reverse flow) |

### 4.2 Forbidden

- Circular dependencies (A → B → A)
- src referencing tests (reverse flow)
- Core referencing Kernel/Providers/Server/Hosting/Enterprise
- Concrete data carriers in Vfs interfaces (must be defined in AIKernel.Dtos)

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
