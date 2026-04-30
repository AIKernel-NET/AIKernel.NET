# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

A framework designed as an **Operating System for AI applications**.

AIKernel treats LLMs not as simple API endpoints, but as **capability‑based processes** orchestrated by an AI‑native OS kernel.

For the Japanese version of this document, see [README.jp.md](README.jp.md).

---

# 1. Purpose

AIKernel.NET aims to provide an execution platform where AI applications can run with:

- **Model‑agnostic, capability‑based execution**
- **Strict information category separation to maximize reasoning quality**
- **Deterministic scheduling + nondeterministic LLM reasoning**
- **Reproducibility (Deterministic Replay)**
- **Governance (signed PromptRules, audit logs, policy enforcement)**
- **OS‑like extensibility (Providers as drivers, Kernel as execution engine)**

---

# 2. Architecture Overview

AIKernel follows a 6‑layer OS‑inspired architecture:

```
Core (syscall layer)
Kernel (AI execution engine)
Providers (LLM / embedding / multimodal drivers)
VfsProviders (external data sources)
Server (OpenAI‑compatible API)
Hosting (application integration)
Enterprise (operations and governance extensions)
```

---

# 3. Directory Structure (Final Version)

```
AIKernel/
├─ docs/
│  ├─ architecture/
│  │  ├─ CATEGORY_SEPARATION_PRINCIPLES.md
│  │  ├─ CONTEXT_ISOLATION_SPEC.md
│  │  ├─ ATTENTION_POLLUTION_THEORY.md
│  │  ├─ PREPROCESSING_VS_PROMPTING.md
│  │  ├─ LLM_SURFACE_MODE_FAILURE.md
│  │  └─ AIKERNEL_VS_LANGCHAIN.md
│  ├─ design/
│  │  └─ DESIGN_INTENT.md
│  └─ rules/
│     └─ PromptRules_TEMPLATES/
│
├─ src/
│  ├─ Core/                      # Syscall layer (abstractions + contracts)
│  │  ├─ Abstractions/
│  │  ├─ Contracts/
│  │  ├─ KernelContext/
│  │  ├─ Events/
│  │  └─ VFS/
│  │
│  ├─ Kernel/                    # Former Runtime → renamed to Kernel
│  │  ├─ Scheduler/
│  │  ├─ Router/
│  │  ├─ Controller/
│  │  ├─ RagEngine/
│  │  ├─ Pipeline/
│  │  └─ Rules/
│  │
│  ├─ Providers/                 # “Brain drivers”
│  │  ├─ SDK/
│  │  ├─ OpenAI/
│  │  ├─ Groq/
│  │  ├─ LlamaCpp/
│  │  └─ LocalRAG/
│  │
│  ├─ VfsProviders/              # Git belongs here (not in Providers)
│  │  └─ Git/
│  │
│  ├─ Server/
│  │  └─ OpenAICompat/
│  │
│  └─ Hosting/
│     └─ Default/
│
├─ samples/
│  └─ quickstart/
│
└─ enterprise/
   └─ AIKernel.Enterprise/
```

---

# 4. Core Design Principles

## 4.1 Information Category Separation (Most Important)
AIKernel enforces strict separation of:

- purpose  
- constraints  
- structure  
- history  
- expression  
- RAG material  
- metadata  

> “Never mix categories in a single LLM context.  
> Mixing destroys attention and collapses reasoning.”

See: `docs/architecture/CATEGORY_SEPARATION_PRINCIPLES.md`

---

## 4.2 Preprocessing First
Prompting is **not** the core.  
The core is **structuring information before it reaches the model**.

See: `PREPROCESSING_VS_PROMPTING.md`

---

## 4.3 Attention Pollution Prevention
Examples, RAG fragments, and style instructions must be isolated.

See: `ATTENTION_POLLUTION_THEORY.md`

---

## 4.4 LLM as Suggestor, PDP as Decision Maker
LLMs propose.  
The Policy Decision Point (PDP) authorizes.

---

# 5. Kernel (Execution Engine)

The Kernel is the heart of AIKernel:

- **Scheduler** — deterministic task scheduling  
- **LlmController** — nondeterministic reasoning  
- **ProviderRouter** — capability‑based provider selection  
- **RagEngine** — materialization  
- **PipelineExecutor** — DAG execution  
- **RulesEngine** — PromptRules evaluation  

This separation ensures reproducibility and governance.

---

# 6. Providers (AI Drivers)

Providers declare **Capabilities**, not model names:

- chat  
- embedding  
- multimodal  
- reasoning  
- vector‑search  
- streaming  

Provider SDK enables easy extension.

---

# 7. VFS Providers (External Data Sources)

Git is not an AI provider.  
It is a **VFS implementation** and belongs under:

```
src/VfsProviders/Git/
```

---

# 8. Server (OpenAI‑Compatible API)

Allows AIKernel to be used as an OpenAI‑compatible backend.

---

# 9. Hosting

Provides:

- DI setup  
- default pipelines  
- configuration  
- application integration  

---

# 10. Enterprise

Provides:

- SIEM integration  
- multi‑tenant support  
- SLO dashboards  
- compliance tooling  

---

# 11. Contributing & License

- Contributions are welcome via PR.  
- Breaking changes must include migration guides.  
- See LICENSE for details.

---

# 12. Summary

AIKernel.NET is an **AI‑native OS** designed for:

- structural correctness  
- reproducibility  
- governance  
- capability‑based execution  
- clean separation of reasoning and expression  

Its goal is to provide a stable, extensible foundation for the next generation of AI applications.

