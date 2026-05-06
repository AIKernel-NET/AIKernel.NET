---
id: iragprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IRagProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IRagProvider-jp.md](./IRagProvider-jp.md).

# IRagProvider (Interface Specification)

## 1. Responsibility Boundary
`IRagProvider` is the retrieval boundary that supplies Material-layer knowledge by searching, indexing, and managing external memory.

- Role:
  Abstracts vector/search backend differences behind a consistent retrieval API.
- Non-role:
  Final material selection and prompt composition remain orchestration-layer responsibilities.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

using AIKernel.Dtos.Context;

public interface IRagProvider : IProvider
{
    Task<IReadOnlyList<MaterialContextDto>> SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default);
    Task IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default);
    Task DeleteAsync(string documentId, CancellationToken cancellationToken = default);
    Task ClearAsync(CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-11` RAG:
  Primary source for dynamically filling Material buffers at runtime.
- `UC-05` Material relevance evaluation:
  Provides candidate material for relevance scoring and inclusion decisions.

## 4. Governance & Determinism
- Replay integrity:
  Because `SearchAsync` depends on mutable external state, runtime retrieval snapshots must be persisted.
- Fail-Closed:
  On timeout/failure, expose incomplete-knowledge state and apply safe-side restrictions.
- Pollution prevention:
  Validate indexed content against injection-like directives before admitting into retrieval corpus.

## 5. Implementation Notes
- Metadata quality:
  Carry provenance/freshness/trust metadata in `MaterialContextDto` for downstream filtering.
- Semantic retrieval:
  Combine keyword retrieval with `IEmbeddingProvider`-based semantic search for robust recall.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
