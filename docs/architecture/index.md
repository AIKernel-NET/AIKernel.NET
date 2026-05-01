---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Architecture — Index"
created: 2026-04-30
tags:
  - aikernel
  - architecture
  - index
  - english
---

# AIKernel Architecture Index
This document is the entry point to the set of documents that systematically present the architectural philosophy of AIKernel.NET.

AIKernel aims to be the **Operating System (OS) for AI applications**. Its core principles are **category separation, preprocessing-first design, attention pollution prevention, and separation of inference and expression**.

This index functions as a guide to understand AIKernel's design principles, theoretical background, and structural comparisons.

---

# 1. Core Architectural Principles

## 1.1 Principles of Category Separation
**File:** `1.CATEGORY_SEPARATION_PRINCIPLES.md`

Information passed to an LLM must not be mixed into a single context. Mixing information destroys attention, halts inference, and triggers surface-mode behavior.

**Category examples:**
- purpose
- constraints
- structure
- history
- rag_material
- expression
- metadata

> "Information passed to an LLM must not be mixed into a single context."
> — CATEGORY_SEPARATION_PRINCIPLES.md

---

## 1.2 Context Isolation Specification
**File:** `2.CONTEXT_ISOLATION_SPEC.md`

AIKernel separates information into three layers before passing it to an LLM:

- **OrchestrationContext** (inference)
- **ExpressionContext** (expression)
- **MaterialContext** (material)

Examples, stylistic instructions, and RAG fragments must not be mixed into inference.

---

## 1.3 Theory of Attention Pollution
**File:** `3.ATTENTION_POLLUTION_THEORY.md`

An LLM's inference capability depends on the purity of attention. Examples, stylistic mimicry, RAG fragments, and history divert attention to surface structures and halt inference.

> "When attention is drawn to surface structures, inference halts, and the system falls into surface-mode failure."
> — ATTENTION_POLLUTION_THEORY.md

---

## 1.4 Risks of Surface-Mode Failure
**File:** `4.LLM_SURFACE_MODE_FAILURE.md`

When exposed to examples, LLMs can enter a "non-inferential mode." This is one reason AIKernel isolates examples.

---

## 1.5 Preprocessing vs Prompting
**File:** `5.PREPROCESSING_VS_PROMPTING.md`

The essence is **structuring preprocessing**, not prompt design. What is included in attention and what is isolated determines inference accuracy.

---

# 2. Comparative Architecture

## 2.1 AIKernel vs LangChain
**File:** `6.AIKERNEL_VS_LANGCHAIN.md`

Issues with LangChain:
- All information is mixed into a single context.
- RAG is passed as-is.
- Examples and history are mixed.
- Attention is disrupted.

Features of AIKernel:
- Category separation
- Separation of inference and expression layers
- Isolation of examples
- Structuring of RAG
- Prevention of attention pollution

> "LangChain is a structure that 'works by chance.' AIKernel is an architecture that 'works correctly by design.'"

---

# 3. Architectural Philosophy

## 3.1 Design Intent
**File:** `../design/DESIGN_INTENT.md`

AIKernel's design philosophy:
- Markdown-first principle (human readability)
- Core = Abstractions + Contracts (JSON Schema)
- Provider = Capability-based
- LLM as suggestor, PDP as decision-maker
- Pipeline = DAG
- PromptRules = Signed Markdown
- Deterministic Replay (reproducibility)

---

# 4. How to Use This Architecture Section

The `architecture/` directory is structured to:
- Explain AIKernel's philosophy
- Explain why category separation is necessary
- Clarify structural differences from frameworks like LangChain
- Provide prerequisite knowledge before reading implementation (Core / Kernel / Providers)

Reading this index and the linked documents in order will help you understand **why AIKernel is the "OS for AI applications."**

---

# 5. Recommended Reading Order

1. CATEGORY_SEPARATION_PRINCIPLES
2. CONTEXT_ISOLATION_SPEC
3. ATTENTION_POLLUTION_THEORY
4. LLM_SURFACE_MODE_FAILURE
5. PREPROCESSING_VS_PROMPTING
6. AIKERNEL_VS_LANGCHAIN
7. DESIGN_INTENT

---

# 6. Conclusion

AIKernel's architecture is not something that "works by chance."
It is an **OS-level approach designed to work correctly by structure.**

This index is the entry point to understanding AIKernel's overall design.
