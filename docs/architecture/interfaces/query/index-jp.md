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
  - japanese
---

英語版は index.md を参照。

# AIKernel Query Interfaces — Index

`query` namespace は Phase 1 Context Build の抽象を含みます。これらの contract は ROM、CacheDB、Material Quarantine、Structure 実行より前に query intent を変換します。

## Interfaces

- `IQueryAugmentor`: `IKernelContext` の下で query を正規化・補間・意味的に rewrite します。
- `IQueryDecomposer`: `IKernelContext` の下で query を順序付き `QueryPart` に分解します。
- `IQueryRouter`: 宣言済み capability と `IKernelContext` に基づき、`QueryPart` を Provider へ routing します。

## DTO

- `QueryPart`: decomposition が生成し、routing/material build が消費する immutable query fragment DTO。

## Boundary

ここでは RAG を実装しません。Retrieval、indexing、material supply は Provider または Pipeline 戦略の責務です。

---

# 変更履歴
- v0.0.1 (2026-05-09): query interface index を追加
