---
id: ipromptverifier
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IPromptVerifier"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IPromptVerifier-jp.md.

# IPromptVerifier (Interface Specification)

## 1. Responsibility Boundary
`IPromptVerifier` is the boundary interface that validates integrity of signed prompt artifacts at runtime.

- Role:
  Evaluate a `SignedPromptArtifactDto` and return tamper/missing/mismatch outcomes through `PromptVerificationResult`.
- Non-role:
  Signature generation is owned by `IPromptSignatureProvider`; `IPromptVerifier` focuses only on verification.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// Defines the IPromptVerifier contract based on UC-11/UC-12/UC-13.
/// </summary>
public interface IPromptVerifier
{
    Task<PromptVerificationResult> VerifyAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}
```

## 3. Related Use Cases
- `UC-13` Runtime signature verification:
  Core component for signature and hash validation during prompt load.
- `UC-20` Deterministic replay and audit trail:
  Contributes to verifying replay artifacts against historical execution conditions.

## 4. Governance & Determinism
- Enforce Fail-Closed:
  Execution must not continue when `PromptVerificationResult.Decision` does not satisfy permit criteria.
- Canonicalization precondition:
  Signature/hash validation assumes the same canonicalization rules (`IRomCanonicalizer`) used at signing time.

## 5. Implementation Notes
- Trust-store integration:
  Integrating with `ISignatureTrustStore` is recommended to reject revoked or untrusted keys.
- Semantic hash validation:
  Prefer semantic-equivalence checks aligned with `ISemanticHasher` over superficial string equality.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
