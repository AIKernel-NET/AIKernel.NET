---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Architecture Interfaces — Index"
created: 2026-05-03
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
- [conversation/index.md](conversation/index.md)
- [execution/index.md](execution/index.md)
- [governance/index.md](governance/index.md)
- [hosting/index.md](hosting/index.md)
- [material/index.md](material/index.md)
- [models/index.md](models/index.md)
- [pipeline/index.md](pipeline/index.md)
- [prompt/index.md](prompt/index.md)
- [provider/index.md](provider/index.md)
- [tooling/index.md](tooling/index.md)
- [vfs/index.md](vfs/index.md)

## Namespace Overview
- `context`: `ContextFragment` lifecycle, context serialization/snapshots, and intake normalization.
- `conversation`: branching/checkpoint/diff contracts for chat state lineage.
- `execution`: two-phase boundary contracts (`IThoughtProcess`, `IOutputPolisher`).
- `governance`: fail-closed guards, audit events, attention/lifecycle observation.
- `hosting`: kernel hosting lifecycle and DI/provider registration contracts.
- `material`: quarantine and structured material contracts.
- `models`: capacity vectors, routing, token/vector estimation, and shape advisory.
- `pipeline`: deterministic pipeline orchestration and task execution contracts.
- `prompt`: signed prompt governance and verification chain with `IPromptVerifier`.
- `provider`: provider runtime, retrieval/model/event/scheduler contracts, and economics profiles.
- `tooling`: tool permission validation and sandbox execution boundaries.
- `vfs`: virtual filesystem provider and session abstractions.
