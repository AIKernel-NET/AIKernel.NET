---
id: iembeddingprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IEmbeddingProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IEmbeddingProvider-jp.md](./IEmbeddingProvider-jp.md).

# IEmbeddingProvider (Interface Specification)

## 1. Responsibility Boundary
`IEmbeddingProvider` converts unstructured text into semantic vectors and supplies numeric foundations for retrieval and relevance evaluation.

- Role:
  Provide single/batch embedding generation and vector-dimension metadata.
- Non-role:
  Vector persistence, indexing, and nearest-neighbor search are out of scope.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

public interface IEmbeddingProvider : IProvider
{
    Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<float[]>> EmbedBatchAsync(IReadOnlyList<string> texts, CancellationToken cancellationToken = default);
    int GetDimension();
}
```

## 3. Related Use Cases
- `UC-05` Material relevance evaluation:
  Uses embeddings for similarity-based material filtering.
- `UC-11` RAG:
  Projects queries and document chunks into a common vector space for retrieval.

## 4. Governance & Determinism
- Model stability:
  For the same `ProviderId` and configuration, embedding dimensionality/space behavior should not drift silently.
- Fail-Closed:
  Input-limit violations or dimension mismatches should fail explicitly instead of returning partial semantics.

## 5. Implementation Notes
- Dimension consistency:
  Ensure `GetDimension()` always matches produced vector lengths.
- Batch throttling:
  `EmbedBatchAsync` should consider provider rate limits and apply chunking when required.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
