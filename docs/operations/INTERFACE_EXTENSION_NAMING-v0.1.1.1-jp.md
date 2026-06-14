# Interface Extension Naming Policy for v0.1.1.1

AIKernel.NET v0.1.1.1 では、既存 public API signature を維持したまま、
横追加の interface、DTO、enum によって public contract surface を拡張する。

新しい interface 名に機械的な expansion suffix は使わない。追加 interface は、
古い interface を拡張した事実ではなく、提供する意味論的な役割で命名する。
継承関係は type name に機械的に埋め込まず、本書および architecture document で説明する。

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

設計ドラフト上の機械的な仮称は正典には残さず、実装済みの semantic name のみを採用する。

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

Canonical triadic governance では、各 contract の役割を直接表す semantic name を使う。

| Contract name | Role |
|---|---|
| `ICouncilEvaluator` | council vote を評価し、council decision carrier を返す。 |
| `IDecisionGate` | 単一 step の boolean gate input tuple を評価する。 |
| `ITrajectoryGate` | trajectory-level governance result carrier を評価する。 |
| `IRomGovernanceEngine` | ROM-facing input から governance context を読み、governance result carrier を返す。 |

DTO 名は carrier record と enum type の曖昧な重複を避ける。
DTO と enum は carrier record と finite value の重複を避ける。
`CouncilVote` は council vote carrier、`CouncilVoteValue` は finite vote value、
`RejectReasonInfo` は reject detail carrier、`RejectReasonKind` は reason category を表す。

---

## Rules

- Provider、Adapter、Runtime、Operator、Replay、Observability、Diagnostics、
  Telemetry、Metrics、Profiles、Perception などの semantic domain 名を使う。
- 新しい振る舞いを追加するために、既存 public interface を置換・rename しない。
- 新規 interface は既存 API の横に追加し、採用を opt-in にする。
- 複数 interface を継承する場合も、機械的な suffix ではなく docs で合成関係を説明する。
- 破壊的変更の移行で side-by-side versioned contract が必要な場合を除き、version-like interface 名を避ける。

これにより package boundary を安定させつつ、機械的な type name による将来負債を避ける。
