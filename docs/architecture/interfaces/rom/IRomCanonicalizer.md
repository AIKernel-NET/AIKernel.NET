---
title: 'IRomCanonicalizer'
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

For Japanese version, see [IRomCanonicalizer-jp.md](./IRomCanonicalizer-jp.md).

# IRomCanonicalizer (ROM Canonicalization Interface Specification)

## 1. Responsibility Boundary
`IRomCanonicalizer` transforms heterogeneous ROM representations into meaning-preserving canonical form, enabling deterministic comparison, signing, and verification.

- Role:
  Normalize newline/order/whitespace/reference representation so semantically equal inputs produce identical canonical outputs.
- Non-role:
  ROM execution and physical I/O are out of scope; this contract focuses on canonical transformation only.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Rom;

public interface IRomCanonicalizer
{
    CanonicalizedRomDto Canonicalize(IRomDocument document);

    Task<CanonicalizedRomDto> CanonicalizeAsync(IRomDocument document, CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-13` Runtime signature verification and governance:
  Removes formatting drift from signature validation semantics.
- `UC-20` Deterministic replay:
  Strengthens semantic-equivalence checks against runtime ROM artifacts.
- `UC-01` ROM loading and parsing:
  Stabilizes structure before downstream resolution/execution.

## 4. Governance & Determinism
- Deterministic stability:
  Semantically identical inputs must yield identical `CanonicalizedRomDto` regardless of platform/runtime.
- Semantic preservation:
  Canonicalization must not alter intended ROM semantics.
- Hash invariance foundation:
  Canonical outputs underpin signing/verification pipelines and require strict compatibility discipline.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should surface clear categories for:

- Syntax/shape failures:
  ROM cannot be canonicalized due to malformed structure.
- Unsupported versions:
  ROM schema/version not supported by current canonicalizer.

## 6. Implementation Notes
- Metadata normalization:
  Normalize front matter and key ordering policies explicitly.
- Extensibility:
  Preserve canonicalization consistency for future multimodal-linked assets.
- Locale discipline:
  Define language/character normalization policies to preserve cross-locale replay stability.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
