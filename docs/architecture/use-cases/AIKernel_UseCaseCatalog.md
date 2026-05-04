---
id: aikernel_use-case_catalog
version: 0.0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: AIKernel.NET — Use Case Catalog
created: 2026-05-02
tags:
  - aikernel
  - architecture
  - use-case
  - english
---

# AIKernel.NET — Use Case Catalog

## 1. Overview

AIKernel.NET is a prompt-referenced AI orchestration OS designed so that **AI selects AI, audits AI, and executes AI**.  
This document provides a systematic catalog of all use cases that the AIKernel abstraction layer must satisfy.  
It serves as the validation baseline for interface design and architectural correctness.

---

## 2. Core Use Cases

### UC-01: Task Intake & Context Distribution

**Purpose**  
Receive user input (natural language or structured data), normalize it through `IInputNormalizer`, and distribute it as `ContextFragment` objects into the appropriate context layers.

**Required Abstractions**  
`IInputNormalizer`, `IContextCollection`, `ContextFragment`

---

### UC-02: Structure Phase Execution

**Purpose**  
Use lightweight reasoning models to decompose tasks, extract constraints, and generate an execution plan.

**Required Abstractions**  
`IThoughtProcess`, `IStructurePlanner`, `IContextCollection` (writes into the Orchestration layer)

---

### UC-03: Model Vector Routing

**Purpose**  
Match the task’s requirement vector with each model’s `ModelCapacityVector`, selecting the optimal model through `IModelVectorRouter`.

**Required Abstractions**  
`IModelVectorRouter`, `ModelCapacityVector`, `ICapabilityRegistry`

---

### UC-04: Generation & Output Polishing

**Purpose**  
Use high‑capability generation models to produce output, then refine it through `IOutputPolisher` into the `ExpressionBuffer`.

**Required Abstractions**  
`IOutputPolisher`, `IKernelContext`, `ExpressionBuffer`

---

### UC-05: Unified Provider Invocation

**Purpose**  
Execute across heterogeneous compute backends (cloud APIs, local NPUs, etc.) through the unified `IProvider` interface.

**Required Abstractions**  
`IProvider`, `IProviderCapabilities`, `ExecutionResult`

---

## 3. Governance & Context Isolation

### UC-06: Attention Control via Three‑Layer Buffers

**Purpose**  
Physically isolate instructions, materials, and output to prevent attention pollution using `IAttentionGuard`.

**Required Abstractions**  
`IContextCollection`, `IContextCategory`, `IAttentionGuard`

---

### UC-07: Material Quarantine

**Purpose**  
Validate and normalize external data (e.g., RAG results) through `IMaterialQuarantine`, converting them into `IStructuredMaterial` before ingestion.

**Required Abstractions**  
`IMaterialQuarantine`, `IStructuredMaterial`

---

### UC-08: Context Snapshot & Persistence

**Purpose**  
Extract execution state as an `IContextSnapshot` and persist/restore it through `IVfsProvider`.

**Required Abstractions**  
`IContextSerializer`, `IVfsProvider`, `IContextSnapshot`

---

## 4. Pipeline & Hardware Advisory

### UC-09: Deterministic Pipeline Execution

**Purpose**  
Execute a chain of intelligence-processing steps as auditable `IPipelineStep` units orchestrated by `IPipelineOrchestrator`.

**Required Abstractions**  
`IPipelineOrchestrator`, `IPipelineStep`

---

### UC-10: Compute Shape Advisory

**Purpose**  
Optimize execution by selecting tensor shapes and compute parameters appropriate for NPU/GPU resources through `IComputeShapeAdvisor`.

**Required Abstractions**  
`IComputeShapeAdvisor`, `IProviderCapabilities`

---

## 5. Prompt Security & Fail‑Closed Execution

### UC-11: Static Prompt Validation

**Purpose**  
Validate Markdown‑based prompts during CI to ensure compliance with AIKernel’s architectural principles and structural rules.

**Required Abstractions**  
`IPromptValidator`, `IPromptRuleSet`

---

### UC-12: Prompt Signing

**Purpose**  
After validation, sign prompts using `IPromptSigner` to establish them as trusted specifications.

