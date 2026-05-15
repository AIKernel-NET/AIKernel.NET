---
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel.NET

![AIKernel.NET Logo](docs/assets/aikernel-logo.png)

AIKernel is an operating system for AI applications.

AIKernel does not define features themselves.  
It defines the deterministic execution context in which features become inevitable.

This repository manages the canonical contract set of AIKernel.

AIKernel.NET is a contract-first foundation that treats LLMs not as simple APIs, but as capability-bearing processes.

---

## NuGet Packages

AIKernel.NET is composed of multiple independent abstraction layers.  
Each layer is published as a separate NuGet package.

| Layer | Package | Version | Link |
| --- | --- | --- | --- |
| Core Types | `AIKernel.Enums` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Enums.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Enums/) |
| Data Models | `AIKernel.Dtos` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Dtos.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Dtos/) |
| Contracts | `AIKernel.Contracts` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Contracts.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Contracts/) |
| Abstractions | `AIKernel.Abstractions` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Abstractions.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Abstractions/) |
| Virtual File System | `AIKernel.Vfs` | ![NuGet](https://img.shields.io/nuget/v/AIKernel.Vfs.svg) | [NuGet](https://www.nuget.org/packages/AIKernel.Vfs/) |

---

See `docs/design/DESIGN_INTENT.md` for design philosophy.  
For executable contracts and spec sheets, see `docs/specs/index.md`.

---

## Hosting Example (C#)

AIKernel.NET integrates with ASP.NET Core DI.  
By composing Core, Providers, and Governance, you can host an AI execution platform.

Because AIKernel.NET is based on interface contracts, implementations can be replaced freely.

### Example Implementation

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAIKernelCore(options =>
{
    options.EnableDeterministicReplay = true;
    options.FailClosed = true;
});

builder.Services.AddModelProvider<OpenAIModelProvider>();
builder.Services.AddVfsProvider<GitVfsProvider>();

builder.Services.AddSignatureTrustStore<FileSignatureTrustStore>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var kernel = scope.ServiceProvider.GetRequiredService<IAIKernel>();
    await kernel.InitializeAsync();
}

app.MapControllers();
app.Run();
```

### Target Experience / Boot Log Example

```txt
[KERNEL] Initializing AIKernel.NET v0.1.0...
[KERNEL] Loading ISignatureTrustStore... [OK]
[KERNEL] Mounting Vfs (Git: ./context)... [OK]
[KERNEL] Verifying System Prompt Signature... [VALID]
[KERNEL] Routing to Provider: [[provider.reasoning.high]]... [OK]

> Hello Intelligence.
> The Semantic Context is stable. Governance is active.
> This boot sequence is deterministic and verifiable.
```

---

## API Example / curl

AIKernel can be exposed as an OpenAI-compatible API.  
Below is an execution example with explicit context.

```bash
curl -X POST http://localhost:5000/v1/execute \
  -H "Content-Type: application/json" \
  -d '{
    "capability": "reasoning",
    "input": "Hello Intelligence",
    "context": {
      "vfs": "git://./context"
    }
  }'
```

### Response Example

```json
{
  "output": "[OpenAI] Hello Intelligence",
  "provider": "openai",
  "capability": "reasoning",
  "context": {
    "vfs": "git://./context"
  }
}
```

> Context is not merely input data.  
> It is an execution condition bound to the Kernel.

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

The documentation is organized into four foundational categories:

| Directory | Role |
| --- | --- |
| `docs/architecture` | Why: principles, invariants, governance |
| `docs/design` | How: design decisions and implementation strategy |
| `docs/specs` | What: normative contracts and acceptance criteria |
| `docs/guidelines` | Rules: repository and contribution policies |

For the latest structure and cross-links, use:

- `docs/index.md`
- `docs/index-jp.md`

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

- Contributions are PR-based.
- Compatibility for Contracts and PromptRules must be explicit.
- Breaking changes must include migration guides.

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
