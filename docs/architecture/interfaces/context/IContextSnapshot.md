---
id: icontextsnapshot
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IContextSnapshot"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IContextSnapshot-jp.md.

# IContextSnapshot (Interface Specification)

## 1. Responsibility Boundary
`IContextSnapshot` is the boundary interface that fixes a point-in-time `IContextCollection` with integrity metadata for auditability and deterministic replay.

- Role:
  Expose snapshot identity, lineage, timestamp, integrity hash, and frozen context payload.
- Non-role:
  Storage backend and serialization format are out of scope.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Context;

public interface IContextSnapshot
{
    string SnapshotId { get; }
    string? ParentSnapshotId { get; }
    DateTimeOffset CreatedAtUtc { get; }
    string ContextHash { get; }
    IContextCollection Context { get; }
}
```

## 3. Related Use Cases
- `UC-20` Deterministic replay and audit trail:
  Reconstructs historical execution conditions from a fixed snapshot baseline.
- `UC-09` Execution state persistence and restore:
  Provides a consistent anchor for suspend/resume workflows.

## 4. Governance & Determinism
- Immutability:
  Snapshot content is expected to remain immutable once finalized.
- Integrity:
  `ContextHash` must remain consistent with the referenced `Context` payload.
- Fail-Closed:
  Reject restore/replay when hash mismatch, mandatory-field loss, or prerequisite divergence is detected.

## 5. Implementation Notes
- Lineage tracking:
  Use `ParentSnapshotId` to preserve traceable delta lineage.
- Time normalization:
  Keep `CreatedAtUtc` in UTC to remove audit timeline ambiguity.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
