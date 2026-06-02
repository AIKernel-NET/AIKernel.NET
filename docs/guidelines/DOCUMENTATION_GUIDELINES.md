---
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel.NET — Documentation Guidelines
All AIKernel documentation must follow these principles to maximize **human readability, structural purity, reproducibility, and governance**.

---

# 1. Basic Policy

## 1.1 Markdown-first
- All design docs, specifications, rules, and manifests must be written in **Markdown**.
- YAML/JSON should be embedded as code blocks in Markdown.
- Do not use PDF / Word / HTML as primary formats.

## 1.2 Bilingual symmetry is mandatory
- Manage `xxx.md` and `xxx-jp.md` strictly as a pair.
- Keep heading levels, bullet counts, and code-block content aligned between Japanese and English.
- Do not apply unilateral edits; update both files in the same PR.

## 1.3 Repository scope (contracts repo)
This repository provides **contracts (Interfaces / minimal DTOs / Enums)** for AIKernel.NET.
Implementations (Kernel / Providers / Server, etc.) are developed in separate repositories.

## 1.4 Versioning (0.0.0 during review)
While Japanese drafts are under review, set document/contract version to **0.0.0**.
When stable, reflect changes into English and update SemVer.

---

# 2. File Naming Rules

## 2.1 Numbered architecture files
```
1.1.CATEGORY_SEPARATION_PRINCIPLES.md
2.CONTEXT_ISOLATION_SPEC.md
3.3.ATTENTION_POLLUTION_THEORY.md
4.LLM_SURFACE_MODE_FAILURE.md
5.PREPROCESSING_VS_PROMPTING.md
6.AIKERNEL_VS_LANGCHAIN.md
index.md
```
Japanese versions append `-jp.md`.

## 2.2 README at repository root
- `README.md` (English)
- `README.jp.md` (Japanese)

## 2.3 PromptRules / PipelineManifests use SemVer + ID
Examples:
```
default-safety-v0.0.0.md
minimal-dag-v0.0.0.md
```

---

# 3. Style Guidelines

## 3.1 Emoji usage
- English README: limited emoji allowed with accompanying text (e.g., ✔ / ❌ plus the word)
- Japanese README: minimize emoji
- architecture: emoji prohibited
- PromptRules: emoji prohibited

## 3.2 Prohibitions
- Platform-dependent characters (circled numbers, full-width symbols)
- Excessive decorative emoji
- Metaphors without context
- Mixing examples into inference explanations

## 3.3 Recommended style
- Short, clear paragraphs
- Use lists
- Prefer Principle → Reason → Conclusion order
- Emphasize important terms with **bold**
- Include English terms for technical words

---

# 4. Content Guidelines

## 4.1 Maintain category separation
Documents must follow AIKernel's category separation principle and avoid mixing categories.

## 4.2 Examples must not be mixed into inference explanations
Architecture documents should avoid examples and remain abstract.

## 4.3 Do not mix RAG material into documents
Minimize external citations and always cite sources.

## 4.4 docs/operations for operations content
Operational docs (Migration Guide, runbooks, release procedures) belong in `docs/operations/`. If a document is planned, mark `status: Planned` and include `TBD` at the top.

---

# 5. Structural Guidelines

## 5.1 Recommended document structure
```
Title
Summary (required)
Background (optional)
Principles / Theory / Specification (required)
Rationale (required)
Conclusion (required)
Related documents (optional)
```



## 5.2 architecture documents: "philosophy → principles → spec → conclusion"
Example flow:
- Theory (Attention Pollution)
- Principle (Category Separation)
- Spec (Context Isolation)
- Comparison (LangChain)
- Conclusion (AIKernel advantages)

---

# 6. Governance and Reproducibility

## 6.1 All docs under Git
- Keep diffs readable
- Write YAML/JSON one meaning per line

## 6.2 Signed PromptRules / Manifests
Include:
- `issuer`
- `version`
- `signature`
- `scope`

## 6.3 Always include a changelog
Example:

```
Changelog
v0.0.0 Draft

v0.0.1 Review: applied issue #123

v0.1.0 Context Isolation update
```

## 6.4 Test operations (not mandatory initially)
Initially, this repo prioritizes contracts; include build-only CI (dotnet build). Add tests for dependency direction and breaking-change detection when contracts stabilize.

---

# 7. Cross-linking

## 7.1 README ↔ architecture/index.md
- README links to architecture
- architecture/index.md links back to README

## 7.2 English ↔ Japanese
At the top of each file include:

For Japanese version, see xxx-jp.md


---

# 8. Rules by document type

## 8.1 architecture
- No emoji
- No examples
- High abstraction
- Clear principles and rationale

## 8.2 design
- Bridge between philosophy and implementation
- Include both abstract and concrete details

## 8.3 rules (PromptRules)
- YAML + Markdown
- Signed
- No emoji

## 8.4 provider docs
- Capability-based
- Avoid model-name dependent explanations

## 8.5 docs/design and docs/operations naming
- Prefer index.md for navigation rather than numbering

## 8.6 ADR
- Number ADRs for traceability (e.g., docs/design/adr/ADR-0001-*.md)

---

# 9. Final Note

AIKernel documentation is part of the architecture itself.
This guideline ensures consistent reflection of AIKernel's principles (category separation, preprocessing-first, attention purity, OS-like structure) across all documents.

---

# 10. AI-Native Integrity Rules (Mandatory)

## 10.1 Use full abstraction type names
- Use exact type names such as `ContextFragment`, `ExpressionBuffer`, `IModelVectorRouter`, and `IComputeShapeAdvisor` instead of descriptive aliases.
- Wrap type names in backticks.

## 10.2 Stay synchronized with the latest architecture
- Align documentation with the `UC-01` through `UC-14` use-case catalog.
- Preserve assumptions around `ModelCapacityVector` and NPU/dynamic-cardinality support.
- Do not use model-name-dependent guidance (including deprecated model naming examples).

## 10.3 Fail-Closed security language
- Treat signature verification by `IPromptVerifier` as an execution precondition, not a recommendation.
- Explicitly state that verification failure must stop execution (fail-closed).
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
