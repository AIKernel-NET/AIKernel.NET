# Interface Extension Naming Policy for v0.1.1.1

AIKernel.NET v0.1.1.1 extends the public contract surface through additive
interfaces, DTOs, and enums while preserving existing public API signatures.

Mechanical expansion suffixes must not be used for new interface names. New
interfaces must be named by the semantic role they provide, not by the fact that
they expand an older interface. The inheritance relationship is documented here
and in architecture documents instead of being encoded mechanically in the type
name.

---

## Core Runtime Expansion Names

| Contract role | v0.1.1.1 name | Inherits |
|---|---|---|
| Kernel provider capability expansion | `IKernelProvider` | `IProvider` |
| Capability routing expansion | `ICapabilityProviderRouter` | `IProviderRouter` |
| Action policy expansion | `IActionGovernancePolicy` | `IPolicy` |
| Governance decision expansion | `IGovernanceDecisionProvider` | `IPdp` |
| Decomposed input expansion | `IDecomposedInputProvider` | `IVirtualInputProvider` |
| Operator action expansion | `IActionOperatorProvider` | `IActionProposalProvider`, `IActionArbiterProvider` |
| Diagnostic frame perception expansion | `IDiagnosticFramePerceptionProvider` | `IFramePerceptionProvider` |

---

## Domain Expansion Names

| Contract role | Implemented name |
|---|---|
| Provider adapter binding | `IProviderAdapter` |
| Runtime adapter binding | `IRuntimeAdapter` |
| Sandbox runtime control | `ISandboxRuntimeControlProvider` |
| Process control | `IProcessControlProvider` |
| Evidence collection | `IEvidenceCollector` |
| Diagnostics collection | `IDiagnosticsProvider` |
| Profile storage | `IProfileStoreProvider` |
| Telemetry sampling | `ITelemetryProvider` |
| Metrics sampling | `IMetricsProvider` |

---

## Governance Contract Names

Canonical triadic governance uses semantic contract names that describe the
role of each contract directly.

| Contract name | Role |
|---|---|
| `ICouncilEvaluator` | Evaluates council votes and produces a council decision carrier. |
| `IDecisionGate` | Evaluates the boolean gate input tuple for a single step. |
| `ITrajectoryGate` | Evaluates a trajectory-level governance result carrier. |
| `IRomGovernanceEngine` | Loads governance context from ROM-facing inputs and returns governance result carriers. |

DTO names avoid ambiguous overlap between carrier records and enum types:
`CouncilVoteValue` carries a vote, `CouncilVoteKind` names the vote kind,
`RejectReasonInfo` carries rejection details, and `RejectReasonKind` names the
reason category.

---

## Rules

- Use semantic domain names such as Provider, Adapter, Runtime, Operator,
  Replay, Observability, Diagnostics, Telemetry, Metrics, Profiles, and
  Perception.
- Do not replace or rename existing public interfaces when adding new behavior.
- Add new interfaces next to the existing API and make adoption opt-in.
- If a new interface inherits multiple interfaces, document the composition in
  docs instead of encoding it as a mechanically extended name.
- Avoid version-like interface names unless a breaking-change migration requires
  a side-by-side versioned contract.

This keeps the package boundary stable while avoiding future debt from
mechanical type names.
