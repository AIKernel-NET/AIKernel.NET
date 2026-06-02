---
id: icontextcollection
title: "IContextCollection"
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

Japanese version: [IContextCollection (インターフェース仕様)](architecture/interfaces/context/IContextCollection-jp.md)

# IContextCollection (Interface Specification)

## 1. Responsibility Boundary
`IContextCollection` is the boundary interface for managing runtime context fragments and enforcing phase-specific buffer boundaries during reasoning cycles.

- Role:
  Manage categorized `ContextFragment` data and provide `Orchestration/Material/Expression/History` buffers.
- Non-role:
  Persistence, external retrieval, and storage integration are out of scope. This interface focuses on in-cycle working memory.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Context;

public interface IContextCollection
{
    IEnumerable<ContextFragment> GetAll();
    IEnumerable<ContextFragment> GetByCategory(ContextCategory category);
    OrchestrationBuffer GetOrchestrationBuffer();
    ExpressionBuffer GetExpressionBuffer();
    MaterialBuffer GetMaterialBuffer();
    HistoryBuffer GetHistoryBuffer();
}
```

## 3. Related Use Cases
- `UC-06` Three-layer buffer boundary (Context Isolation):
  Maintains separation of instruction/material/expression to reduce attention pollution.
- `UC-02` Structure phase execution:
  Supplies inputs required by `IThoughtProcess` logic construction.

## 4. Governance & Determinism
- Immutability in-cycle:
  Buffer content should be treated as immutable within a single reasoning cycle.
- Deterministic ordering:
  `GetAll()` / `GetByCategory()` should return stable ordering for identical inputs.
- Fail-Closed:
  Missing mandatory categories should terminate on the deny side instead of allowing partial execution.

## 5. Implementation Notes
- Preserve boundaries:
  Keep explicit buffer demarcation conventions during rendering to avoid category bleed.
- Memory efficiency:
  Prefer reference-based handling for large material payloads and minimize deep copies.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
