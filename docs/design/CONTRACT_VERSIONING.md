---
id: contract-versioning
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "CONTRACT_VERSIONING — Contract (Interface/DTO/Enum) Versioning Policy"
created: 2026-05-01
tags:
- aikernel
- design
- contracts
- versioning
- governance
- english
updated: 2026-05-06
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

Note:
- Adding interfaces can affect implementers; always document compatibility impact.

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
