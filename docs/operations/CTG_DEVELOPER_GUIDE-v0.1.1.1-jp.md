---
updated: 2026-06-14
published: 2026-06-14
version: "0.1.1.1"
edition: "Draft"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

英語版: [CTG Developer Guide](CTG_DEVELOPER_GUIDE-v0.1.1.1.md)

# CTG Developer Guide v0.1.1.1

この guide は、Canonical Trajectory Governance contract を追加、レビュー、利用する
ための runbook である。開発者向け文書であり、canon rule text は追加しない。

固定された理論参照は Paper 12 である。

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- DOI: https://doi.org/10.5281/zenodo.20681895

論文は Zenodo 公開済みであり、後続の実装詳細に合わせて修正してはならない。
実装 contract は論文より詳細であってよいが、論文の invariant を保つ必要がある。

---

## 1. Contract-only rule

AIKernel.NET が受け入れる CTG 要素は contract layer のみである。

- `AIKernel.Abstractions.Governance` の interface
- `AIKernel.Dtos.Governance` の record
- `AIKernel.Enums.Governance` の enum
- public API の bilingual XML documentation

runtime engine、provider strategy、rule interpreter、canon body text、
file-system reader をこの repository に追加してはならない。

---

## 2. CTG contract を追加する手順

type を追加する前に、その concept が安定した contract concept であり、
runtime behavior ではないことを確認する。

手順:

1. 閉じた語彙が必要な場合は enum を先に追加する。
2. immutable record shape と初期化済み collection を持つ DTO carrier を追加する。
3. request / response DTO が安定してから interface signature のみを追加する。
4. すべての public type / member に bilingual XML documentation を付与する。
5. public vocabulary を変える contract の場合は architecture、design、operations docs を更新する。

既存 public interface signature は変更しない。

---

## 3. Runtime implementation guidance

CTG contract を実装する runtime host は次の規則に従う。

- canon が欠落した場合は fail-closed とする
- unknown enum value は fail-closed とする
- unknown enum の raw value を diagnostics または metadata に保持する
- `CanonReference` を伝搬し、canon text を創作しない
- gate result と trajectory result に `RejectReasonInfo` を保持する
- replay のために `StepGovernanceTrace` と `GovernanceTrace` を埋める
- `Confidence` と `RiskScore` は observation data としてのみ使う
- routine exception path は cancellation のみにする

runtime package は algorithm execution を所有する。AIKernel.NET は共有 contract
vocabulary のみを所有する。

---

## 4. Monolith ROM と diff layer

Monolith CTG-ROM の最小構成は、AIKernel personality OS の baseline canon である。
runtime package は、`rom/governance/` の base canon file を stable governance
input として扱い、`rom/locales/<locale>/` の locale descriptor を personality ROM
selector として扱う。

開発者は Monolith base の上に diff layer を提供することで CTG-ROM を
personalize する。diff layer は差分のみを含めるべきであり、base canon 全体を
コピーして変更した replacement profile として扱ってはならない。

runtime VFS implementation は次の順序で merge する。

1. base canon layer
2. selected locale personality layer
3. developer diff layer（安定順序）
4. read-only mounted Personality-ROM

canon が欠落した場合、reference を解決できない場合、unknown value を検出した場合、
または diff layer が Monolith base invariant を弱める場合、merge は fail closed
しなければならない。

canonical file layout は [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1-jp.md) を参照する。

---

## 5. Gate review checklist

AIKernel.NET の外で gate 関連 contract または implementation を review する場合、
次を確認する。

- Ethos reject または explicit veto が gate を閉じられる。
- unknown / missing value が gate を閉じる。
- inconclusive evidence が gate を閉じる。
- confidence または risk weighting が decision を変更していない。
- C# enum numeric value を数学的 vote weight として直接使っていない。
- contract vote value を aggregate evaluation 前に有限 CTG table へ map している。
- accept / reject result が result DTO で表現されている。
- rejection が `RejectReasonInfo` を保持している。
- canon evidence が `IReadOnlyList<CanonReference>` を保持している。
- step trace と trajectory trace が deterministic かつ ordered である。

---

## 6. Diagnostics と telemetry

unknown enum handling は observable でなければならない。consumer が unknown enum
value を見た場合、次を行う。

1. fail closed する
2. raw numeric value を diagnostics または metadata に記録する
3. telemetry surface が存在する場合は telemetry を出力する
4. unknown value を既知 enum member に丸めない

この behavior の正典 policy は
[Enum Handling Policy](ENUM_HANDLING_POLICY-v0.1.1.1-jp.md) を参照する。

---

## 7. Validation command

CTG contract change を公開する前に次を実行する。

```powershell
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
dotnet pack src\AIKernel.NET.slnx -c Release
```

local development package の場合:

```powershell
dotnet pack src\AIKernel.NET.slnx -c Release -p:UseLocalPackageVersion=true -p:LocalPackageBuildNumber=<build-number>
```

local package version format は次の通り。

```text
0.1.1-dev<build-number>
```

---

## 8. Paper alignment checklist

CTG 関連の変更では次を確認する。

- 公開済み paper package を編集していない。
- CTG が Logos、Ethos、Pathos による three-council gateway のままである。
- Ethos denial が hard execution boundary のままである。
- Ethos denial がない場合、mapped aggregate vote が strictly positive のときだけ
  execution を admit する。
- ambiguous、missing、unknown、zero、negative case は fail closed する。
- trajectory validity は、すべての step-level gate が execution を admit することとして表現する。
- CTG-ROM は prompt ではなく governance/persona contract である。
- Monolith CTG-ROM は personalized diff layer の base layer として維持する。
- PPM を CTG execution gate として扱っていない。
- HATL は state、memory、replayable record の integrity/provenance layer として残っている。

---

## 9. Pull request checklist

- 既存 public interface signature を変更していない。
- implementation class を追加していない。
- canon rule body を追加していない。
- 機械的な expansion suffix を導入していない。
- `Unknown = 0` を持たない enum を追加していない。
- DTO collection が `null` default になっていない。
- 予測可能な failure に exception を要求していない。
- public XML documentation が bilingual である。
- architecture、design、operations navigation を更新している。

---

## 10. 関連文書

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- [Canonical Trajectory Governance](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md)
- [CTG Contract Model](../design/CTG_CONTRACT_MODEL-v0.1.1.1-jp.md)
- [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1-jp.md)
- [XML Documentation Policy](XML_DOCUMENTATION_POLICY-v0.1.1.1-jp.md)
- [Interface Extension Naming Policy](INTERFACE_EXTENSION_NAMING-v0.1.1.1-jp.md)
