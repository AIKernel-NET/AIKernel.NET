---
id: contract-versioning
title: "CONTRACT_VERSIONING — Contract (Interface/DTO/Enum) Versioning Policy"
created: 2026-05-01
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
- aikernel
- design
- contracts
- versioning
- governance
- english
---

# CONTRACT_VERSIONING — Contract (Interface/DTO/Enum) Versioning Policy

## Overview
This document defines versioning policy for AIKernel.NET contracts (Interfaces/DTOs/Enums/Schemas). Contracts are central to AIKernel's contract-driven approach, so compatibility rules are core governance.

---

## 1. Scope (What is a "Contract")
Contracts include:
- Public interfaces (Core abstract APIs)
- DTOs and Enums
- JSON Schema and other format specifications used for storage/communication
- Audit event and execution context schemas (basis for reproducibility)

---

## 2. Versioning Basics (SemVer)

### 2.1 0.0.0 phase (review)
During review, set contract/document versions to 0.0.0 to indicate instability and potential breaking changes.

### 2.2 SemVer handling
- **Major**: breaking changes
- **Minor**: backward-compatible additions
- **Patch**: bug fixes, comments, docs (no compatibility impact)

---

## 3. Definition of Breaking Changes
Treat the following as breaking:
- Removal or signature change of interface methods/properties
- Deletion or semantic change of DTO/Enum values that breaks compatibility
- Adding required fields to schemas

Principle:
- Breaking changes must be accompanied by an Issue/ADR documenting rationale, impact, and migration plan.

---

## 4. Non-breaking Changes
Generally considered non-breaking:
- Adding optional fields to DTOs
- Adding enum values (without changing existing meanings)
- Adding interface members in ways that do not break existing implementations
- Moving public contract ownership between packages when namespace, type identity compatibility, and migration guidance are preserved through type forwarding

Note:
- Adding interfaces can affect implementers; always document compatibility impact.
- Compatibility facades must clearly state the new owning package and the unsupported dependency direction. The temporary `AIKernel.Vfs` facade from v0.0.3 was removed in v0.0.4; consumers now reference `AIKernel.Abstractions` directly.
- Breaking interface renames, such as the v0.0.4 `IKernelContextExecutor` / `IChatTurnVerificationResult` / `IChatTurnSemanticHasher` cleanup, must be listed in the migration guide before package publication.
- Contract-surface purity cleanup, such as v0.0.5 removal of DTOs, enums, and exception implementations from contract packages, is a breaking change and must include explicit type replacement tables.

---

## 5. Deprecation Policy
- Prefer a deprecation period before removal when possible
- Document alternatives in docs and comments
- Consolidate migration steps in `MIGRATION_GUIDE` (operations) when available

---

## 6. Contract Classification and Responsibilities (avoid mixing)
To align with category separation and context isolation:
- Do not mix Orchestration (inference), Expression, and Material concerns in the same contract
- Avoid implementation-specific behavior in contracts; keep those in implementation repos
- Keep `AIKernel.Abstractions` and `AIKernel.Contracts` interface-only. DTOs belong in `AIKernel.Dtos`; shared enum primitives belong in `AIKernel.Enums`; runtime exceptions and result/failure adapters belong in implementation packages such as `AIKernel.Core` or `AIKernel.Common`.

---

## 7. Release Metadata to Publish
For each release, publish:
- Contract version (SemVer)
- Breaking / Non-breaking classification
- Impact scope (which interfaces/DTOs/Enums changed)
- Migration highlights (link to operations docs)

---

## Related Documents
- `./DESIGN_INTENT.md`
- `ARCHITECTURE_DECISIONS.md`
- `EXTENSION_POINTS.md`
- `../architecture/index.md`
- `../guidelines/DOCUMENTATION_GUIDELINES.md`
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.3 (2026-06-02): Added package ownership/type-forwarding compatibility guidance
- v0.0.4 (2026-06-04): Added explicit guidance for ambiguous-interface renames and contract extraction releases
- v0.0.5 (2026-06-05): Added contract-surface purity cleanup guidance for interface-only packages
