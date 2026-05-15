---
id: iprovidercapabilities
title: "IProviderCapabilities"
created: 2026-05-03
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
  - english
---

For Japanese version, see [IProviderCapabilities-jp.md](./IProviderCapabilities-jp.md).

# IProviderCapabilities (Interface Specification)

## 1. Responsibility Boundary
`IProviderCapabilities` is the capability specification sheet used by routing/governance to evaluate what a provider can do and under which constraints.

- Role:
  Expose supported operations/data types, concurrency ceilings, rate limits, static capacity vector, dynamic capacity views, query-processing support, and embedding metadata.
- Non-role:
  It does not execute inference; it declares capability metadata only.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Providers;

using AIKernel.Abstractions.Models;

public interface IProviderCapabilities :
    IProviderOperationCapabilities,
    IProviderConnectionCapabilities,
    IProviderCapacityVectorSource,
    IDynamicProviderCapacitySource,
    IProviderProfileSource,
    IQuantizationSupport,
    IQueryProcessingCapabilities,
    IEmbeddingCapabilityMetadata
{
}

public interface IQueryProcessingCapabilities
{
    bool SupportsQueryAugmentation { get; }
    bool SupportsQueryDecomposition { get; }
    bool SupportsQueryRouting { get; }
    int MaxQueryParts { get; }
    IReadOnlyList<string> SupportedQueryProcessingOperations { get; }
    bool SupportsQueryProcessingOperation(string operation);
}

public interface IEmbeddingCapabilityMetadata
{
    bool SupportsEmbedding { get; }
    int? EmbeddingDimensions { get; }
    IReadOnlyList<string> SupportedEmbeddingModels { get; }
}
```

## 3. Related Use Cases
- `UC-03` Model vector routing:
  Uses `Vector` and dynamic capacities for candidate matching.
- `UC-22` Dynamic capacity control:
  Uses `RateLimit` and runtime capacities for throttling and route weighting.
- Phase 1 Query Processing:
  Uses query and embedding capability metadata for `IQueryRouter` candidate selection.

## 4. Governance & Determinism
- Capability accuracy:
  If declared operations are not actually executable, mark provider unhealthy and fail closed.
- Replay integrity:
  Snapshot dynamic capacity values at execution time for deterministic audit/replay reasoning.
- Backend transparency:
  Return comparable metrics regardless of cloud API vs local runtime backend.
- Query boundary:
  Query-processing capability metadata must not imply that Core implements retrieval or indexing.

## 5. Implementation Notes
- Vector dimension discipline:
  Keep `ModelCapacityVector` dimensions consistent for fair comparison.
- Cache strategy:
  If dynamic probes are cached, enforce explicit TTL to balance freshness and stability.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.1 (2026-05-09): Added query-processing and embedding capability metadata
