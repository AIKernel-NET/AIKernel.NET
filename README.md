---
updated: 2026-11-12
published: 2026-06-16
version: "0.1.3"
edition: "Release"
status: "Release"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

AIKernel is a .NET foundation for composing AI execution conditions, external capabilities, and inspectable records. This repository owns the shared contracts: interfaces, DTOs, enums, and boundary types.

**AIKernel.Core** supplies runtime behavior; **AIKernel.Providers** and other packages supply external integrations. Start with a runnable sample, then choose the capabilities your application needs.

## Start here

1. [What AIKernel helps you build](docs/overview/what-is-aikernel.md).
2. [Run your first sample](docs/overview/quick-start.md), without an API key or GPU.
3. [Read and change the sample](docs/tutorials/first-kernel.md) to connect its output to code.

| Your task | Guide |
| --- | --- |
| Choose dependencies | [Package responsibilities](docs/architecture/module-map.md) |
| Connect a model or service | [Provider guide](docs/providers/provider-model.md) |
| Fix setup or startup | [Troubleshooting](docs/runtime/index.md) |
| Look up exact types and members | [API Reference](https://aikernel.net/reference/) |

[All guides](docs/index.md) · [Develop with an AI assistant](https://aikernel.net/en/ai/) · [日本語](README-jp.md)

The [0.1.4 upgrade guide](docs/overview/upgrade-0-1-4.md) covers model selection and how to check your first reply after an update. [Release notes](RELEASE_NOTES.md)

---

## 0.1.3 public Package Line

The 0.0.x design-implementation phase and the 0.1.0 prototype validation
baseline are complete. The current public package line is 0.1.3.

AIKernel is distributed across the following contract, runtime, provider, tool,
and demo repositories.

- `AIKernel.NET` - MIT contract packages: interfaces, DTOs, and enums.
- `AIKernel.Core` - Apache-2.0 runtime, monads, DSL, Kernel, Hosting, and
  provider integration.
- `AIKernel.Demo` - prototype applications for console, API host, WASM,
  pipeline, PDP, VFS, and replay inspection.
- `AIKernel.Tools` - external Capability modules and developer tools.
- `AIKernel.Control` - control-plane execution engines for CPU, GPU, emulator,
  Bonsai mapping, and diagnostics.
- `AIKernel.Providers` - official extension Provider and standard OS driver
  packages.
- `AIKernel.Wasm` - browser/WebAssembly runtime and WebGPU provider packages.

For CUDA on Windows x64 and Linux x64, use the CUDA Driver bundled with
`AIKernel.Kernel` 0.1.4. The NVIDIA driver is its only native runtime prerequisite.
`AIKernel.Cuda13.0` is the legacy LibTorch reference implementation through 0.1.3.
Maintenance has ended.

Historical architecture documents may retain their original 0.0.x front matter
and 0.1.0 prototype notes. User-facing package installation examples should use
the current 0.1.3 packages.

Release notes:

- [English](RELEASE_NOTES.md)
- [日本語](RELEASE_NOTES-ja.md)

---

## Concept Elevation

AIKernel v0.2.x introduces a concept-layer naming system based on a canonical philosophical vocabulary.
This does not change CTG-ROM or canonical governance contracts.

See:

- [Development Notes](docs/development/index.md)
- [Repository Alignment v0.1.1.1](docs/development/repository-alignment-v0.1.1.1.md)
- [Canonical Language Dictionary](docs/canonical-language/index.md)
- [Concept Elevation Refactoring Design](docs/design/concept-elevation-refactoring-design.md)
- [Concept Elevation Guidelines](docs/guidelines/concept-elevation-guidelines.md)
- [Concept Elevation Migration Notes](docs/migration/concept-elevation-v0.1.1.1.md)
- [Concept Elevation TODO](docs/todo/concept-elevation-refactoring-todo.md)

---

## NuGet Packages

AIKernel.NET is composed of multiple independent abstraction layers.  
Each layer is published as a separate NuGet package.

| Layer | Package | Version | Link |
| --- | --- | --- | --- |
| Core Types | `AIKernel.Enums` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Enums.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Enums/) |
| Data Models | `AIKernel.Dtos` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Dtos.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Dtos/) |
| Contracts | `AIKernel.Contracts` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Contracts.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Contracts/) |
| Image contracts | `AIKernel.Contracts.Images` | 0.1.4 | [Interface guide](src/AIKernel.Contracts.Images/README.md) |
| Abstractions | `AIKernel.Abstractions` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Abstractions.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Abstractions/) |

