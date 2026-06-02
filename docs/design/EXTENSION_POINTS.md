---
id: extension-points
title: "EXTENSION_POINTS — Extension Point Specifications (Provider / Vfs / Policy, etc.)"
created: 2026-05-01
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
- aikernel
- design
- extension
- capabilities
- english
---

# EXTENSION_POINTS — Extension Point Specifications (Provider / Vfs / Policy, etc.)

## Overview
This document enumerates AIKernel.NET's extension points (replaceable components) and clarifies **what is a contract and what is implementation**. AIKernel's core principles—contract-driven, capability-based, PDP governance, DAG execution, and reproducibility—guide extension design.

## Assumption (role of this repository)
- This repository (contracts repo) provides the fixed points for Interfaces / DTOs / Enums.
- Implementations (Kernel/Providers/Server) live in separate repositories; here we define the shape of extension points.

---

## 1. Provider (Capability plugin) extensions
### 1.1 Purpose
Treat Providers by Capability rather than model name to enable replacement.

### 1.2 Contract-level requirements (examples)
- Providers must be able to declare Capabilities (what they can and cannot do).
- Provider calls are subject to Kernel routing policies and PDP governance.

### 1.3 Implementation responsibilities (separate repo)
- Provider implementations (OpenAI/Groq/Local, etc.)
- Concrete Capability values (features, constraints, latency classes)

---

## 2. ProviderRouter extension
### 2.1 Purpose
Select candidates based on Capabilities and dynamic state (health/budget/constraints).

### 2.2 Contract-level requirements
- Routing is implementation-specific, but the **input types used for decisions** are fixed as contract types.
- PDP may veto candidates.

---

## 3. Policy / PDP extension
### 3.1 Purpose
Keep LLMs as suggestors and govern boundary operations (external transmission, tool execution, persistence).

### 3.2 Contract-level requirements
- PDP returns final decisions (Allow/Deny, etc.).
- PDP must provide decision rationale suitable for audit.

### 3.3 Implementation responsibilities (separate repo)
- Concrete policies (compliance/cost/region/data classification)
- Rule evaluation engines or external policy integrations

---

## 4. Guard (Deterministic guard) extension
### 4.1 Purpose
Provide deterministic safety checks independent of LLM nondeterminism.

### 4.2 Contract-level requirements
- Guard returns verdicts (allow/deny/conditional allow).
- Guard results may feed into PDP.

---

## 5. Pipeline (DAG/Step) extension
### 5.1 Purpose
Compose use-cases (Chat/RAG/Optimization) while separating cross-cutting concerns (safety/audit/metrics).

### 5.2 Contract-level requirements
- Pipeline is represented as a DAG; TaskManager controls execution deterministically.
- Execution logs and state are the basis for replay.

---

## 6. Query Processing extension
### 6.1 Purpose
Allow Phase 1 query augmentation, decomposition, semantic projection, and query routing to be replaced without changing Core contracts.

### 6.2 Contract-level requirements
- `IQueryAugmentor`, `IQueryDecomposer`, and `IQueryRouter` receive `IKernelContext`.
- `QueryPart` is the immutable handoff DTO between query planning and context/material build.
- Provider capability metadata declares query-processing and embedding support.
- RAG stays a provider/pipeline strategy and is not pulled into Core retrieval.

---

## 7. Vfs (External data boundary) extension
### 7.1 Purpose
Separate external data sources (Git, etc.) from Providers as a data boundary.

### 7.2 Contract-level requirements
- Abstract read/write/list operations as Vfs contracts; implementations live in separate repos.

---

## 8. PromptRules / RulesEngine extension (operational artifacts)
### 8.1 Purpose
Treat PromptRules as signed Markdown operational artifacts for tamper detection and governance.

### 8.2 Contract-level requirements
- Support metadata such as signature, scope, and version.

---

## 9. Audit events (Audit/Event) extension
### 9.1 Purpose
Emit primary information to support Deterministic Replay and auditing.

### 9.2 Contract-level requirements
- Event types should be additive and backward-compatible; changes follow versioning rules.

---

## Related Documents
- `./DESIGN_INTENT.md`
- `ARCHITECTURE_DECISIONS.md`
- `CONTRACT_VERSIONING.md`
- `../architecture/index.md`
- `../guidelines/DOCUMENTATION_GUIDELINES.md`
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.1 (2026-05-09): Added Query Processing extension point