**Required Abstractions**  
`IPromptSigner`, `IPromptHashCalculator`

---

### UC-13: Runtime Signature Verification

**Purpose**  
Verify prompt signatures at load time using `IPromptVerifier`.  
If tampering is detected, execution is rejected under the fail‑closed principle.

**Required Abstractions**  
`IPromptVerifier`, `IPromptSignatureProvider`, `IPromptRepository`

---

## 6. Hosting & Dependency Injection

### UC-14: Dynamic Configuration via Kernel Modules

**Purpose**  
Register Providers and Routers into the DI container through `IKernelModule`, enabling environment‑specific hosting.

**Required Abstractions**  
`IKernelHost`, `IKernelModule`, `IServiceRegistrar`, `IProviderRegistrar`

---

## 7. Conversation Branching, Checkpointing, Diff, and Persistence

### UC-15: Chat Branching

**Purpose**  
Branch conversation history like Git and start a new conversation from any prior state.

**Required Abstractions**  
`IConversationBranch`, `IConversationSnapshot`, `IConversationStore`, `IConversationDiff`

---

### UC-16: Chat Checkpointing

**Purpose**  
Save arbitrary conversation points as checkpoints so they can be restored, compared, and branched later.

**Required Abstractions**  
`IConversationCheckpoint`, `IConversationSerializer`, `IConversationTimeline`

---

### UC-17: Chat Diffing

**Purpose**  
Compare two conversation states and visualize which reasoning, instructions, and materials differ.

**Required Abstractions**  
`IConversationDiff`, `IDiffFormatter`

---

### UC-18: Chat Persistence

**Purpose**  
Persist conversation history in a Git-like model across local storage, cloud backends, and VFS.

**Required Abstractions**  
`IConversationStore`, `IVfsProvider`

---

## 8. Multi-Model Governance and Credit Control

### UC-19: Parallel Multi-Model Execution

**Purpose**  
Execute multiple `IProvider` backends in parallel for the same task to optimize both latency and quality.

**Required Interfaces**  
`IProvider`, `IProviderCapabilities`, `IConversationSnapshot`, `IConversationTimeline`

**Context**  
UC-03 (Model Vector Routing), UC-05 (Provider Invocation), UC-09 (Deterministic Pipeline)

**Layer**  
Orchestration, Provider

---

### UC-20: Committee Reasoning

**Purpose**  
Integrate reasoning outputs from multiple models to avoid single-model dependency and improve decision robustness.

**Required Interfaces**  
`IConversationSnapshot`, `IConversationDiff`, `IThoughtProcess`, `IProvider`

**Context**  
UC-02 (Structure Phase), UC-15 (Chat Branching), UC-17 (Chat Diffing)

**Layer**  
Orchestration, Material

---

### UC-21: Cross-Model Conflict Detection

**Purpose**  
Detect conflicts in claims, evidence, and constraints across model outputs and route them into fail-closed re-evaluation.

**Required Interfaces**  
`IConversationDiff`, `IDiffFormatter`, `IConversationSnapshot`, `IPromptVerifier`

**Context**  
UC-13 (Runtime Signature Verification), UC-17 (Chat Diffing), UC-20 (Committee Reasoning)

**Layer**  
Orchestration, Material, Expression

---

### UC-22: Complementary Reasoning

**Purpose**  
Combine model-specific strengths to achieve reasoning depth beyond single-model execution.

**Required Interfaces**  
`IModelVectorRouter`, `IProviderCapabilities`, `IThoughtProcess`, `IConversationBranch`

**Context**  
UC-03 (Model Vector Routing), UC-10 (Compute Shape Advisory), UC-19 (Parallel Multi-Model Execution)

**Layer**  
Orchestration, Provider

---

### UC-23: Provider Credit Management

**Purpose**  
Monitor provider-level balance, cost, and usage to preserve reasoning economics while controlling execution targets.

**Required Interfaces**  
`IProviderCreditInfo`, `IProviderCostProfile`, `IProviderUsageStats`, `IProviderBillingInfo`, `IProviderResourceProfile`

**Context**  
UC-03 (Model Vector Routing), UC-05 (Provider Invocation), UC-18 (Chat Persistence)

