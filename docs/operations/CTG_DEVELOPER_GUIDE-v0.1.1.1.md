---
updated: 2026-06-14
published: 2026-06-14
version: "0.1.1.1"
edition: "Draft"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

Japanese version: [CTG Developer Guide](CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md)

# CTG Developer Guide v0.1.1.1

This guide is the runbook for adding, reviewing, and consuming Canonical
Trajectory Governance contracts. It is written for developers. It does not add
canon rule text.

The fixed theoretical reference is Paper 12:

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- DOI: https://doi.org/10.5281/zenodo.20681895

The paper is Zenodo-published and must not be edited to follow later
implementation details. Implementation contracts may be more detailed than the
paper as long as they preserve the paper's invariants.

---

## 1. Contract-Only Rule

AIKernel.NET accepts only the CTG contract layer:

- interfaces in `AIKernel.Abstractions.Governance`
- records in `AIKernel.Dtos.Governance`
- enums in `AIKernel.Enums.Governance`
- bilingual XML documentation for public API

Do not add runtime engines, provider strategies, rule interpreters, canon body
text, or file-system readers to this repository.

---

## 2. Adding a CTG Contract

Before adding a type, confirm that the concept is a stable contract concept and
not runtime behavior.

Use this sequence:

1. Add the enum first when the contract needs a closed vocabulary.
2. Add DTO carriers with immutable record shape and initialized collections.
3. Add interface signatures only after request and response DTOs are stable.
4. Add bilingual XML documentation to every public type and member.
5. Update architecture, design, or operations docs if the contract changes the
   public vocabulary.

Existing public interface signatures must not be changed.

---

## 3. Runtime Implementation Guidance

Runtime hosts that implement CTG contracts should follow these rules:

- treat missing canon as fail-closed
- treat unknown enum values as fail-closed
- preserve raw unknown enum values in diagnostics or metadata
- propagate `CanonReference` values without inventing canon text
- preserve `RejectReasonInfo` in gate and trajectory results
- fill `StepGovernanceTrace` and `GovernanceTrace` for replay
- use `Confidence` and `RiskScore` as observation data only
- keep cancellation as the only routine exception path

The runtime package owns algorithm execution. AIKernel.NET owns only the shared
contract vocabulary.

---

## 4. Gate Review Checklist

When reviewing a gate-related contract or implementation outside AIKernel.NET,
verify:

- Ethos reject or explicit veto can close the gate.
- Unknown and missing values close the gate.
- Inconclusive evidence closes the gate.
- No confidence or risk weighting changes the decision.
- C# enum numeric values are not used directly as mathematical vote weights.
- Contract vote values are mapped to the finite CTG table before aggregate
  evaluation.
- The accepted or rejected result is represented by a result DTO.
- Rejection carries `RejectReasonInfo`.
- Canon evidence carries `IReadOnlyList<CanonReference>`.
- Step and trajectory traces are deterministic and ordered.

---

## 5. Diagnostics and Telemetry

Unknown enum handling must be observable. When a consumer sees an unknown enum
value, it should:

1. fail closed
2. record the raw numeric value in diagnostics or metadata
3. emit telemetry when a telemetry surface exists
4. avoid coercing unknown values into known enum members

Use [Enum Handling Policy](ENUM_HANDLING_POLICY-v0.1.1.1.md) as the canonical
policy for this behavior.

---

## 6. Validation Commands

Run these commands before publishing CTG contract changes:

```powershell
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
dotnet pack src\AIKernel.NET.slnx -c Release
```

For local development packages:

```powershell
dotnet pack src\AIKernel.NET.slnx -c Release -p:UseLocalPackageVersion=true -p:LocalPackageBuildNumber=<build-number>
```

The local package version format is:

```text
0.1.1-dev<build-number>
```

---

## 7. Paper Alignment Checklist

For CTG-related changes, verify:

- The change does not edit the published paper package.
- CTG remains a three-council gateway over Logos, Ethos, and Pathos.
- Ethos denial remains a hard execution boundary.
- Execution admission requires a strictly positive mapped aggregate vote when no
  Ethos denial exists.
- Ambiguous, missing, unknown, zero, or negative cases fail closed.
- Trajectory validity is represented as all step-level gates admitting execution.
- CTG-ROM remains a governance/persona contract, not a prompt.
- PPM is not treated as the CTG execution gate.
- HATL remains the integrity/provenance layer for state, memory, and replayable
  records.

---

## 8. Pull Request Checklist

- No existing public interface signature changed.
- No implementation class was added.
- No canon rule body was added.
- No mechanical expansion suffix was introduced.
- No new enum lacks `Unknown = 0`.
- No DTO collection defaults to `null`.
- No predictable failure requires an exception.
- Public XML documentation is bilingual.
- Architecture, design, and operations navigation is updated.

---

## 9. Related Documents

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- [Canonical Trajectory Governance](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md)
- [CTG Contract Model](../design/CTG_CONTRACT_MODEL-v0.1.1.1.md)
- [XML Documentation Policy](XML_DOCUMENTATION_POLICY-v0.1.1.1.md)
- [Interface Extension Naming Policy](INTERFACE_EXTENSION_NAMING-v0.1.1.1.md)
