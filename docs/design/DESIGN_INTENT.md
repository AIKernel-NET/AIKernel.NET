---
id: design-intent
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Design Intent"
scope:
  - repo: AIKernel.NET
createdAt: 2026-04-28T00:00:00Z
updated: 2026-05-06
---

# Design Intent

## Summary

- Use Markdown as the primary representation and prioritize human readability. Design docs, rules, and prompts are managed in Markdown to make diff review easy.
- Core holds abstract interfaces and Contracts (JSON Schema) and avoids implementation dependencies.
- Providers are treated capability-first and must not depend on model names or vendor-specific behaviors.
- LLMs act as suggestors; the PDP (Policy Decision Point) is the final decision-maker.
- Pipelines are DAGs; TaskManager handles resource control and scheduling.
- PromptRules are signed Markdown to strengthen governance and tamper detection.
- Prioritize auditability and reproducibility (Deterministic Replay) by fully recording execution logs, prompts, and runtime state.

---

## Details

### Design Philosophy

#### Human-centered documentation
Markdown is the primary representation so developers, reviewers, and auditors can immediately understand artifacts.

#### Contract-driven
All interfaces between Core and Providers are defined as JSON Schema. Schemas are versioned and the handling of backward-incompatible changes is explicit.

#### Capability abstraction
Providers declare "what they can do" (Capabilities). Callers adapt dynamically to capabilities. Model names and API details are hidden behind capability adapters to enable provider replacement and multi-provider operation.

#### Separation of responsibilities
LLMs generate suggestions; PDP makes final decisions. PDP integrates rules, compliance, cost, and risk assessments.

---

## Architecture Overview

### Core
- Abstract interfaces (input/output types, error types, metadata)
- Contracts (JSON Schema)
- Schema validation in CI
- Breaking changes require explicit migration steps

### Provider layer
- Capability declarations (e.g., streaming, embeddings, function-calling, multimodal)
- Thin adapter mapping Core abstractions to provider APIs
- Minimize side effects and maximize testability

### Pipeline layer
- DAG representation (Tasks are nodes, dependencies are edges)
- Tasks have input and output hashes for re-execution
- TaskManager manages resource allocation, priority, concurrency, rate limits, and failover

### PromptRules
- Signed Markdown
- Tamper detection and history
- PDP integration for rule checks before and after prompt generation

---

## Governance and Security

### Centralized policy
PDP centralizes policy application at runtime. Policies are versioned and require diff review.

### Signing and verification
PromptRules, critical configuration, and contract files must be signed and verified at runtime.

### Least privilege
Provider credentials and keys are stored in a Secret Manager and access is minimized.

### Data classification
Inputs and outputs carry classification labels that automatically control masking, storage, and external transmission.

---

## Auditability and Reproducibility

### Deterministic Replay
Save the following to guarantee re-execution under identical conditions:
- PromptRules version
- Provider capability declarations
- Input data
- Runtime configuration
- Random seeds
- Snapshots of external API responses

### Audit logs
Record change history, PDP decision rationale, signature verification results, errors, and retry history in searchable audit logs.

### Diff replay
Provide tools to compare small PromptRules changes and identify impact.

---

## Operations and Observability

- Metrics: latency, success rate, cost, cache hit rate, retry rate
- Distributed tracing: assign trace IDs per Pipeline execution
- Alerts for SLA violations, anomalous cost, policy violation attempts
- Regular backups and recovery procedures for Contracts, PromptRules, PDP policies, and audit logs

---

## Developer Guidelines

- Document public APIs, Contracts, and PromptRules in Markdown and validate them in PRs
- Require unit tests, contract tests, integration tests, and replay tests
- Maintain backward compatibility for minor updates; breaking changes use major versions
- When adding a Capability, define its Capability Schema and show compatibility with existing Providers
- Changes to PromptRules or PDP policies require security and domain owner approvals

---

## Error Handling and Fallbacks

- Define error types in Contracts; callers implement recovery strategies per error type
- Provide multi-provider or local-rule fallbacks for critical decision paths
- Provider calls use exponential backoff and max retries; PDP controls retry policies

---

## Performance and Cost Management

- Include provider cost metrics and provide per-pipeline cost estimates
- Use caching where it does not break reproducibility
- TaskManager is designed for horizontal scaling and slot allocation based on resource constraints

---

## Compatibility and Migration

- Version Contracts, PromptRules, and PDP policies independently
- Expose versions at runtime
- Provide automatic conversion tools and migration guides for breaking changes; require migration tests

---

## Changelog

- v1.0.0 Initial release

## Glossary

### Capability
A provider-declared set of "what it can do" abstracted from model names and API details.

### PDP
Policy Decision Point that integrates compliance, cost, risk, and rules to make final decisions.

### LLMController
Control layer treating LLM as a suggestor; outputs are subject to PDP decisions.

### TaskManager
Deterministic scheduler for pipeline tasks.

### DAG
Directed Acyclic Graph representation of pipeline structure.

### PromptRules
Signed Markdown rules for prompt generation.

### Contracts
JSON Schema-based contract definitions held by Core.

### Deterministic Replay
Mechanism to save all elements required to re-run an execution identically.

### Provider
Layer that declares Capabilities and provides models or APIs.

### FeatureSpec
Provider feature specification (function-calling, streaming, multimodal support).

### TokenizerProfile
Profile describing tokenizer characteristics to normalize token counts.

### DynamicMetricStore
Store for provider dynamic metrics used in runtime provider scoring.

### Secret Manager
Secure store for provider credentials and keys.

### AuditEvent
Primary runtime information recorded for auditing and replay.

### Policy
Rule sets referenced by PDP.

### Replay Test
Test to verify deterministic replay yields identical results.

### Contract Test
Tests ensuring Provider and Runtime compatibility with Contracts.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
