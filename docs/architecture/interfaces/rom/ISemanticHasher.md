---
title: 'ISemanticHasher'
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

For Japanese version, see [ISemanticHasher-jp.md](./ISemanticHasher-jp.md).

# ISemanticHasher (Semantic Hash Interface Specification)

## 1. Responsibility Boundary
`ISemanticHasher` computes and verifies deterministic hash fingerprints representing canonical ROM semantics.

- Role:
  Produce algorithm-bound deterministic digests and verify digest equality against expected values.
- Non-role:
  Canonicalization itself is delegated to `IRomCanonicalizer`.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Rom;

public interface ISemanticHasher
{
    string Algorithm { get; }

    string ComputeHash(CanonicalizedRomDto canonicalized);

    Task<string> ComputeHashAsync(CanonicalizedRomDto canonicalized, CancellationToken cancellationToken = default);

    bool VerifyHash(CanonicalizedRomDto canonicalized, string expectedHash);

    Task<bool> VerifyHashAsync(
        CanonicalizedRomDto canonicalized,
        string expectedHash,
        CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-13` Runtime signature verification and governance:
  Provides digest foundation for signature payload checks.
- `UC-20` Deterministic replay:
  Enables fast semantic equivalence checks between runtime and stored ROM.
- `UC-01` ROM load validation:
  Supports integrity checks at ingestion.

## 4. Governance & Determinism
- Full determinism:
  Same `Algorithm` + same `CanonicalizedRomDto` must yield identical hash text.
- Collision resistance:
  Implementations should use modern secure hash functions to reduce semantic-collision risk.
- Algorithm consistency:
  Behavior changes affecting persisted hashes require strict compatibility governance.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should clearly surface:

- Crypto subsystem failures:
  Digest computation infrastructure errors.
- Unsupported algorithms:
  Algorithm requested but unavailable in current runtime.

## 6. Implementation Notes
- Prefix format:
  Prefer algorithm-tagged hash notation (e.g., `sha256:...`) for crypto agility.
- Asset-chain integrity:
  Include referenced binary-asset digests in canonical payloads to preserve end-to-end integrity.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
