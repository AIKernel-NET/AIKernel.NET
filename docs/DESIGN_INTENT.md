# Design Intent

## Summary

- Prioritize human readability through a Markdown-first approach. All design documents, rules, and prompts are written in Markdown to enable easy diffing and review.  
- The Core layer holds abstract interfaces and Contracts (JSON Schema), eliminating implementation dependencies.  
- Providers are handled based on capabilities, not model names or vendor-specific behavior.  
- LLMs act as suggestors, while the PDP (Policy Decision Point) is the final decision-maker.  
- Pipelines are structured as DAGs, with the TaskManager responsible for resource control and scheduling.  
- PromptRules are signed Markdown documents to strengthen governance and change tracking.  
- Auditing and reproducibility (Deterministic Replay) are top priorities, ensuring complete preservation of execution logs, prompts, and runtime state.

---

## Details

## Design Philosophy

### Human-Centric Documentation
Markdown is treated as the primary representation of design.  
Documents must be immediately understandable by developers, reviewers, and auditors—not only machines.

### Contract-Driven Architecture
All interfaces between the Core and Providers are defined using JSON Schema.  
Schemas are versioned and include explicit compatibility rules (backward compatibility, handling of breaking changes).

### Capability Abstraction
Providers declare what they can do (capabilities).  
Callers adapt dynamically to these capabilities.  
Model names and API details are hidden behind capability implementations, enabling easy provider replacement and multi-provider operation.

### Separation of Responsibilities
LLMs are limited to generating suggestions.  
Final decisions are made by the PDP, which integrates rules, compliance, cost, and risk evaluation.

---

## Architecture Overview

### Core
- Abstract interfaces (input/output types, error types, metadata types)  
- Contracts defined in JSON Schema  
- CI-based schema validation  
- Breaking changes require explicit migration procedures

### Provider Layer
- Capability declarations (e.g., streaming, embeddings, function-calling, multimodal)  
- Thin adapter layer mapping Core abstractions to provider-specific APIs  
- Minimal side effects and high testability

### Pipeline Layer
- DAG representation (tasks as nodes, dependencies as edges)  
- Each task maintains input and output hashes for reproducibility  
- TaskManager handles resource allocation, priority, parallelism, rate limiting, and failover

### PromptRules
- Signed Markdown documents  
- Tamper detection and versioned change history  
- Rule evaluation engine integrated with the PDP, applied before and after prompt generation

---

## Governance and Security

### Centralized Policy Management
The PDP centrally manages policies and applies them at runtime.  
Policies are versioned and require diff-based review.

### Signing and Verification
PromptRules, critical configuration files, and contract files must be signed and verified at runtime.

### Least Privilege
Provider credentials and keys are stored in a Secret Manager with minimal access permissions.

### Data Classification
Input and output data carry classification labels.  
Processing rules (masking, storage permissions, external transmission) are automatically applied based on classification.

---

## Auditing and Reproducibility

### Deterministic Replay
All elements required for execution are preserved, including:

- PromptRules version  
- Provider capability declarations  
- Input data  
- Runtime configuration  
- Random seeds  
- Snapshots of external API responses  

This ensures exact re-execution under identical conditions.

### Audit Logs
Audit logs store change history, PDP decision reasons, signature verification results, and error/retry history.  
Logs are searchable and support dedicated audit views.

### Differential Reproduction
Tools are provided to compare small changes (e.g., minor PromptRules edits) and identify their impact.

---

## Operations and Observability

- Standard metrics: latency, success rate, cost (per API call), cache hit rate, retry rate  
- Distributed tracing with trace IDs for each pipeline execution  
- Alerts for SLA violations, abnormal cost increases, and policy violation attempts  
- Regular backups of Contracts, PromptRules, PDP policies, and audit logs, with documented recovery procedures

---

## Developer Guidelines

- All public APIs, Contracts, and PromptRules must be written in Markdown and validated automatically during PRs  
- Required test types: unit tests, contract tests, integration tests, replay tests  
- Minor updates must maintain backward compatibility; breaking changes require major version increments and migration guides  
- Adding new capabilities requires defining a Capability Schema and documenting how existing providers adapt  
- Changes to PromptRules or PDP policies require approval from both a security reviewer and a domain reviewer

---

## Error Handling and Fallback

- Error types are defined in Contracts; callers must implement recovery strategies based on error categories  
- Critical decision paths must include fallback providers or local rules  
- Provider calls use exponential backoff and retry limits, with retry policies controlled by the PDP

---

## Performance and Cost Management

- Provider cost metrics are collected and used to estimate pipeline execution cost  
- Result caching is used where it does not compromise reproducibility  
- TaskManager is designed for horizontal scaling and allocates resource slots based on constraints

---

## Compatibility and Migration

- Contracts, PromptRules, and PDP policies are versioned independently  
- Runtime execution explicitly records the version of each component  
- Breaking changes require automated conversion tools, migration documentation, and mandatory migration tests

---

## Change History

- v1.0.0 Initial version

---

## Glossary

### Capability  
A declaration of what a provider can do.  
Used by the Runtime to select providers based on functionality rather than model names.

### PDP (Policy Decision Point)  
The component responsible for final decision-making.  
Evaluates rules, compliance, cost, and risk.

### LLMController  
Controls LLM behavior by treating the LLM as a suggestor.  
Ensures that LLM output is not used without PDP approval.

### TaskManager  
Deterministic scheduler responsible for resource allocation, priority, parallelism, rate limiting, and failover.

### DAG (Directed Acyclic Graph)  
Pipeline structure where tasks are nodes and dependencies are edges.  
Ensures reproducibility and traceability.

### PromptRules  
Signed Markdown documents defining prompt-generation rules.  
Versioned and auditable.

### Contracts  
JSON Schema–based definitions of data types, error types, and metadata types.  
Guarantee compatibility between Core, Runtime, and Providers.

### Deterministic Replay  
Mechanism ensuring that executions can be reproduced exactly under the same conditions.

### Provider  
Implements capabilities and provides actual model or API functionality.  
Examples: OpenAI, LocalRAG, LlamaCpp.

### FeatureSpec  
Specification of provider-supported features such as streaming or multimodal support.

### TokenizerProfile  
Abstract representation of a provider’s tokenizer characteristics.

### DynamicMetricStore  
Stores dynamic provider metrics (latency, error rate, health) used during provider selection.

### Secret Manager  
Secure storage for provider credentials and keys.

### AuditEvent  
Primary execution information recorded for auditing and reproducibility.

### Policy  
Rule set used by the PDP for decision-making.

### Replay Test  
Test verifying that deterministic replay produces identical results.

### Contract Test  
Test verifying compatibility with JSON Schema–based Contracts.

