---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Query Interfaces — Index"
created: 2026-05-09
updated: 2026-05-09
tags:
  - aikernel
  - architecture
  - interfaces
  - query-processing
  - english
---

For Japanese version, see index-jp.md.

# AIKernel Query Interfaces — Index

The `query` namespace contains Phase 1 Context Build abstractions. These contracts transform query intent before ROM, CacheDB, Material Quarantine, and Structure execution.

## Interfaces

- `IQueryAugmentor`: normalizes, augments, and semantically rewrites a query under `IKernelContext`.
- `IQueryDecomposer`: decomposes a query into ordered `QueryPart` units under `IKernelContext`.
- `IQueryRouter`: routes `QueryPart` units to providers using declared capabilities and `IKernelContext`.

## DTO

- `QueryPart`: immutable query fragment DTO produced by decomposition and consumed by routing/material build.

## Boundary

RAG is not implemented here. Retrieval, indexing, and material supply remain provider or pipeline strategy responsibilities.

---

# Changelog
- v0.0.1 (2026-05-09): Initial query interface index
