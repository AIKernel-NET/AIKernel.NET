---
version: 0.0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ISignatureTrustStore Interface Draft"
created: 2026-05-04
updated: 2026-05-04
tags:
  - aikernel
  - architecture
  - interfaces
  - prompt
  - governance
  - english
---

For Japanese version, see `ISignatureTrustStore-jp.md`.

# ISignatureTrustStore

## Purpose
Defines a trust-anchor abstraction used by signed prompt governance to resolve signer trust, key validity, and revocation status in a provider-agnostic way.

## Responsibility
- Resolve trusted signer identities and associated verification material.
- Evaluate trust status (trusted / revoked / expired / unknown).
- Expose trust metadata required for audit records.

## Key Members (Draft)
```csharp
public interface ISignatureTrustStore
{
    Task<SignerTrustRecord?> GetSignerAsync(string signerId, CancellationToken ct = default);
    Task<TrustDecision> EvaluateAsync(SignatureEnvelope envelope, CancellationToken ct = default);
    Task<IReadOnlyList<SignerTrustRecord>> ListTrustedSignersAsync(CancellationToken ct = default);
}
```

## Supporting Contracts (Draft)
```csharp
public sealed record SignerTrustRecord(
    string SignerId,
    string KeyId,
    string Algorithm,
    DateTimeOffset ValidFromUtc,
    DateTimeOffset ValidToUtc,
    bool IsRevoked,
    IReadOnlyDictionary<string, string>? Metadata = null);

public sealed record SignatureEnvelope(
    string SignerId,
    string KeyId,
    string Algorithm,
    string Signature,
    string PayloadHash,
    DateTimeOffset SignedAtUtc);

public enum TrustDecision
{
    Trusted = 1,
    Revoked = 2,
    Expired = 3,
    UnknownSigner = 4,
    InvalidKeyBinding = 5,
    Indeterminate = 6
}
```

## Use Cases
- Signed prompt execution preflight in `IPromptVerifier`.
- Policy authorization checks in `IPromptValidator`.
- Audit chain enrichment in replay dump generation.

## Fail-Closed Semantics
- `Indeterminate` or unresolved signer state must result in execution denial.
- Missing trust anchor must never downgrade to warning-only mode.

