---
updated: 2026-06-15
published: 2026-05-16
version: "0.1.1.1"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
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

### 1. [AIKernel Development Guidelines](AIKERNEL_DEVELOPMENT_GUIDELINES.md)
**Contents:**
- Contract-first development discipline
- Monadic LINQ use with Result / Either / Option / Try / Async
- Fail-closed execution boundaries
- DRY and DGA refactoring rules
- Public API bilingual comment requirements
- Test, package, release, and PR quality gates
- Documentation, Python wrapper, and cross-package consistency checks

Defines the primary contributor discipline for implementation, review, and
release readiness across the AIKernel package family.

---

### 2. [Documentation Guidelines](DOCUMENTATION_GUIDELINES.md)  
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

### 3. [Docs Contributing Guide](DOCS_CONTRIBUTING.md)  
**Contents:**  
- Rules for documentation PRs  
- CI checks (lint, link-check, build)  
- Translation workflow (English ↔ Japanese)  
- Review structure (owners system)  
- PR checklist  

Defines the **operational rules** for contributing documentation.

---

### 4. [Repository Dependency Rules](REPO_DEPENDENCY_RULES.md)  
**Contents:**  
- Allowed dependency directions (Core → Kernel → Providers)  
- Prohibition of circular dependencies  
- Handling of breaking changes  
- Recommended CI dependency checks  

Ensures the **architectural integrity** of the entire AIKernel ecosystem.

---

### 5. [Concept Elevation Guidelines](concept-elevation-guidelines.md)
**Contents:**
- Canonical philosophical vocabulary usage rules
- Concept Elevation as more than rename
- Allowed and forbidden layers
- Concept Weight Rule
- CTG-ROM safety rule
- Architecture test requirements

Defines the pre-coding naming discipline for v0.2.x Concept Elevation
Refactoring across AIKernel implementation repositories.

---

### 6. Contract Versioning Policy
**Contents:**  
- Versioning rules for Interfaces / DTOs / Enums  
- Definition of breaking changes  
- Non-breaking change rules  
- Relationship with the Migration Guide
- SemVer governance  

Defines governance for safely evolving **Contracts**, the foundation of AIKernel.

---

### 7. [Concept Elevation Migration Notes](../migration/concept-elevation-v0.1.1.1.md)
**Contents:**
- Add-only compatibility policy for v0.1.1.1
- Repository-by-repository migration plan
- CTG-ROM safety checklist
- Future coding phase boundaries

Defines the compatibility envelope before Concept Elevation implementation begins.

---

### 8. [Repository Alignment v0.1.1.1](../development/repository-alignment-v0.1.1.1.md)
**Contents:**
- Cross-repository responsibility boundaries
- 0.1.1.1 local NuGet package versioning
- NuGet-only / no-PyPI scope for this update line
- Thin-surface rule for 0.1.3 contract promotion

Defines the canonical operating envelope for AIKernel.NET, Core, Providers,
Cuda13.0, Control, Tools, Wasm, Demo, and Doom during 0.1.1.1 development.

---

### 9. Migration Guide (Planned)
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

1. **AIKERNEL_DEVELOPMENT_GUIDELINES**
2. **DOCUMENTATION_GUIDELINES**  
3. **DOCS_CONTRIBUTING**  
4. **REPO_DEPENDENCY_RULES**  
5. **CONCEPT_ELEVATION_GUIDELINES**
6. **CONTRACT_VERSIONING**
7. **REPOSITORY_ALIGNMENT_V0.1.1.1**
8. **MIGRATION_GUIDE** (when available)

---

## Related Directories

- `docs/architecture/` — Architectural philosophy (Why)  
- `docs/design/` — Implementation policies (How)  
- `docs/guidelines/` — Operational rules (Rules) ← *this directory*
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
