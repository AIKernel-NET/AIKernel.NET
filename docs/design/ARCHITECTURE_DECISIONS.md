---
id: architecture-decisions
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ARCHITECTURE_DECISIONS — Major Architecture Decisions (ADR Collection)"
created: 2026-05-01
tags:
- aikernel
- design
- adr
- governance
- english
updated: 2026-05-06
---

# ARCHITECTURE_DECISIONS — Major Architecture Decisions (ADR Collection)

## Overview
This document aggregates AIKernel.NET's major architecture decisions so they can be referenced later.
AIKernel.NET aims to be the "OS for AI applications" and places **Contracts and Abstractions** as fixed points to separate implementation dependencies.

- **Purpose**: Record the rationale (Why) and the chosen approach (What/How) for future extension, migration, and review.
- **Non-purpose**: Implementation details and code specifics are delegated to implementation repositories and to `DI_GUIDE` / `EXTENSION_POINTS`.

---

## AD-0001 Prioritize Contract-Driven Design
### Decision
Core holds abstract interfaces and Contracts (JSON Schema/DTOs) and excludes implementation dependencies.

### Rationale
- Fixing compatibility around Contracts makes implementation replacement and future extension easier.
- In early OSS stages, Contracts clearly communicate boundaries and intent.

### Impact
- Implementations (Kernel/Providers/Server) are isolated into separate modules/repositories.
- Contract changes become governance items; breaking changes must be documented.

---

## AD-0002 LLM as Suggestor, PDP as Final Decision-Maker
### Decision
LLMs generate suggestions; the PDP (Policy Decision Point) makes final decisions.

### Rationale
- Govern nondeterministic LLM outputs at the OS level.
- Ensure auditability and integrated decision-making for compliance, cost, and risk.

### Impact
- PDP is a contract-defined extension point and can be replaced by different implementations.

---

## AD-0003 Treat Providers by Capability (Avoid model-name dependence)
### Decision
Providers declare Capabilities and avoid dependence on model names or vendor-specific behaviors.

### Rationale
- Enables multi-provider operation, failover, and cost/latency optimization.
- Provides stable abstractions in a rapidly changing model landscape.

### Impact
- ProviderRouter will make decisions based on Capabilities.

---

## AD-0004 Pipeline as DAG with Deterministic TaskManager
### Decision
Pipelines are expressed as DAGs and TaskManager controls resource allocation and scheduling deterministically.

### Rationale
- Manage execution order, retries, and other controllable aspects deterministically.
- Provide traceability for Deterministic Replay.

### Impact
- Pipeline implementation becomes an extension point; cross-cutting concerns (safety/audit/metrics) are separated.

---

## AD-0005 Make Deterministic Replay a Top Requirement
### Decision
Prioritize auditability and reproducibility by saving execution logs, prompts, and runtime state.

### Rationale
- Explanation and reproducibility are essential for treating AI systems as an operational OS.

### Impact
- Audit events and trace information must be fixed as Contracts/specifications.

---

## AD-0006 Treat Documentation as Part of Architecture
### Decision
Documentation is part of the architecture. Use numbered architecture files + index, with English as canonical and Japanese as deep-dive.

### Rationale
- Strengthen diff review and governance; maintain consistency of philosophy and specification.

---

## Related Documents
- `./DESIGN_INTENT.md` (Design Intent)
- `../architecture/index.md` (Architecture index)
- `../guidelines/DOCUMENTATION_GUIDELINES.md` (Documentation guidelines)
- `EXTENSION_POINTS.md` (Extension points)
- `CONTRACT_VERSIONING.md` (Contract versioning)
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
