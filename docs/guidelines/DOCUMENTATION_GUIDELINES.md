---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Documentation Guidelines"
created: 2026-04-30
tags:
  - aikernel
  - documentation
  - guideline
  - english
---

# AIKernel.NET — Documentation Guidelines
All AIKernel documentation must follow these principles to maximize **human readability, structural purity, reproducibility, and governance**.

---

# 1. Basic Policy

## 1.1 Markdown-first
- All design docs, specifications, rules, and manifests must be written in **Markdown**.
- YAML/JSON should be embedded as code blocks in Markdown.
- Do not use PDF / Word / HTML as primary formats.

## 1.2 English is canonical; Japanese is deep-dive
- `xxx.md` → English (canonical, for OSS)
- `xxx-jp.md` → Japanese (deep-dive, additional rationale)

Reverse-translating Japanese into English is prohibited; English is the canonical version. Japanese may contain deeper explanations that remain only in Japanese.

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
1.CATEGORY_SEPARATION_PRINCIPLES.md
2.CONTEXT_ISOLATION_SPEC.md
3.ATTENTION_POLLUTION_THEORY.md
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
