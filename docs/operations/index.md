---
updated: 2026-06-14
published: 2026-05-16
version: "0.1.1.1"
edition: "Release"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# AIKernel Operations — Index
This directory serves as the entry point for **Operations** documentation in AIKernel.NET.
As of 0.1.1, the Operations area also carries the public package installation path,
the official demo-program reading order, and the release-time verification surface.

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
- v0.0.5 external Capability module contract preparation
- v0.0.5 DynamicSLM Model ABI and distillation offload contract preparation
- v0.0.5 SeedSLM discipline, delegation, thought artifact, and memory placement contract preparation
- v0.0.5 HATL external cryptographic operator contract preparation
- v0.0.5 governance admissibility replay and Semantic IR slot vocabulary
- v0.0.5 Semantic Compilation DTO vocabulary
- v0.1.0 MemoryRegion / MemoryMapper contract extraction
- v0.1.1 synchronized package line verification across NuGet, PyPI, Providers, WASM, Tools, CUDA, and Demo
- v0.1.1.1 additive domain contract surface and documentation-policy alignment
- v0.1.1.1 .NET / NuGet-only package boundary; no PyPI packages are produced for this validation line
- v0.1.2 canonical series release assumption: synchronized NuGet and PyPI package families
- v0.1.1.1 CTG DTO / enum normalization before publication

Use this guide when upgrading package references or validating contract-layer dependencies.

---

### 2. [Package Installation Guide](PACKAGE_INSTALLATION_GUIDE.md)
**Status:** Active
**Current contents:**
- Fastest three-command path for starting the AIKernel OS surface
- NuGet package map for contract, runtime, provider, tools, WASM, and CUDA layers
- PyPI package map for Python wrapper users
- `0.1.1.1` rule: update .NET / NuGet packages only; keep PyPI packages on `0.1.1`
- `0.1.2` assumption: publish refreshed NuGet and PyPI package families together
- Provider selection guidance and repository links
- 0.1.1 version-mixing rule

Use this guide when installing AIKernel packages or validating package-family boundaries.

---

### 3. [Demo Programs Guide](DEMO_PROGRAMS_GUIDE.md)
**Status:** Active
**Current contents:**
- Recommended first demo: `AIKernel.Demo.CoreRuntime`
- Eight-demo map across CoreRuntime, Contracts, Control, Providers, StandardProviders, Tools, WASM, and CUDA
- Release-friendly dry-run execution order
- Python demo surface guidance

Use this guide when learning AIKernel through executable examples.

---

### 4. [Interface Extension Naming Policy](INTERFACE_EXTENSION_NAMING-v0.1.1.1.md)
**Status:** Active
**Current contents:**
- Semantic interface naming without mechanical suffixes
- Draft-name to implemented-name mapping for v0.1.1.1 additive contracts
- Inheritance documentation rules for opt-in interface expansion

Use this policy when adding or reviewing public interfaces.

---

### 5. [Enum Handling Policy](ENUM_HANDLING_POLICY-v0.1.1.1.md)
**Status:** Active
**Current contents:**
- `Unknown = 0` requirement for new domain enums
- Fail-closed behavior for unknown enum values
- Diagnostics, metadata, and telemetry requirements for raw enum values

Use this policy when adding enums or consuming values from adapters, providers,
replay artifacts, telemetry carriers, or external metadata.

---

### 6. [XML Documentation Policy](XML_DOCUMENTATION_POLICY-v0.1.1.1.md)
**Status:** Active
**Current contents:**
- Bilingual XML documentation requirement for public API
- Inline `JA:` form and paired `docs.en.xml` / `docs.ja.xml` include form
- Review checklist for public types, members, parameters, type parameters, and returns

Use this policy when adding or reviewing public contract comments.

---

### 7. [CTG Developer Guide](CTG_DEVELOPER_GUIDE-v0.1.1.1.md)
**Status:** Active
**Current contents:**
- Contract-only rules for Canonical Trajectory Governance
- Developer guidance for council, gate, trajectory, ROM, and trace carriers
- Fail-closed review checklist for unknown values, missing canon, vetoes, and diagnostics
- Paper 12 alignment checklist for the Zenodo-published CTG theory

Use this guide when adding, reviewing, or implementing CTG contracts in runtime packages.

---

### 8. [CTG Developer Theory](../architecture/21.CTG_DEVELOPER_THEORY-v0.1.1.1.md)
**Status:** Active
**Current contents:**
- Developer-facing theory map for CTG
- Three-council model, finite vote values, and discrete gate decisions
- Rejection taxonomy, canon reference shape, and replay boundaries

Use this guide when reviewing whether CTG DTOs, enums, and runtime-package
implementations preserve the published paper invariants.

---

### 9. [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1.md)
**Status:** Active
**Current contents:**
- Monolith CTG-ROM directory layout
- Separation between `/rom/governance` canon assets and `/rom/locales` personality descriptors
- Base canon layer, locale layer, developer diff layer, and VFS merge layer
- Fail-closed merge rules for personalized Personality-ROM construction

Use this guide when adding, reviewing, or mounting CTG-ROM canon and personalization layers.

---

### 10. Release Operations
**Status:** Planned
**Planned contents:**
- Release workflow (tag → build → publish → verify)
- Handling of signed artifacts
- Versioning rules (SemVer + Contract Versioning alignment)
- Post-release validation procedures

---

### 11. Monitoring & Observability
**Status:** Planned
**Planned contents:**
- Metrics (latency, cost, retries, cache, provider health)
- Distributed tracing (Pipeline / TaskManager / ProviderRouter)
- Alert design (SLO / SLA / SLI)
- Log structure (AuditEvent / Replay Logs)

---

### 12. Incident Response
**Status:** Planned
**Planned contents:**
- Detection → Triage → Isolation → Recovery → Postmortem
- Provider failover procedures
- RAG data corruption recovery
- Using Deterministic Replay for incident analysis

---

### 13. Security Operations
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
- The Migration Guide contains concrete steps through v0.1.1 and the v0.1.1.1 CTG DTO / enum normalization
- The Package Installation Guide covers the synchronized `0.1.1` NuGet / PyPI line, the `0.1.1.1` NuGet-only contract update, and the v0.1.2 synchronized NuGet / PyPI release assumption
- The Demo Programs Guide covers the official AIKernel.Demo learning path
- Interface naming, enum handling, XML documentation policy, CTG developer guidance, CTG developer theory, and CTG ROM layout cover the v0.1.1.1 additive contract surface
- Release, monitoring, incident, and security operations remain Planned

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
- v0.0.5 (2026-06-05): Added contract-surface purity cleanup, external Capability module, DynamicSLM Model ABI / SeedSLM discipline / distillation offload, HATL external cryptographic operator, governance admissibility, and Semantic Compilation DTO vocabulary migration coverage
- v0.1.0 (2026-06-07): Added MemoryRegion / MemoryMapper contract extraction coverage
- v0.1.1 (2026-06-10): Added package installation and demo program guides for the synchronized public release line
- v0.1.1.1 (2026-06-14): Added CTG developer guide, CTG Developer Theory, Monolith CTG-ROM layout coverage, and the NuGet-only package boundary for 0.1.1.1
