---
id: imaterialquarantine
title: "IMaterialQuarantine"
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

Japanese version: [IMaterialQuarantine (インターフェース仕様)](architecture/interfaces/material/IMaterialQuarantine-jp.md)

# IMaterialQuarantine (Interface Specification)

## 1. Responsibility Boundary
`IMaterialQuarantine` defines the boundary responsible for safety enforcement and structural canonicalization of materials ingested into the AI system (external data, RAG outputs, user files, and related sources).

- Role:
  Promote unverified `ContextFragment` inputs into trusted and structured `IStructuredMaterial`.
- Non-role:
  Physical scanning (malware, corruption, low-level validation) belongs to `IMaterialScanner`. `IMaterialQuarantine` focuses on governance-driven quarantine logic and shape conversion.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Material;

/// <summary>
/// Quarantines external material and converts it into a structured form
/// that can be safely consumed by the system.
/// </summary>
public interface IMaterialQuarantine
{
    /// <summary>
    /// Quarantines and normalizes an unverified fragment.
    /// </summary>
    /// <param name="rawFragment">Raw fragment to quarantine</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Quarantined structured material</returns>
    Task<IStructuredMaterial> QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default);
}
```

Note:
`QuarantineViolationException` and `InvalidMaterialFormatException` are representative implementation-layer exception names. The current abstraction contract does not hard-code exception type names.

## 3. Related Use Cases
- `UC-07` Material Quarantine:
  Acts as the first guardrail during external material ingestion.
- `UC-21` Material Quarantine and Policy Enforcement:
  Works with `IPdp` and `IMaterialScanner` to block policy-noncompliant material.

## 4. Governance & Determinism
- Fail-Closed:
  If evaluation becomes indeterminate or validation fails unexpectedly, processing must terminate on the reject side.
- Canonicalization expectation:
  Logically equivalent inputs must converge to equivalent `IStructuredMaterial` output forms, contributing to deterministic replay.

## 5. Implementation Notes
- If trust score from `IMaterialScanner` is below threshold, reject quarantine by policy.
- During conversion to `IStructuredMaterial`, apply policy-based PII masking and confidential data removal.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
