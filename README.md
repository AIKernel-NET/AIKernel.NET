# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

A framework aiming to be the **Operating System (OS) for AI applications**.

AIKernel treats LLMs not as simple API calls but as **capability-bearing processes**.

See `docs/design/DESIGN_INTENT.md` for design philosophy.

---

# 1. Purpose

AIKernel.NET aims to provide an OS that enables AI applications with:
- capability-based execution independent of model names
- category separation to maximize inference purity
- deterministic scheduler + nondeterministic LLM hybrid control
- reproducibility (Deterministic Replay)
- governance (signed PromptRules / audit logs)
- OS-like extensibility (Provider = driver / Kernel = execution engine)

---

# 2. Architecture Overview

AIKernel.NET defines abstractions and provides minimal DTOs/Enums. Implementations are separated to preserve Core purity.

```
AIKernel architecture layers (OS-like):
Core (syscall)
Kernel (AI OS core)
Providers (brain drivers)
VfsProviders (external data sources)
Server (external API adapter)
Hosting (app integration)
Enterprise (operations extensions)
```

---

# 3. AIKernel.Core directory layout (current)

```
AIKernel.NET/
├─ docs/
│  ├─ assets/
│  │  └─ aikernel-logo.png
│  ├─ architecture/
│  │  ├─ index.md
│  │  ├─ index-jp.md
│  │  ├─ 1.CATEGORY_SEPARATION_PRINCIPLES.md
│  │  ├─ 1.CATEGORY_SEPARATION_PRINCIPLES-jp.md
│  │  ├─ 2.CONTEXT_ISOLATION_SPEC.md
│  │  ├─ 2.CONTEXT_ISOLATION_SPEC-jp.md
│  │  ├─ 3.ATTENTION_POLLUTION_THEORY.md
│  │  ├─ 3.ATTENTION_POLLUTION_THEORY-jp.md
│  │  ├─ 4.LLM_SURFACE_MODE_FAILURE.md
│  │  ├─ 4.LLM_SURFACE_MODE_FAILURE-jp.md
│  │  ├─ 5.PREPROCESSING_VS_PROMPTING.md
│  │  ├─ 5.PREPROCESSING_VS_PROMPTING-jp.md
│  │  ├─ 6.AIKERNEL_VS_LANGCHAIN.md
│  │  └─ 6.AIKERNEL_VS_LANGCHAIN-jp.md
│  ├─ design/
│  │  ├─ DESIGN_INTENT.md
│  │  └─ DESIGN_INTENT-jp.md
│  └─ rules/
│     └─ PromptRules_TEMPLATES/  # TBD: Coming Soon.
│
├─ src/
│ ├─ AIKernel.Abstractions/
│ ├─ AIKernel.Contracts/
│ ├─ AIKernel.Dtos/
│ ├─ AIKernel.Enums/
│ ├─ AIKernel.Events/
│ ├─ AIKernel.KernelContext/
│ └─ AIKernel.VFS/
└─ AIKernel.NET.sln
```

# Repository mapping

| Repository | Contained solutions/projects | Example directories | Artifacts | Main dependencies |
| --- | --- | --- | --- | --- |
| **AIKernel.NET** | Contracts layer (shared) | `Contracts` (Interfaces; DTO; Enums) | NuGet contract packages | none (top-level contracts) |
| **AIKernel.Core** | Core platform | `Core/`, `Kernel/`, `Providers/`, `VfsProviders/`, `Server/`, `Hosting/` | NuGet libraries | **AIKernel.NET** |
| **AIKernel.SDK** | Client libraries | `AIKernel.SDK` | NuGet client packages | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Web** | Admin console | `admin-web` (SPA/Blazor) | SPA build artifacts | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Infra** | Deployment definitions | `terraform/`, `k8s/`, `helm/` | Manifests | all repos |
| **AIKernel.Tools** | Dev tools & CI templates | `cli/`, `generators/`, `ci-templates/` | CLI binaries; CI templates | all repos |
| **AIKernel.Docs** | Documentation aggregation | `architecture/`, `runbooks/` | Documentation site | all repos |
| **AIKernel.Enterprise** | Enterprise solutions | `solutions/`, `services/`, `workers/`, `charts/` | Private container images; Helm charts | **AIKernel.NET**, **AIKernel.Core**, **AIKernel.Infra** |

---

# 4. Design Principles

## 4.1 Category separation (most important)
- Orchestration (inference)
- Expression (output shaping)
- Material (external data)
- History
- Style

Do not mix these categories.

> "Information passed to an LLM must not be mixed into a single context." — CATEGORY_SEPARATION_PRINCIPLES.md

---

## 4.2 Preprocessing-first
Prompts are the final formatting step.

> Inference quality is determined by preprocessing structure. — PREPROCESSING_VS_PROMPTING.md

---

## 4.3 Attention pollution prevention
Mixing examples, RAG, and history breaks inference.

> When attention is drawn to surface structures, inference halts. — ATTENTION_POLLUTION_THEORY.md

---

## 4.4 LLM as suggestor, PDP as decision-maker
LLM is a suggestor; PDP makes final decisions.

---

# 5. Kernel (formerly Runtime)

Kernel is the core OS:
- TaskManager (deterministic scheduler)
- LlmController (nondeterministic inference)
- ProviderRouter (capability-based brain selection)
- RagEngine (materialization)
- PipelineExecutor (DAG execution)
- RulesEngine (PromptRules)

---

# 6. Providers (brain drivers)

Providers declare **Capabilities** rather than model names:
- chat
- embedding
- multimodal
- reasoning
- vector-search
- streaming

Providers are extensible via SDKs.

---

# 7. VFS Providers (Git, etc.)

Treat Git as an external data source (VFS), not a Provider.

---

# 8. Server (OpenAI-compatible API)

Adapter to expose AIKernel as an OpenAI-compatible API.

---

# 9. Hosting

- DI
- default pipelines
- configuration
- app integration

---

# 10. Enterprise

- SIEM integration
- multi-tenant support
- SLO dashboards

---

# 11. License / Contribution

- PR-based contributions
- Explicit compatibility for Contracts and PromptRules
- Attach migration guides for breaking changes

---

# 12. Final Note

AIKernel.NET provides a **structurally correct AI execution platform** as an OS.
It aims to be the standard OS for AI applications by focusing on category separation, preprocessing-first design, governance, and reproducibility.
