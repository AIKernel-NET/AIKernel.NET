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

For a developer-oriented explanation of the theory-to-contract mapping, read
[CTG Developer Theory](../architecture/21.CTG_DEVELOPER_THEORY-v0.1.1.1.md).

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

## 4. Monolith ROM and Diff Layers

The Monolith CTG-ROM minimal configuration is the baseline canon for the
AIKernel personality OS. Runtime packages should treat the base canon files in
`rom/governance/` as stable governance inputs and the locale descriptors in
`rom/locales/<locale>/` as personality ROM selectors.

Developers personalize CTG-ROM by providing diff layers over the Monolith base.
Diff layers should contain only deltas. They must not copy and mutate the whole
base canon as a replacement profile.

Runtime VFS implementations should merge in this order:

1. base canon layer
2. selected locale personality layer
3. developer diff layers in stable order
4. read-only mounted Personality-ROM

The merge must fail closed when canon is missing, references cannot be resolved,
unknown values are encountered, or a diff layer weakens Monolith base
invariants.

See [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1.md) for the canonical file layout.

---

## 5. Gate Review Checklist

When reviewing a gate-related contract or implementation outside AIKernel.NET,
verify:

- Ethos rejection can close the gate.
- Ethos-veto cases are represented as rejection evidence, not as a fourth
  `CouncilVoteValue`.
- Unknown and missing values close the gate.
- Insufficient evidence closes the gate.
- No confidence or risk weighting changes the decision.
- C# enum numeric values are not used directly as mathematical vote weights.
- `CouncilVoteValue` values are mapped to the finite CTG table before aggregate
  evaluation.
- `DecisionGateRequest` contains one vote-only `GateInput`, not per-council
  `L` / `E` / `P` gate envelopes or a `CouncilDecision` payload.
- The accepted or rejected result is represented by a result DTO.
- Rejection carries `RejectReasonInfo`.
- Canon evidence carries `IReadOnlyList<CanonReference>`.
- Step and trajectory traces are deterministic and ordered.

---

## 6. Diagnostics and Telemetry

Unknown enum handling must be observable. When a consumer sees an unknown enum
value, it should:

1. fail closed
2. record the raw numeric value in diagnostics or metadata
3. emit telemetry when a telemetry surface exists
4. avoid coercing unknown values into known enum members

Use [Enum Handling Policy](ENUM_HANDLING_POLICY-v0.1.1.1.md) as the canonical
policy for this behavior.

---

## 7. Validation Commands

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
0.1.1.1-dev<build-number>
```

---

## 8. Paper Alignment Checklist

For CTG-related changes, verify:

- The change does not edit the published paper package.
- CTG remains a three-council gateway over Logos, Ethos, and Pathos.
- Ethos denial remains a hard execution boundary.
- Execution admission requires a strictly positive mapped aggregate vote when no
  Ethos denial exists.
- Ambiguous, missing, unknown, zero, or negative cases fail closed.
- Trajectory validity is represented as all step-level gates admitting execution.
- CTG-ROM remains a governance/persona contract, not a prompt.
- The Monolith CTG-ROM remains the base layer for personalized diff layers.
- PPM is not treated as the CTG execution gate.
- HATL remains the integrity/provenance layer for state, memory, and replayable
  records.

---

## 9. Pull Request Checklist

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

## 10. Related Documents

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- [Canonical Trajectory Governance](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md)
- [CTG Contract Model](../design/CTG_CONTRACT_MODEL-v0.1.1.1.md)
- [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1.md)
- [XML Documentation Policy](XML_DOCUMENTATION_POLICY-v0.1.1.1.md)
- [Interface Extension Naming Policy](INTERFACE_EXTENSION_NAMING-v0.1.1.1.md)
