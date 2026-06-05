---
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel Operations — Index
This directory serves as the entry point for **Operations** documentation in AIKernel.NET.  
At this stage, most documents are **Planned**, and will be created once the core specifications  
(Contracts / Kernel / Providers) reach a stable state.

Operations documents differ from architecture (Why), design (How), and guidelines (Rules).  
They focus on **practical operational procedures (Runbooks)** such as monitoring, release workflows,  
incident response, and SLO/SLA management.

---

## Operations Documents

### 1. [Migration Guide](MIGRATION_GUIDE.md)  
**Status:** Active  
**Current contents:**  
- Migration steps across breaking contract changes  
- Classification of changes (Breaking / Non-breaking)  
- Compatibility and dependency checks  
- Upgrade checklists  
- v0.0.3 -> v0.0.4 contract extraction for DSL, DSL ROM, History ROM, and Kernel clock
- v0.0.4 -> v0.0.5 contract-surface purity cleanup for interface-only packages
- v0.0.5 DynamicSLM Model ABI and distillation offload contract preparation
- v0.0.5 SeedSLM discipline, delegation, thought artifact, and memory placement contract preparation
- v0.0.5 HATL external cryptographic operator contract preparation
- v0.0.5 governance admissibility replay and Semantic IR slot vocabulary

Use this guide when upgrading package references or validating contract-layer dependencies.

---

### 2. Release Operations  
**Status:** Planned  
**Planned contents:**  
- Release workflow (tag → build → publish → verify)  
- Handling of signed artifacts  
- Versioning rules (SemVer + Contract Versioning alignment)  
- Post-release validation procedures  

---

### 3. Monitoring & Observability  
**Status:** Planned  
**Planned contents:**  
- Metrics (latency, cost, retries, cache, provider health)  
- Distributed tracing (Pipeline / TaskManager / ProviderRouter)  
- Alert design (SLO / SLA / SLI)  
- Log structure (AuditEvent / Replay Logs)  

---

### 4. Incident Response  
**Status:** Planned  
**Planned contents:**  
- Detection → Triage → Isolation → Recovery → Postmortem  
- Provider failover procedures  
- RAG data corruption recovery  
- Using Deterministic Replay for incident analysis  

---

### 5. Security Operations  
**Status:** Planned  
**Planned contents:**  
- Signature verification (PromptRules / Contracts / Policies)  
- Provider credential management (Secret Manager)  
- Access control based on Data Classification  
- Audit log retention and tamper detection  

---

## Purpose of Operations

AIKernel Operations serve three major purposes:

### 1. Stability  
- Automatic recovery from provider failures  
- Pipeline reproducibility  
- Safe upgrades and rollouts  

### 2. Observability  
- Metrics  
- Tracing  
- Logging  
- Alerting  

### 3. Governance  
- Release management  
- Tracking contract changes  
- Signature verification  
- Audit readiness  

Operations provide the foundation for running AIKernel as a long-term, reliable **AI OS**.

---

## Current Status

Operations documentation is being expanded as contract and packaging boundaries stabilize.

Currently:
- The Migration Guide contains concrete steps through v0.0.5
- All other documents remain Planned  

Future versions will expand this directory.

---

## Related Directories

- `docs/architecture/` — Architectural philosophy (Why)  
- `docs/design/` — Implementation policies (How)  
- `docs/guideline/` — Operational rules (Rules)  
- `docs/operations/` — Runbooks and operational procedures ← *this directory*
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.3 (2026-06-02): Marked Migration Guide as active and added v0.0.3 dependency-layer migration coverage
- v0.0.4 (2026-06-04): Added DSL / History ROM contract extraction migration coverage
- v0.0.5 (2026-06-05): Added contract-surface purity cleanup, DynamicSLM Model ABI / SeedSLM discipline / distillation offload, HATL external cryptographic operator, and governance admissibility / Semantic IR vocabulary migration coverage
