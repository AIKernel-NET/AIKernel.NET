---
title: "AIKernel Architecture Interfaces — Index"
created: 2026-05-03
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
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
- [context/index.md](context/index.md)
- [contracts/index.md](contracts/index.md)
- [conversation/index.md](conversation/index.md)
- [dynamicslm/index.md](dynamicslm/index.md)
- [dsl/index.md](dsl/index.md)
- [execution/index.md](execution/index.md)
- [governance/index.md](governance/index.md)
- [history/index.md](history/index.md)
- [hosting/index.md](hosting/index.md)
- [kernel/index.md](kernel/index.md)
- [material/index.md](material/index.md)
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
- `kernel`: execution entry and lifecycle contracts.
- `dsl`: deterministic semantic IR, DSL pipeline, DSL ROM registry, and VFS-backed DSL ROM store contracts.
- `dynamicslm`: Model ABI, capability subgraph resolution, lineage verification, payload materialization, scheduling, and differential distillation contracts for capability-modular SLM artifacts.
- `governance`: attention guard, audit logger, signature trust, context lifecycle, and ChatChain hash-chain contracts.
- `history`: history summarization and History ROM registry/export/store contracts.
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
- v0.0.5 (2026-06-05): Added DynamicSLM Model ABI interface category