As of `v0.0.4`, Vfs interface contracts are published through `AIKernel.Abstractions`.
The public namespace remains `AIKernel.Vfs`, but the separate `AIKernel.Vfs` compatibility package/project has been removed.

As of `v0.0.4`, deterministic DSL, DSL ROM, History ROM, and Kernel clock contracts are also published through `AIKernel.Abstractions` / `AIKernel.Dtos`.

As of `v0.1.0`, `AIKernel.Abstractions` and `AIKernel.Contracts` export interfaces only.
DTOs are owned by `AIKernel.Dtos`, and shared enums are owned by `AIKernel.Enums`.

As of `v0.1.0`, OS-independent MemoryRegion / MemoryMapper
contracts are owned by `AIKernel.Abstractions.Memory`, with metadata in
`AIKernel.Dtos.Memory` and access-mode primitives in `AIKernel.Enums`.
Core and Kernel packages provide runtime implementations and adapters.

As of `v0.1.0`, external Capability module contracts are available through
`AIKernel.Abstractions.Capabilities`, `AIKernel.Dtos.Capabilities`, and capability module enum primitives in `AIKernel.Enums`.
These contracts distinguish CLI executable, managed assembly, native ABI, DSL ROM, and remote endpoint capability boundaries without introducing runtime loading behavior into the contract packages.

As of `v0.1.0`, DynamicSLM Model ABI contracts are available through
`AIKernel.Abstractions.DynamicSlm`, `AIKernel.Dtos.DynamicSlm`, and DynamicSLM enum primitives in `AIKernel.Enums`.
These contracts prepare Core/Provider implementations for capability-modular SLM artifacts, lineage verification, payload loading, scheduling, and differential distillation planning without introducing runtime behavior into the contract packages.
Heavy differential distillation execution is modeled as a background offload through scheduler/service interfaces so the load pipeline can continue through teacher, remote, or cached fallback paths.
SeedSLM contract vocabulary extends this surface with strict output discipline, fail-closed delegation, ReplayLog-compatible thought artifacts, and resident SeedSLM / paged CapabilitySLM memory placement metadata.

As of `v0.1.0`, HATL contract foundations are also available through
`AIKernel.Abstractions.Hatl`, `AIKernel.Dtos.Hatl`, and HATL enum primitives in `AIKernel.Enums`.
Cryptographic runtime is intentionally external and can be provided by AIKernel.RH-backed operators or other audited modules.

As of `v0.1.0`, governance and semantic-compilation vocabulary also includes `AdmissibilityReplayRecord`, `AdmissibilityGateKind`, `AdmissibilityDecisionKind`, `TaskCostClass`, `CriticalOperationRequirement`, and `SemanticIrSlot` for Core-side admission ReplayLog evidence.
Semantic Compilation DTOs provide contract-only carriers for semantic states, Semantic IR elements, governed circuits, prototype spaces, semantic distance reports, deterministic synthesis descriptors, and semantic transitions. Governance DTOs also include trajectory governance carriers for semantic ellipsoids, convergence/anomaly score reports, and candidate action evaluations.
Pre-inference admissibility contracts include critical-operation and computational-complexity gate interfaces, side-effect profiles, model execution budgets, and fail-closed gate results.

---

See `docs/design/DESIGN_INTENT.md` for design philosophy.  
For executable contracts and spec sheets, see `docs/specs/index.md`.

---

## Try an executable example

[Quick Start](docs/overview/quick-start.md) covers preparation, execution, and output. The [sample walkthrough](docs/tutorials/first-kernel.md) connects actual code to each result.

