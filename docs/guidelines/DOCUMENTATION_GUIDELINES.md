---
version: 1.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Documentation Guidelines"
created: 2026-04-30
tags:
  - aikernel
  - documentation
  - guideline
---

# AIKernel.NET — Documentation Guidelines
All documentation in AIKernel must follow the principles defined here.  
The goal is to maximize **human readability, structural purity, reproducibility, and governance**.

---

# 1. Fundamental Principles

## 1.1 Markdown First
- All design documents, specifications, rules, and manifests must be written in **Markdown**.
- YAML/JSON must be embedded as code blocks within Markdown.
- PDF, Word, and HTML formats are not used.

## 1.2 English as the canonical version, Japanese as the deep‑dive version
- `xxx.md` → English version (canonical, OSS‑facing)
- `xxx.jp.md` → Japanese version (deep explanations, additional context, philosophical details)

The Japanese version is **not required to be a direct translation**;  
it may contain deeper explanations that are more naturally expressed in Japanese.

---

# 2. File Naming Rules

## 2.1 Architecture documents must be numbered
```
1.CATEGORY_SEPARATION_PRINCIPLES.md
2.CONTEXT_ISOLATION_SPEC.md
3.ATTENTION_POLLUTION_THEORY.md
4.LLM_SURFACE_MODE_FAILURE.md
5.PREPROCESSING_VS_PROMPTING.md
6.AIKERNEL_VS_LANGCHAIN.md
index.md
```

Japanese versions use `.jp.md`.

## 2.2 README files must be placed at the repository root
- `README.md` (English)
- `README.jp.md` (Japanese)

## 2.3 PromptRules / PipelineManifests use SemVer + ID
Example:
```
default-safety-v1.0.0.md
minimal-dag-v1.0.0.md
```

---

# 3. Style Guidelines

## 3.1 Use of emoji
- English README → limited emoji allowed (✔ / ❌), but always accompanied by text (e.g., ❌ Incorrect.)
- Japanese README → emoji should be minimal
- architecture → emoji prohibited (to preserve conceptual purity)
- PromptRules → emoji prohibited (for machine‑readability and stability)

## 3.2 Prohibited elements
- Platform‑dependent characters (①②③, full‑width symbols, etc.)
- Decorative or excessive emoji
- Metaphors without context
- Mixing examples into reasoning explanations (violates AIKernel principles)

## 3.3 Recommended style
- Short, clear paragraphs
- Frequent use of bullet points
- Structure: **Principle → Reason → Conclusion**
- Use **bold** for important terms
- Provide English terms for technical concepts (e.g., 推論 / reasoning)

---

# 4. Content Guidelines

## 4.1 Maintain information category separation
Documentation must follow the same principles as AIKernel itself:  
**never mix heterogeneous categories**.

Examples of categories:
- Principle  
- Theory  
- Specification  
- Comparison  
- Implementation  
- Operations  

Each must be placed in separate documents.

## 4.2 Do not mix examples into reasoning explanations
Architecture documents must avoid examples and focus on abstract structure.

## 4.3 Do not embed RAG material into documents
External references should be minimal and must include proper attribution.

---

# 5. Structural Guidelines

## 5.1 Recommended structure for all documents
```
# Title
Summary (required)
Background (optional)
Principles / Theory / Specification (required)
Reasoning (required)
Conclusion (required)
Related Documents (optional)
```

## 5.2 Architecture documents follow:
**Philosophy → Principles → Specification → Comparison → Conclusion**

Example flow:
- Theory (Attention Pollution)
- Principle (Category Separation)
- Specification (Context Isolation)
- Comparison (LangChain)
- Conclusion (Why AIKernel is structurally correct)

---

# 6. Governance and Reproducibility

## 6.1 All documents must be version‑controlled in Git
- Markdown must be structured so diffs are readable
- YAML/JSON must follow “one meaning per line”

## 6.2 PromptRules / Manifests must include signatures
Required fields:
- `issuer`
- `version`
- `signature`
- `scope`

## 6.3 All documents must include a changelog
Example:
```
## Changelog
- v1.0.0 Initial version
- v1.1.0 Updated Context Isolation section
```

---

# 7. Cross‑linking Rules

## 7.1 README ↔ architecture/index.md
- README must link to architecture/index.md
- architecture/index.md must link back to README

## 7.2 English ↔ Japanese versions
Each file must include at the top:

```
For the Japanese version, see xxx.jp.md
```

---

# 8. Rules by Document Type

## 8.1 architecture (conceptual documents)
- No emoji
- No examples
- High abstraction
- Principles and reasoning must be explicit

## 8.2 design (Design Intent)
- Bridge between philosophy and implementation
- May include both abstract and concrete content

## 8.3 rules (PromptRules)
- YAML + Markdown
- Signature required
- Emoji prohibited

## 8.4 provider documentation
- Must describe capabilities, not model names
- Avoid model‑specific behavior unless necessary

---

# 9. Final Note

Documentation in AIKernel is not merely descriptive;  
it is **part of the architecture itself**.

These guidelines ensure that AIKernel’s core philosophy  
— category separation, preprocessing‑first, attention purity, and OS‑level structure —  
is consistently reflected across all documents.

