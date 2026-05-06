---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Guidelines — Index"
created: 2026-05-01
tags:
  - aikernel
  - guideline
  - documentation
  - governance
  - english
updated: 2026-05-06
---

# AIKernel Guidelines — Index
This directory serves as the entry point for all **Guidelines** in AIKernel.NET.  
Unlike the architecture documents (Why) or design documents (How),  
the guideline documents define **rules, standards, and operational procedures** for maintaining the project.

To preserve quality, reproducibility, and governance across the entire AIKernel ecosystem,  
all guidelines follow the **Markdown-first principle**,  
with **English as the canonical version** and **Japanese as the deep-dive version**.

---

## Guideline Documents

### 1. Documentation Guidelines  
**File:** `DOCUMENTATION_GUIDELINES(.jp).md`  
**Contents:**  
- Markdown-first principle  
- English as canonical  
- File naming rules  
- Architecture document structure  
- Emoji usage restrictions  
- Governance (signatures, versions, changelogs)  
- Rules for organizing the `docs/` directory  

All AIKernel documentation must follow this guideline.

---

### 2. Docs Contributing Guide  
**File:** `DOCS_CONTRIBUTING(.jp).md`  
**Contents:**  
- Rules for documentation PRs  
- CI checks (lint, link-check, build)  
- Translation workflow (English ↔ Japanese)  
- Review structure (owners system)  
- PR checklist  

Defines the **operational rules** for contributing documentation.

---

### 3. Repository Dependency Rules  
**File:** `REPO_DEPENDENCY_RULES(.jp).md`  
**Contents:**  
- Allowed dependency directions (Core → Kernel → Providers)  
- Prohibition of circular dependencies  
- Handling of breaking changes  
- Recommended CI dependency checks  

Ensures the **architectural integrity** of the entire AIKernel ecosystem.

---

### 4. Contract Versioning Policy  
**File:** `CONTRACT_VERSIONING(.jp).md`  
**Contents:**  
- Versioning rules for Interfaces / DTOs / Enums  
- Definition of breaking changes  
- Non-breaking change rules  
- Relationship with the Migration Guide  
- SemVer governance  

Defines governance for safely evolving **Contracts**, the foundation of AIKernel.

---

### 5. Migration Guide (Planned)  
**File:** `MIGRATION_GUIDE(.jp).md`  
**Contents:**  
- Migration steps across breaking contract changes  
- Classification of changes (Breaking / Non-breaking)  
- Automated conversion tools and checklists (planned)  

Currently **Planned**. Will be created once Contracts stabilize.

---

## Purpose of Guidelines

AIKernel guidelines serve three major purposes:

### 1. Consistency  
- Document structure  
- Naming conventions  
- Versioning  
- PR workflow  

### 2. Reproducibility  
- Changelogs  
- Signatures  
- CI checks  
- Translation management  

### 3. Governance  
- Contract evolution  
- Dependency direction  
- Documentation quality assurance  

These guidelines provide the foundation for operating AIKernel as a long-term **AI OS**.

---

## Recommended Reading Order

1. **DOCUMENTATION_GUIDELINES**  
2. **DOCS_CONTRIBUTING**  
3. **REPO_DEPENDENCY_RULES**  
4. **CONTRACT_VERSIONING**  
5. **MIGRATION_GUIDE** (when available)

---

## Related Directories

- `docs/architecture/` — Architectural philosophy (Why)  
- `docs/design/` — Implementation policies (How)  
- `docs/guideline/` — Operational rules (Rules) ← *this directory*
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
