---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Architecture Interfaces — Index"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# AIKernel Architecture Interfaces — Index

## Namespaces
- [context/index.md](context/index.md)
- [contracts/index.md](contracts/index.md)
- [conversation/index.md](conversation/index.md)
- [execution/index.md](execution/index.md)
- [governance/index.md](governance/index.md)
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
- [tooling/index.md](tooling/index.md)
- [vfs/index.md](vfs/index.md)

## Namespace Overview
- `kernel`: execution entry and lifecycle contracts.
- `models`: capability axes, dynamic capacity, and execution constraints.
- `query`: Phase 1 query augmentation, decomposition, and routing contracts.
- `security`: deterministic authorization contracts via PDP/Guard.
- `tasks`: task units and pipeline result contracts.
- `scheduling`: scheduled job and execution-result contracts.
- Existing categories (context to vfs) now include responsibility/UC/spec linkage in each index.

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added categories and synchronized links with src
- v0.0.1 (2026-05-09): Added query interface category
