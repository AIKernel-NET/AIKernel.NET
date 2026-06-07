---
title: "AIKernel Architecture Interfaces — Index"
created: 2026-05-03
updated: 2026-06-07
published: 2026-05-16
version: "0.1.0"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

Japanese version: [Index](index-jp.md)

# AIKernel Architecture Interfaces — Index

## Namespaces
- [capabilities/index.md](capabilities/index.md)
- [context/index.md](context/index.md)
- [contracts/index.md](contracts/index.md)
- [control/index.md](control/index.md)
- [conversation/index.md](conversation/index.md)
- [dynamicslm/index.md](dynamicslm/index.md)
- [dsl/index.md](dsl/index.md)
- [execution/index.md](execution/index.md)
- [governance/index.md](governance/index.md)
- [hatl/index.md](hatl/index.md)
- [history/index.md](history/index.md)
- [hosting/index.md](hosting/index.md)
- [kernel/index.md](kernel/index.md)
- [material/index.md](material/index.md)
- [memory/index.md](memory/index.md)
- [models/index.md](models/index.md)
- [pipeline/index.md](pipeline/index.md)
- [prompt/index.md](prompt/index.md)
- [provider/index.md](provider/index.md)
- [query/index.md](query/index.md)
- [rom/index.md](rom/index.md)
- [routing/index.md](routing/index.md)
- [rules/index.md](rules/index.md)
- [scheduling/index.md](scheduling/index.md)
- [security/index.md](security/index.md)
- [tasks/index.md](tasks/index.md)
- [time/index.md](time/index.md)
- [tooling/index.md](tooling/index.md)
- [vfs/index.md](vfs/index.md)

## Namespace Overview
- `capabilities`: external Capability module registry and invocation boundary contracts for CLI, managed assembly, native ABI, DSL ROM, and remote endpoint modules.
- `control`: Control Plane contracts for semantic graph to physical execution mapping.
- `kernel`: execution entry and lifecycle contracts.
- `dsl`: deterministic semantic IR, DSL pipeline, DSL ROM registry, and VFS-backed DSL ROM store contracts.
- `dynamicslm`: Model ABI, capability subgraph resolution, lineage verification, payload materialization, scheduling, differential distillation planning, and background offload contracts for capability-modular SLM artifacts.
- `governance`: attention guard, audit logger, signature trust, context lifecycle, ChatChain hash-chain contracts, admission replay evidence, and Semantic IR slot vocabulary.
- `hatl`: Hash-Anchored Trust Layer ledger, public anchor, Digital Deed, and external cryptographic operator contracts.
- `history`: history summarization and History ROM registry/export/store contracts.
- `memory`: OS-independent MemoryRegion / MemoryMapper contract surface owned by AIKernel.NET, with Result-based runtime adapters left to Core/Common.
- `models`: capability axes, dynamic capacity, and execution constraints.
- `query`: Phase 1 query augmentation, decomposition, and routing contracts.
- `security`: deterministic authorization contracts via PDP/Guard.
- `tasks`: task units and pipeline result contracts.
- `scheduling`: scheduled job and execution-result contracts.
- `time`: deterministic Kernel clock contracts.
- `vfs`: Vfs contracts are owned by `AIKernel.Abstractions` while preserving the public `AIKernel.Vfs` namespace.
- Existing categories (context to vfs) now include responsibility/UC/spec linkage in each index.

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added categories and synchronized links with src
- v0.0.1 (2026-05-09): Added query interface category
- v0.0.3 (2026-06-02): Added Vfs contract ownership note
- v0.0.4 (2026-06-04): Added DSL, History ROM, and Time interface categories
- v0.0.4 (2026-06-04): Clarified governance coverage for audit and ChatChain contracts
- v0.0.5 (2026-06-05): Added DynamicSLM Model ABI, distillation offload, and SeedSLM discipline interface category
- v0.0.5 (2026-06-05): Added HATL interface category for external cryptographic operators
- v0.0.5 (2026-06-05): Added governance vocabulary for admission replay and Semantic IR slots
- v0.0.5 (2026-06-05): Added external Capability module interface category
- v0.1.0 (2026-06-07): Added MemoryRegion / MemoryMapper interface category and ownership note
- v0.1.0 (2026-06-07): Added Control Plane interface category and ownership note