**Layer**  
Orchestration, Provider

---

## 9. Runtime Operations, Tooling, and Observability

### UC-24: Audit Event Emission

**Purpose**  
Emit auditable lifecycle events for execution, policy, and provider operations.

**Required Interfaces**  
`IAuditEvent`, `IAuditEventContract`

**Context**  
UC-09 (Deterministic Pipeline Execution), UC-13 (Runtime Signature Verification)

**Layer**  
Orchestration, Expression

---

### UC-25: Event Bus Distribution

**Purpose**  
Distribute internal kernel events to subscribers for decoupled orchestration and monitoring.

**Required Interfaces**  
`IEventBus`

**Context**  
UC-05 (Unified Provider Invocation), UC-24 (Audit Event Emission)

**Layer**  
Orchestration, Provider

---

### UC-26: Retrieval and Embedding Ingestion

**Purpose**  
Index and retrieve material through embedding and RAG providers before quarantine and structuring.

**Required Interfaces**  
`IEmbeddingProvider`, `IRagProvider`, `IMaterialQuarantine`

**Context**  
UC-07 (Material Quarantine), UC-08 (Context Snapshot & Persistence)

**Layer**  
Material, Provider

---

### UC-27: Model Inference Interaction

**Purpose**  
Execute message-based model inference with streaming and answer generation patterns.

**Required Interfaces**  
`IModelProvider`, `IModelMessage`

**Context**  
UC-03 (Model Vector Routing), UC-04 (Generation & Output Polishing)

**Layer**  
Orchestration, Provider

---

### UC-28: Scheduled Job Orchestration

**Purpose**  
Run periodic and asynchronous jobs with lifecycle state and execution results.

**Required Interfaces**  
`IScheduler`, `IScheduleSpec`, `IScheduledJob`, `IExecutionResult`

**Context**  
UC-09 (Deterministic Pipeline Execution), UC-18 (Chat Persistence)

**Layer**  
Orchestration, Provider

---

### UC-29: Task Pipeline Management

**Purpose**  
Register, execute, pause, resume, and inspect DAG-style task pipelines.

**Required Interfaces**  
`ITaskManager`, `IPipeline`, `ITask`, `ITaskContext`, `ITaskExecutionResult`, `IPipelineExecutionResult`

**Context**  
UC-02 (Structure Phase Execution), UC-09 (Deterministic Pipeline Execution)

**Layer**  
Orchestration

---

### UC-30: Token and Vector Estimation

**Purpose**  
Estimate token usage and task vectors for routing, budget control, and shape advisory.

**Required Interfaces**  
`ITokenizer`, `ITaskVectorEstimator`, `IModelVectorRouter`, `IComputeShapeAdvisor`

**Context**  
UC-03 (Model Vector Routing), UC-10 (Compute Shape Advisory)

**Layer**  
Orchestration, Models

---

### UC-31: Tool Access Control and Sandbox Execution

**Purpose**  
Validate tool permissions and execute tools within an isolated sandbox boundary.

**Required Interfaces**  
`IToolPermission`, `IToolAccessValidator`, `IToolSandbox`

**Context**  
UC-11 (Static Prompt Validation), UC-13 (Runtime Signature Verification)

**Layer**  
Orchestration, Provider

---

### UC-32: Context Lifecycle Observation

**Purpose**  
Observe attention signals and context lifecycle transitions for contamination prevention and summarization.

**Required Interfaces**  
`IAttentionObserver`, `IContextLifecycleManager`, `IHistorySummarizer`

**Context**  
UC-06 (Attention Control via Three-Layer Buffers), UC-07 (Material Quarantine)

**Layer**  
Orchestration, Material

---

## 10. Summary

This catalog defines the required behaviors of the AIKernel.NET abstraction layer.

### Validation Criteria

- **Security Integrity**  
  UC‑11 to UC‑13 ensure a complete trust chain from development to runtime.

- **Resource Optimization**  
  UC‑10 guarantees interface‑level compatibility with next‑generation hardware such as NPUs.

- **Naming Consistency**  
  Type names and use cases must maintain a strict 1:1 correspondence.

---
