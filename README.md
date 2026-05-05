# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

A framework aiming to be the **Operating System (OS) for AI applications**.

AIKernel treats LLMs not as simple API calls but as **capability-bearing processes**.

---

## NuGet Packages

AIKernel.NET is composed of multiple independent abstraction layers.  
Each layer is published as a separate NuGet package.

| Layer | Package | Version | Link |
|-------|---------|---------|------|
| Core Types | AIKernel.Enums | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Enums.svg) | https://www.nuget.org/packages/AIKernel.Enums/ |
| Data Models | AIKernel.Dtos | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Dtos.svg) | https://www.nuget.org/packages/AIKernel.Dtos/ |
| Contracts | AIKernel.Contracts | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Contracts.svg) | https://www.nuget.org/packages/AIKernel.Contracts/ |
| Abstractions | AIKernel.Abstractions | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Abstractions.svg) | https://www.nuget.org/packages/AIKernel.Abstractions/ |
| Kernel Context | AIKernel.KernelContext | ![NuGet](https://img.shields.io/nuget/v/AIKernel.KernelContext.svg) | https://www.nuget.org/packages/AIKernel.KernelContext/ |
| Virtual File System | AIKernel.VFS | ![NuGet](https://img.shields.io/nuget/v/AIKernel.VFS.svg) | https://www.nuget.org/packages/AIKernel.VFS/ |
| Event System | AIKernel.Events | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Events.svg) | https://www.nuget.org/packages/AIKernel.Events/ |

---

See `docs/design/DESIGN_INTENT.md` for design philosophy.  
For executable contracts (spec sheets), see `docs/specs/index.md`.

Target experience (boot log example):
```txt
[KERNEL] Initializing AIKernel.NET v0.1.0...
[KERNEL] Loading ISignatureTrustStore... [OK]
[KERNEL] Mounting VFS (Git: ./context)... [OK]
[KERNEL] Verifying System Prompt Signature... [VALID]
[KERNEL] Routing to Provider: [[provider.reasoning.high]]... [OK]

> Hello Intelligence.
> The Semantic Context is stable. Governance is active.
```

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

Documentation is organized into four layers:
- `docs/architecture`: Why (principles, theory, governance)
- `docs/design`: How (design decisions and implementation strategy)
- `docs/specs`: What (executable contracts and verifiable requirements)
- `docs/guidelines`: operational and contribution rules

---

# 3. AIKernel.NET directory layout (current)

```
AIKernel.NET/
├─ README.md
├─ README-jp.md
├─ LICENSE
├─ docs/
│  ├─ CONTRIBUTING.md
│  ├─ CONTRIBUTING-jp.md
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
│  │  ├─ index.md
│  │  ├─ index-jp.md
│  │  ├─ DESIGN_INTENT.md
│  │  ├─ DESIGN_INTENT-jp.md
│  │  ├─ ARCHITECTURE_DECISIONS.md
│  │  ├─ ARCHITECTURE_DECISIONS-jp.md
│  │  ├─ EXTENSION_POINTS.md
│  │  ├─ EXTENSION_POINTS-jp.md
│  │  ├─ DI_GUIDE.md
│  │  ├─ DI_GUIDE-jp.md
│  │  ├─ CONTRACT_VERSIONING.md
│  │  ├─ CONTRACT_VERSIONING-jp.md
│  │  ├─ SEMANTIC_SNAPSHOT_FORMAT.md
│  │  └─ SEMANTIC_SNAPSHOT_FORMAT-jp.md
│  ├─ specs/
│  │  ├─ index.md
│  │  ├─ index-jp.md
│  │  ├─ 01.EXECUTION_PIPELINE_SPEC.md
│  │  ├─ 01.EXECUTION_PIPELINE_SPEC-jp.md
│  │  ├─ 02.SIGNED_PROMPT_GOVERNANCE_SPEC.md
│  │  ├─ 02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md
│  │  ├─ 03.ROM_CORE_SPEC.md
│  │  ├─ 03.ROM_CORE_SPEC-jp.md
│  │  ├─ 04.MODEL_ROUTING_SPEC.md
│  │  ├─ 04.MODEL_ROUTING_SPEC-jp.md
│  │  ├─ 05.MATERIAL_QUARANTINE_SPEC.md
│  │  ├─ 05.MATERIAL_QUARANTINE_SPEC-jp.md
│  │  ├─ 06.REPLAY_DUMP_SPEC.md
│  │  └─ 06.REPLAY_DUMP_SPEC-jp.md
│  ├─ guidelines/
│  │  ├─ index.md
│  │  ├─ index-jp.md
│  │  ├─ DOCUMENTATION_GUIDELINES.md
│  │  ├─ DOCUMENTATION_GUIDELINES-jp.md
│  │  ├─ DOCS_CONTRIBUTING.md
│  │  ├─ DOCS_CONTRIBUTING-jp.md
│  │  ├─ REPO_DEPENDENCY_RULES.md
│  │  ├─ REPO_DEPENDENCY_RULES-jp.md
│  ├─ operations/                # TBD: Planned.
│  │  ├─ index.md
│  │  ├─ index-jp.md
│  │  ├─ MIGRATION_GUIDE.md
│  │  └─ MIGRATION_GUIDE-jp.md
│  └─ rules/
│     └─ PromptRules_TEMPLATES/  # TBD: Coming Soon.
│
├─ src/
│  ├─ AIKernel.NET.slnx
│  ├─ README.md
│  ├─ README.jp.md
│  ├─ AIKernel.Abstractions/
│  ├─ AIKernel.Contracts/
│  ├─ AIKernel.Dtos/
│  ├─ AIKernel.Enums/
│  ├─ AIKernel.Events/
│  ├─ AIKernel.KernelContext/
│  ├─ AIKernel.VFS/
│  └─ tests/
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

## 4.5 Signed Prompt Governance and Fail-Closed
Prompts carry authority equivalent to code execution.  
AIKernel executes only approved, signed prompts and halts immediately when tampering or untrusted signers are detected.

- Verification sequence: `IPromptRepository` -> `IPromptVerifier` -> `ISignatureTrustStore` -> `IPromptValidator` -> `ExecutionPipeline`
- Detailed spec: `docs/specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC.md`

## 4.6 Relation-Oriented Data Structure (Relation-Oriented Markdown: ROM)
AIKernel treats knowledge not as linear text but as a set of relations.

- `YAML`: Defines entity metadata and identity.
- `Headings`: Define semantic categories and contextual scopes.
- `Bullets`: Declaratively express facts and properties.
- `Links` (`[[id]]`): Represent graph edges between entities.
- `Semantic Hash`: Uses order-insensitive canonical hashing to strengthen signature verification.

With ROM, human-authored notes can be transformed directly into an LLM-reasonable knowledge base.

## 4.7 Git-Managed Reasoning (ConversationStore)
AI conversations are managed not as linear logs but as tree-structured Git commits.  
This natively supports reasoning forks and point-in-time replay.

---

# 5. Kernel (formerly Runtime)

Kernel is the core OS:
- TaskManager (deterministic scheduler)
- LlmController (nondeterministic inference)
- ProviderRouter (capability-based brain selection)
- RagEngine (materialization)
- PipelineExecutor (DAG execution)
- RulesEngine (PromptRules)
- IPromptVerifier / IPromptValidator (runtime signature verification for fail-closed enforcement)
- ISignatureTrustStore (trust anchor managing trusted signers and revocation state)

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

For implementation, lock contracts first by following `docs/specs/index.md`, then apply implementation strategy from `docs/design`.
