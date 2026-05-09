---
id: iembeddingprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IEmbeddingProvider"
created: 2026-05-03
updated: 2026-05-09
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IEmbeddingProvider-jp.md](./IEmbeddingProvider-jp.md).

# IEmbeddingProvider (Interface Specification)

## 1. Responsibility Boundary
`IEmbeddingProvider` converts text into semantic vectors and supplies numeric foundations for semantic-space operations in Phase 1.

- Role:
  Provide single/batch embedding generation and vector-dimension metadata.
- Non-role:
  Vector persistence, indexing, nearest-neighbor search, and Core knowledge retrieval are out of scope.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

public interface ITextEmbeddingProvider
{
    Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default);
}

public interface IBatchEmbeddingProvider
{
    Task<IReadOnlyList<float[]>> EmbedBatchAsync(IReadOnlyList<string> texts, CancellationToken cancellationToken = default);
}

public interface IEmbeddingDimensionProvider
{
    int GetDimension();
}

public interface IEmbeddingProvider :
    IProvider,
    ITextEmbeddingProvider,
    IBatchEmbeddingProvider,
    IEmbeddingDimensionProvider
{
}
```

## 3. Related Use Cases
- `UC-05` Material relevance evaluation:
  Uses embeddings for similarity-based material filtering.
- `UC-11` RAG:
  Projects queries and material chunks into a common vector space when a provider or pipeline strategy performs material retrieval.
- Phase 1 Query Processing:
  Supports optional semantic projection after `IQueryDecomposer` has produced `QueryPart` units.

## 4. Governance & Determinism
- Model stability:
  For the same `ProviderId` and configuration, embedding dimensionality/space behavior should not drift silently.
- Fail-Closed:
  Input-limit violations or dimension mismatches should fail explicitly instead of returning partial semantics.
- RAG boundary:
  Embedding support does not make Core a retrieval engine; it only exposes semantic projection capability.

## 5. Implementation Notes
- Dimension consistency:
  Ensure `GetDimension()` always matches produced vector lengths.
- Batch throttling:
  `EmbedBatchAsync` should consider provider rate limits and apply chunking when required.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.1 (2026-05-09): Aligned embedding docs with split capabilities and Phase 1 Query Processing
