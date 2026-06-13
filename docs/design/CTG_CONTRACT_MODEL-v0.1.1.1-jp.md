---
updated: 2026-06-14
published: 2026-06-14
version: "0.1.1.1"
edition: "Draft"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

英語版: [CTG Contract Model](CTG_CONTRACT_MODEL-v0.1.1.1.md)

# CTG Contract Model v0.1.1.1

この文書は、Canonical Trajectory Governance contract が AIKernel.NET 内で
どのように構成されるかを説明する。contract surface を追加、レビュー、利用する
contributor 向けの design guide であり、runtime implementation は規定しない。

理論参照は Zenodo 公開済み CTG 論文である。

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- DOI: https://doi.org/10.5281/zenodo.20681895

論文は公開後に固定される。AIKernel.NET の documentation と contract はより詳細に
なりうるが、論文の core model と矛盾してはならない。

---

## 1. Package boundary

| Package | Namespace | 許可される内容 |
| --- | --- | --- |
| `AIKernel.Abstractions` | `AIKernel.Abstractions.Governance` | interface のみ |
| `AIKernel.Dtos` | `AIKernel.Dtos.Governance` | DTO record のみ |
| `AIKernel.Enums` | `AIKernel.Enums.Governance` | enum type のみ |

implementation class、algorithm、rule body、provider strategy、runtime engine、
canon text はこれらの package に置かない。

---

## 2. Interface contract

| Interface | 責務 |
| --- | --- |
| `ICouncilEvaluator` | council input を評価し、council decision を返す。 |
| `IDecisionGate` | 単一の deterministic step gate request を評価する。 |
| `ITrajectoryGate` | ordered step governance trace set を評価する。 |
| `IRomGovernanceEngine` | ROM-backed request carrier を通じて governance を評価する。 |

interface は contract signature のみを公開する。非同期 response には
`ValueTask<T>` を使い、`CancellationToken` は最後の parameter に置く。

---

## 3. DTO flow

CTG DTO は replay 可能な flow を構成する。

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

各 DTO は carrier である。DTO は rule logic、derived behavior、side effect を
持ってはならない。

---

## 4. Naming decision

CTG は機械的 suffix ではなく semantic name を使う。

| Concept | Contract name | 理由 |
| --- | --- | --- |
| Council vote carrier | `CouncilVoteValue` | vote enum 名との衝突を避ける。 |
| Rejection detail carrier | `RejectReasonInfo` | structured reason DTO と reason enum value を区別する。 |
| Canon link | `CanonReference` | rule text を埋め込まず、安定した canon identity を運ぶ。 |
| Council triad | `CouncilKind` | `Logos`、`Ethos`、`Pathos` を governance vocabulary として維持する。 |

sideways contract addition に機械的な expansion suffix や version suffix を追加しない。
semantic interface name を使い、どの既存 interface または concept を拡張するかは
document で説明する。

---

## 5. Failure と diagnostics

予測可能な failure は exception ではなく DTO field で表現する。CTG result DTO は
次のような field で failure 情報を公開する。

- `Succeeded`
- `Accepted`
- `Rejected`
- `ErrorCode`
- `ErrorMessage`
- `RejectReasons`
- `Diagnostics`

cancellation は例外的 control path であり、`OperationCanceledException` を利用できる。

unknown enum value は fail-closed である。consumer は diagnostics を出力し、
telemetry が利用できる場合は raw numeric value を metadata に含めた
`unknown_enum_value` event を記録する。

---

## 6. Vote mapping

論文は数学的 vote table を positive、neutral、negative value として表現する。
`CouncilVoteKind` の C# enum value はその weight ではなく、安定した
serialization discriminant である。

runtime implementation は contract value を CTG の有限 table へ map する。

| Contract value | Mathematical role |
| --- | --- |
| `Approve` | positive vote |
| `Abstain` | neutral vote |
| `Reject` | negative vote |
| `Veto` | explicit hard-denial carrier、特に Ethos 向け |
| `Unknown` | fail-closed unknown value |

step gate は論文レベルの invariant に従う。

- Ethos reject または explicit veto は execution を deny する。
- Ethos denial がない場合、map された aggregate council vote が strictly positive
  の場合のみ execution を admit する。
- zero、negative、missing、unknown、inconclusive evidence は execution を deny する。

---

## 7. Optional observation carrier

`Confidence` と `RiskScore` は optional `double?` property である。これらは
trace carrier に限る。

許可される用途:

- council evaluation 中に観測された measurement を保存する
- runtime host が使った evidence を正確に replay する
- operator 向け diagnostics を公開する

禁止される用途:

- council vote に weight を付ける
- `gate(l,e,p)` behavior を変更する
- deterministic governance を probabilistic scoring に変える

---

## 8. Canon reference shape

canon evidence を運ぶ DTO は、次の collection を優先する。

```csharp
IReadOnlyList<CanonReference>
```

これにより、DTO shape を後で変更せずに複数 canon anchor を保持できる。canon
reference が欠落または解決不能な場合、runtime implementation は fail-closed として扱う。

---

## 9. Paper alignment notes

論文は trace object について簡略化した C# sketch を使っている。現在の実装は、
次の audit invariant を守る限り、より詳細な DTO を利用してよい。

- 各 council vote は reason code と canon reference で説明可能である。
- 各 gate result は replay 可能である。
- 各 trajectory result は ordered step trace を保持する。
- CTG-ROM は immutable governance/persona contract concept として維持する。
- CTG は PPM および HATL から分離する。

PPM は prime-phase research line の公開用語である。古い shorthand を formal
theory name として新規 documentation に導入しない。

---

## 10. Review checklist

- 変更は追加型であり、既存 public signature を変更しない。
- 新規 interface は `AIKernel.Abstractions.Governance` のみに置く。
- 新規 DTO は `AIKernel.Dtos.Governance` のみに置く。
- 新規 enum は `AIKernel.Enums.Governance` のみに置く。
- public API XML documentation はすべて bilingual である。
- すべての enum は `Unknown = 0` を持つ。
- result DTO は予測可能な failure を exception なしで運ぶ。
- canon rule text を AIKernel.NET に追加しない。
- runtime behavior を AIKernel.NET に追加しない。
- C# enum numeric value を CTG vote weight として扱わない。
- CTG theory を説明する新規 documentation は Paper 12 へリンクする。

---

## 11. 関連文書

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- [Canonical Trajectory Governance](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md)
- [CTG Developer Guide](../operations/CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md)
- [Domain Contract Surface v0.1.1.1](../architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1-jp.md)
