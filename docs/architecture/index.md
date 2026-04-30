---
version: 1.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Architecture — Index"
created: 2026-04-30
tags:
  - aikernel
  - architecture
  - index
---

# AIKernel Architecture Index
This directory contains the core architectural principles, theories, and specifications that define **AIKernel.NET** — an Operating System for AI applications.

AIKernel is built on a set of strict, theory‑driven design principles:
- **Information Category Separation**
- **Context Isolation**
- **Attention Pollution Prevention**
- **Surface Mode Failure Avoidance**
- **Preprocessing over Prompting**
- **Structural correctness over empirical prompt tuning**

These documents explain *why* AIKernel works and *why other frameworks fail structurally*.

For the Japanese version of this index, see `index.jp.md`.

---

# 1. Core Architectural Principles

## **1. Category Separation Principles**  
**File:** `1.CATEGORY_SEPARATION_PRINCIPLES.md`

The most fundamental rule of AIKernel:
> **Never mix heterogeneous information in a single LLM context.**

Mixing categories destroys attention purity and collapses reasoning.

Categories include:
- purpose  
- constraints  
- structure  
- history  
- context  
- rag_material  
- expression  
- metadata  

This principle is the foundation of all other architecture rules.

---

## **2. Context Isolation Specification**  
**File:** `2.CONTEXT_ISOLATION_SPEC.md`

AIKernel isolates information into three distinct contexts:

### **OrchestrationContext**  
Purpose, constraints, abstract structure, reasoning patterns.

### **ExpressionContext**  
Style, examples, explanations, analogies.

### **MaterialContext**  
RAG fragments, external information.

Rules:
- Examples must never enter OrchestrationContext  
- RAG material must never be mixed directly into reasoning  
- ExpressionContext is used only at output time  

---

## **3. Attention Pollution Theory**  
**File:** `3.ATTENTION_POLLUTION_THEORY.md`

LLM reasoning depends on **attention purity**.  
Pollution sources include:

- examples  
- style instructions  
- RAG fragments  
- history  
- noise  

Effects:
- reasoning collapse  
- surface imitation  
- hallucination increase  
- loss of purpose  

This theory explains why naive RAG and prompt mixing fail.

---

## **4. LLM Surface Mode Failure**  
**File:** `4.LLM_SURFACE_MODE_FAILURE.md`

When exposed to examples or stylistic patterns, LLMs fall into **surface mode**:

- imitates style  
- stops reasoning  
- loses structure  
- becomes “instantly dumb”  

AIKernel prevents this by isolating examples and expression.

---

## **5. Preprocessing vs Prompting**  
**File:** `5.PREPROCESSING_VS_PROMPTING.md`

Prompting is not the core.  
The core is **structuring information before it reaches the model**.

Misconceptions:
- “Prompt engineering is the key” → ❌  
- “Examples improve accuracy” → ❌  
- “RAG can be passed directly” → ❌  

Truth:
> **Preprocessing determines reasoning quality. Prompting is only final formatting.**

---

# 2. Comparative Architecture

## **6. AIKernel vs LangChain**  
**File:** `6.AIKERNEL_VS_LANGCHAIN.md`

LangChain issues:
- mixes all information in one context  
- passes RAG directly  
- mixes examples and history  
- destroys attention  
- produces unstable reasoning  

AIKernel advantages:
- strict category separation  
- isolated reasoning and expression layers  
- RAG materialization  
- attention pollution prevention  

Conclusion:
> LangChain “works by accident”.  
> AIKernel “works by architecture”.

---

# 3. How to Use This Architecture Section

This directory is designed to:

- explain the theoretical foundations of AIKernel  
- provide the rationale behind category separation  
- show why naive prompt‑based frameworks fail  
- prepare developers before reading Core / Kernel / Providers code  

Reading these documents in order provides a complete understanding of  
**why AIKernel is an AI‑native OS**.

---

# 4. Recommended Reading Order

1. **Category Separation Principles**  
2. **Context Isolation Specification**  
3. **Attention Pollution Theory**  
4. **Surface Mode Failure**  
5. **Preprocessing vs Prompting**  
6. **AIKernel vs LangChain**  
7. **Design Intent** (`../design/DESIGN_INTENT.md`)

---

# 5. Summary

AIKernel’s architecture is not based on prompt tricks or empirical tuning.  
It is based on **structural correctness**, **information purity**, and **OS‑level separation of concerns**.

This index serves as the entry point to the theoretical foundation of the framework.

