---
title: 'IRelationResolver'
created: 2026-05-06
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

For Japanese version, see [IRelationResolver-jp.md](./IRelationResolver-jp.md).

# IRelationResolver (Relation Resolution Interface Specification)

## 1. Responsibility Boundary
`IRelationResolver` is the semantic-linking boundary that resolves ROM reference IDs into concrete executable/data entities.

- Role:
  Resolve reference identifiers into `ResolvableEntity` and expose preflight resolvability checks.
- Non-role:
  Physical storage access and cache lifecycle remain delegated to lower-layer providers.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Rom;

public interface IRelationResolver
{
    Task<AIKernel.Dtos.Rom.ResolvableEntity?> ResolveAsync(string referenceId, CancellationToken cancellationToken = default);
    Task<bool> CanResolveAsync(string referenceId, CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-01` ROM loading and parsing:
  Dynamically links template references to concrete assets.
- `UC-15` Context hydration:
  Expands runtime context from abstract identifiers.
- `UC-12` Reference integrity validation:
  Performs early resolvability checks before execution.

## 4. Governance & Determinism
- Deterministic resolution:
  Identical `referenceId` and source state must yield identical resolution outcomes.
- Fail-Closed:
  Missing required references must block execution to avoid incomplete context runs.
- Cycle protection:
  Detect cyclic reference graphs to prevent infinite expansion and stack exhaustion.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should clearly surface:

- Invalid reference format:
  Identifier does not match expected schema.
- Resolution substrate failure:
  Data-source access/load failures during resolve operations.

## 6. Implementation Notes
- Protocol dispatch:
  Delegate by scheme prefix (e.g., `vfs://`, `db://`) to specialized sub-resolvers.
- Entity flexibility:
  Keep `ResolvableEntity` extensible for text, structured, and binary asset forms.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
