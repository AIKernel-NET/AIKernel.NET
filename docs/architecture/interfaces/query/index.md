---
title: "AIKernel Query Interfaces — Index"
created: 2026-05-09
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - query-processing
  - english
---

Japanese version: [Specification Index](specs/index-jp.md)

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