For a Web API or external model, choose a host through the [Provider guide](docs/providers/provider-model.md) and [AIKernel.Demo](https://github.com/AIKernel-NET/AIKernel.Demo). The basic example constructs runtime components; it does not boot a complete Kernel or call an LLM.

---

## 1. Purpose

AIKernel.NET aims to provide an OS that enables AI applications with:

- capability-based execution independent of model names
- category separation to maximize inference purity
- hybrid control of a deterministic scheduler and nondeterministic LLMs
- reproducibility through Deterministic Replay
- governance through signed PromptRules and audit logs
- OS-like extensibility where Providers act as drivers and the Kernel acts as the execution engine

---

## 2. Architecture Overview

AIKernel.NET defines abstract contracts and provides minimal DTOs and Enums.  
By fully separating contracts from implementation, it preserves Core purity and maximizes implementation flexibility.

AIKernel is designed as an OS-like layered architecture:

```text
Core         = syscall layer
Kernel       = AI OS core
Providers    = brain drivers
VfsProviders = external data sources
Server       = external API adapter
Hosting      = application integration
Enterprise   = operations extensions
```

---

## 3. Documentation Structure

To keep documentation and source synchronized, this README intentionally avoids deep file-by-file listings.

The documentation is organized into the following categories:

| Directory | Role |
| --- | --- |
| `docs/architecture` | Why: principles, invariants, governance |
| `docs/canonical-language` | Vocabulary: ecosystem-wide concept-layer naming dictionary |
| `docs/design` | How: design decisions and implementation strategy |
| `docs/specs` | What: normative contracts and acceptance criteria |
| `docs/guidelines` | Rules: repository and contribution policies |
| `docs/migration` | Migration notes and compatibility plans |
| `docs/operations` | Release, migration, and package-public operation guides |
| `docs/papers` | DOI-backed AIKernel / AIOS paper series |
| `docs/theory` | Work-in-progress research notes before paper/spec promotion |
| `docs/todo` | Pre-coding and cross-repository task trackers |

For the latest structure and cross-links, use the category indexes:

- `docs/architecture/index.md` / `docs/architecture/index-jp.md`
- `docs/canonical-language/index.md`
- `docs/design/index.md` / `docs/design/index-jp.md`
- `docs/specs/index.md` / `docs/specs/index-jp.md`
- `docs/guidelines/index.md` / `docs/guidelines/index-jp.md`
- `docs/migration/concept-elevation-v0.1.1.1.md`
- `docs/operations/index.md` / `docs/operations/index-jp.md`
- `docs/papers/README.md`
- `docs/theory/README.md` / `docs/theory/README-jp.md`
- `docs/todo/concept-elevation-refactoring-todo.md`

For the v0.1.3 canonical contract surface, start with:

- `docs/architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1.md`
- `docs/architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md`
- `docs/architecture/21.CTG_DEVELOPER_THEORY-v0.1.1.1.md`
- `docs/design/CTG_CONTRACT_MODEL-v0.1.1.1.md`
- `docs/operations/CTG_DEVELOPER_GUIDE-v0.1.1.1.md`
- `docs/operations/CTG_ROM_LAYOUT-v0.1.1.1.md`
- `docs/papers/12-canonical-trajectory-governance/README.md`
- `docs/operations/INTERFACE_EXTENSION_NAMING-v0.1.1.1.md`
- `docs/operations/ENUM_HANDLING_POLICY-v0.1.1.1.md`
- `docs/operations/XML_DOCUMENTATION_POLICY-v0.1.1.1.md`

The `0.1.3` package line publishes .NET / NuGet packages and synchronized PyPI
wrappers for `0.1.3`; do not mix this line with earlier packages.
package line.

---

## Repository Mapping

AIKernel is organized across multiple repositories.  
This repository manages the shared contract layer used by all solutions.

| Repository | Responsibility | Example directories/projects | Artifacts | Main dependencies |
| --- | --- | --- | --- | --- |
| **AIKernel.NET** | Shared contract layer | `Contracts`, DTOs, Enums | NuGet contract packages | none |
| **AIKernel.Core** | Core platform | `Core/`, `Kernel/`, `Providers/`, `VfsProviders/`, `Server/`, `Hosting/` | NuGet libraries | **AIKernel.NET** |
| **AIKernel.SDK** | Client libraries | `AIKernel.SDK` | NuGet client packages | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Web** | Admin console | `admin-web` | SPA build artifacts | **AIKernel.NET**, **AIKernel.Core** |
| **AIKernel.Infra** | Deployment definitions | `terraform/`, `k8s/`, `helm/` | Manifests | all repos |
| **AIKernel.Tools** | Developer tools and CI templates | `cli/`, `generators/`, `ci-templates/` | CLI binaries, CI templates | all repos |
| **AIKernel.Docs** | Documentation aggregation | `architecture/`, `runbooks/` | Documentation site | all repos |
| **AIKernel.Enterprise** | Enterprise solutions | `solutions/`, `services/`, `workers/`, `charts/` | Private container images, Helm charts | **AIKernel.NET**, **AIKernel.Core**, **AIKernel.Infra** |

---

## 4. Design Principles

### 4.1 Category Separation

Category separation is the most important design principle in AIKernel.

The following categories must not be mixed into a single context:

- Orchestration
- Expression
- Material
- History
- Style

> Information passed to an LLM must not be mixed into a single context.  
> — `CATEGORY_SEPARATION_PRINCIPLES.md`

---

### 4.2 Preprocessing First

Prompts are the final formatting step.

> Inference quality is determined by preprocessing structure.  
> — `PREPROCESSING_VS_PROMPTING.md`

---

### 4.3 Query Processing as Phase 1 Context Build

Query augmentation, decomposition, semantic conversion, and query routing are Phase 1 preprocessing responsibilities.

AIKernel treats these as context-build operations, not as Core knowledge retrieval. RAG remains a provider or pipeline strategy that can supply material, while Core keeps the abstract contracts for shaping query intent before ROM, CacheDB, and Governance participate.

Core abstractions:

- `IQueryAugmentor`
- `IQueryDecomposer`
- `IEmbeddingProvider`
- `IQueryRouter`
- `QueryPart`

---

### 4.4 Attention Pollution Prevention

Mixing examples, RAG material, and history can break inference.

> When attention is drawn to surface structures, inference halts.  
> — `ATTENTION_POLLUTION_THEORY.md`

---

### 4.5 LLM as Suggestor, PDP as Decision-Maker

The LLM is a suggestor.  
The Policy Decision Point (PDP) makes final decisions.

---

### 4.6 Signed Prompt Governance and Fail-Closed

Prompts carry authority equivalent to code execution.

AIKernel executes only approved, signed prompts and halts immediately when tampering or untrusted signers are detected.

Verification sequence:

```text
IPromptRepository
-> IPromptVerifier
-> ISignatureTrustStore
-> IPromptValidator
-> ExecutionPipeline
```

Detailed spec:

- `docs/specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC.md`

---

### 4.7 Relation-Oriented Data Structure (ROM)

AIKernel treats knowledge not as linear text, but as a set of relations.

Relation-Oriented Markdown (ROM) is the canonical representation format for AIKernel knowledge assets.

- `YAML`: Defines entity metadata and identity.
- `Headings`: Define semantic categories and contextual scopes.
- `Bullets`: Declaratively express facts and properties.
- `Links` (`[[id]]`): Represent graph edges between entities.
- `Semantic Hash`: Uses order-insensitive canonical hashing to strengthen signature verification.

With ROM, human-authored notes can be transformed directly into an LLM-reasonable knowledge base.

---

### 4.8 Git-Managed Reasoning (ConversationStore)

AI conversations are managed not as linear logs, but as tree-structured Git commits.

This natively supports:

- reasoning forks
- branch exploration
- point-in-time replay

---

## 5. Kernel

Kernel is the core of AIKernel and corresponds to the operating system kernel.

Primary components include:

- TaskManager: deterministic scheduler
- LlmController: nondeterministic inference controller
- ProviderRouter: capability-based brain selection
- RagEngine: materialization engine
- PipelineExecutor: DAG execution
- RulesEngine: PromptRules evaluation
- IPromptVerifier / IPromptValidator: runtime signature verification for fail-closed enforcement
- ISignatureTrustStore: trust anchor for trusted signers and revocation state

---

## 6. Providers

Providers declare **Capabilities** rather than model names.

Examples:

- chat
- embedding
- query-augmentation
- query-decomposition
- query-routing
- multimodal
- reasoning
- vector-search
- streaming

Providers are extensible through SDKs.

---

## 7. Vfs Providers

Git and other storage systems are treated as external data sources.

They are classified as Vfs Providers, not Model Providers.

---

## 8. Server

The Server layer exposes AIKernel as an OpenAI-compatible API.

---

## 9. Hosting

The Hosting layer provides application integration features such as:

- Dependency Injection
- default pipelines
- configuration
- application startup integration

---

## 10. Enterprise

Enterprise extensions may include:

- SIEM integration
- multi-tenant support
- SLO dashboards

---

## 11. License / Contribution

- AIKernel.NET is a contract/specification repository and is released under the MIT License.
- AIKernel.NET contains no implementation and therefore carries no patent surface; MIT maximizes interoperability and standardization.
- Papers and research documents follow the license explicitly attached to each paper.
- Contributions are PR-based.
- Compatibility for Contracts and PromptRules must be explicit.
- Breaking changes must include migration guides.
- Contributors must follow the full development discipline in
  [AIKernel Development Guidelines](docs/guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md)
  and [AIKernel 開発ガイドライン](docs/guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES-jp.md).

---

## 12. Final Note

AIKernel.NET provides a **structurally correct AI execution platform** as an operating system for AI applications.

It aims to become a standard OS for AI applications by focusing on:

- category separation
- preprocessing-first design
- governance
- reproducibility
- deterministic execution context

For implementation, lock contracts first by following `docs/specs/index.md`, then apply implementation strategy from `docs/design`.
