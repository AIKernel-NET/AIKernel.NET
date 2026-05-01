# AIKernel.NET
AIKernel is an operating-system-style framework for AI applications, built on strict category separation, context isolation, and contract-driven orchestration.
This repository contains the Core layer of the AIKernel OS, including abstractions, contracts, DTOs, enums, events, execution context, and virtual file system interfaces.

---

## Core Architecture Overview

AIKernel Core is divided into **7 foundational modules**, each representing a strict OS boundary:

- **AIKernel.Abstractions**     – Syscall-level interfaces (IKernel, IProvider, IGuard, IPdp)
- **AIKernel.Contracts**        – Orchestration and context schemas (immutable input formats)
- **AIKernel.Dtos**             – Lightweight data transfer objects
- **AIKernel.Enums**            – Shared enumerations across the OS
- **AIKernel.Events**           – Audit and system event definitions
- **AIKernel.KernelContext**    – Execution context (identity, permissions, budgets, classification)
- **AIKernel.VFS**              – Virtual file system abstractions (external data boundary)

This structure enforces the AIKernel design principles:

- **Category Separation** — No mixing of abstractions, contracts, DTOs, or events
- **Context Isolation** — Runtime context is never mixed with LLM inference
- **Contract-Driven Execution** — Kernel behavior is defined by immutable schemas
- **Boundary Enforcement** — Kernel, Providers, and VFS interact only through stable interfaces

---

## NuGet Packages

Each module is published as an independent NuGet package:

- AIKernel.Abstractions
- AIKernel.Contracts
- AIKernel.Dtos
- AIKernel.Enums
- AIKernel.Events
- AIKernel.KernelContext
- AIKernel.VFS

All packages follow:

- MIT License
- Semantic Versioning
- Strict dependency rules (see below)

---

## Dependency Rules (Critical for OS Integrity)

To prevent architectural erosion, the following dependency graph is enforced:

- AIKernel.Abstractions   →  AIKernel.Contracts, AIKernel.Enums
- AIKernel.Contracts      →  AIKernel.Enums
- AIKernel.Dtos           →  AIKernel.Enums
- AIKernel.Events         →  AIKernel.Enums, AIKernel.Dtos
- AIKernel.KernelContext  →  AIKernel.Enums, AIKernel.Dtos
- AIKernel.VFS            →  AIKernel.Enums, AIKernel.Dtos, AIKernel.KernelContext
- tests/*                 →  Free (but must not be referenced by src)

**Prohibited dependencies:**

- Contracts → Dtos
- Events → Abstractions
- KernelContext → Abstractions
- VFS → Abstractions

---

## Testing Structure

- tests/AIKernel.Abstractions.Tests   – Contract tests for IKernel / IProvider / IGuard / IPdp
- tests/AIKernel.Contracts.Tests      – Schema and context validation tests

Mocks and test utilities live in:

- AIKernel.Testing

---

## License

MIT License
Copyright © 2026 Takuya Sogawa of AIKernel-NET

---

## Repository

https://github.com/AIKernel-NET/AIKernel.NET
