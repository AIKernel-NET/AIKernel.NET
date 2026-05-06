---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ISignatureTrustStore Interface Draft"
created: 2026-05-04
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - prompt
  - governance
  - english
---

For Japanese version, see [ISignatureTrustStore-jp.md](./ISignatureTrustStore-jp.md).

# ISignatureTrustStore (Interface Specification)

## 1. Responsibility Boundary
`ISignatureTrustStore` is the trust-anchor boundary that evaluates signer trust, key revocation, certificate-chain validity, and anchor health.

- Role:
  Provide signer trust-score resolution, key revocation checks, expiry checks, chain verification, trusted-anchor discovery, and store health checks.
- Non-role:
  Cryptographic signature matching itself belongs to `IPromptVerifier`.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Governance;

public interface ISignatureTrustStore
{
    Task<double> ResolveTrustScoreAsync(string signerId, CancellationToken cancellationToken = default);
    Task<bool> IsKeyRevokedAsync(string keyId, CancellationToken cancellationToken = default);
    Task<DateTime?> GetKeyExpiryAsync(string keyId, CancellationToken cancellationToken = default);
    Task<bool> VerifyCertificateChainAsync(string signerId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<string>> GetTrustedAnchorsAsync(CancellationToken cancellationToken = default);
    Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-13` Runtime signature verification and governance:
  Resolves signer trust prerequisites before signature acceptance.
- `UC-20` Deterministic replay and audit chain:
  Enables historical validation of trust decisions at execution time.
- `UC-32` Trust-anchor operations:
  Monitors revocation, expiry, and chain status.

## 4. Fail-Closed Semantics
- If `ResolveTrustScoreAsync` returns negative (unreachable/untrusted), execution must be denied.
- If `IsHealthyAsync` is `false`, do not downgrade to warning-only mode.
- Revoked or expired keys must trigger immediate blocking.

## 5. Governance & Determinism
- Deterministic trust evaluation:
  Under identical time/context inputs, trust outcomes should be reproducible.
- Audit integrity:
  Decisions and evidence (keyId, expiry, chain, anchors) should be traceable in audit logs.

## 6. Implementation Notes
- Revocation freshness:
  Treat CRL/OCSP fetch failures as fail-closed conditions.
- Snapshot discipline:
  Persist trust-state snapshots to replay "as-of-execution-time" decisions accurately.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
