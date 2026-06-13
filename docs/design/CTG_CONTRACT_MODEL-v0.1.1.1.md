---
updated: 2026-06-14
published: 2026-06-14
version: "0.1.1.1"
edition: "Draft"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

Japanese version: [CTG Contract Model](CTG_CONTRACT_MODEL-v0.1.1.1-jp.md)

# CTG Contract Model v0.1.1.1

This document describes how Canonical Trajectory Governance contracts are shaped
inside AIKernel.NET. It is a design guide for contributors who add, review, or
consume the contract surface. It does not prescribe runtime implementation.

The theoretical reference is the Zenodo-published CTG paper:

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- DOI: https://doi.org/10.5281/zenodo.20681895

The paper is fixed after publication. AIKernel.NET documentation and contracts
may become more detailed, but they must not contradict the paper's core model.

---

## 1. Package Boundaries

| Package | Namespace | Allowed contents |
| --- | --- | --- |
| `AIKernel.Abstractions` | `AIKernel.Abstractions.Governance` | interfaces only |
| `AIKernel.Dtos` | `AIKernel.Dtos.Governance` | DTO records only |
| `AIKernel.Enums` | `AIKernel.Enums.Governance` | enum types only |

No implementation class, algorithm, rule body, provider strategy, runtime engine,
or canon text belongs in these packages.

---

## 2. Interface Contracts

| Interface | Responsibility |
| --- | --- |
| `ICouncilEvaluator` | Evaluates council input and returns council decisions. |
| `IDecisionGate` | Evaluates one deterministic step gate request. |
| `ITrajectoryGate` | Evaluates an ordered set of step governance traces. |
| `IRomGovernanceEngine` | Evaluates governance through a ROM-backed request carrier. |

Interfaces expose contract signatures only. They must use `ValueTask<T>` for
asynchronous responses and must place `CancellationToken` as the final parameter.

---

## 3. DTO Flow

CTG DTOs form a replayable flow:

```text
RomGovernanceEvaluationRequest
  -> CouncilEvaluationRequest
  -> CouncilEvaluationResult
  -> CouncilDecision
  -> CouncilVoteValue
  -> DecisionGateRequest
  -> DecisionGateResult
  -> StepGovernanceTrace
  -> TrajectoryGateRequest
  -> TrajectoryGateResult
  -> GovernanceTrace
```

Each DTO is a carrier. The DTOs must not contain rule logic, derived behavior,
or side effects.

---

## 4. Naming Decisions

CTG uses semantic names rather than mechanical suffixes.

| Concept | Contract name | Reason |
| --- | --- | --- |
| Council vote carrier | `CouncilVoteValue` | Avoids collision with vote enum names. |
| Rejection detail carrier | `RejectReasonInfo` | Distinguishes structured reason DTOs from reason enum values. |
| Canon link | `CanonReference` | Carries stable canon identity without embedding rule text. |
| Council triad | `CouncilKind` | Preserves `Logos`, `Ethos`, and `Pathos` as the governance vocabulary. |

Do not add mechanical expansion suffixes or version suffixes for sideways
contract additions. Use a semantic interface name and document which earlier
interface or concept it expands.

---

## 5. Failure and Diagnostics

Predictable failures are represented by DTO fields, not exceptions. CTG result
DTOs expose failure information through fields such as:

- `Succeeded`
- `Accepted`
- `Rejected`
- `ErrorCode`
- `ErrorMessage`
- `RejectReasons`
- `Diagnostics`

Cancellation is the exceptional control path and may use
`OperationCanceledException`.

Unknown enum values are fail-closed. Consumers should emit diagnostics and, when
telemetry is available, record an `unknown_enum_value` event with the raw numeric
value in metadata.

---

## 6. Vote Mapping

The paper expresses the mathematical vote table as positive, neutral, and
negative values. The C# enum values in `CouncilVoteKind` are not those weights;
they are stable serialization discriminants.

Runtime implementations should map contract values to the finite CTG table:

| Contract value | Mathematical role |
| --- | --- |
| `Approve` | positive vote |
| `Abstain` | neutral vote |
| `Reject` | negative vote |
| `Veto` | explicit hard-denial carrier, especially for Ethos |
| `Unknown` | fail-closed unknown value |

The step gate follows the paper-level invariant:

- Ethos reject or explicit veto denies execution.
- Without Ethos denial, execution is admitted only when the mapped aggregate
  council vote is strictly positive.
- Zero, negative, missing, unknown, or inconclusive evidence denies execution.

---

## 7. Optional Observation Carriers

`Confidence` and `RiskScore` are optional `double?` properties. They are trace
carriers only.

Allowed use:

- preserve a measurement observed during council evaluation
- replay the exact evidence used by a runtime host
- expose diagnostics for operators

Disallowed use:

- weighting council votes
- changing `gate(l,e,p)` behavior
- turning deterministic governance into probabilistic scoring

---

## 8. Canon Reference Shape

Any DTO that carries canon evidence should prefer a collection:

```csharp
IReadOnlyList<CanonReference>
```

This preserves multiple canon anchors without changing DTO shape later. A
missing or unresolved canon reference should be treated as fail-closed by the
runtime implementation.

---

## 9. Paper Alignment Notes

The paper intentionally uses simplified C# sketches for trace objects. The
current implementation may use more detailed DTOs as long as the audit invariant
is preserved:

- each council vote is explainable by reason code and canon reference
- each gate result is replayable
- each trajectory result preserves the ordered step trace
- CTG-ROM remains an immutable governance/persona contract concept
- CTG remains separate from PPM and HATL

PPM is the publication term for the prime-phase research line. Do not introduce
the older shorthand as a formal theory name in new documentation.

---

## 10. Review Checklist

- The change is additive and does not alter existing public signatures.
- New interfaces are placed only under `AIKernel.Abstractions.Governance`.
- New DTOs are placed only under `AIKernel.Dtos.Governance`.
- New enums are placed only under `AIKernel.Enums.Governance`.
- All public API XML documentation is bilingual.
- All enums include `Unknown = 0`.
- Result DTOs carry predictable failures without requiring exceptions.
- Canon rule text is not added to AIKernel.NET.
- Runtime behavior is not added to AIKernel.NET.
- C# enum numeric values are not treated as CTG vote weights.
- New CTG documentation links back to Paper 12 when it explains theory.

---

## 11. Related Documents

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- [Canonical Trajectory Governance](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md)
- [CTG Developer Guide](../operations/CTG_DEVELOPER_GUIDE-v0.1.1.1.md)
- [Domain Contract Surface v0.1.1.1](../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1.md)
