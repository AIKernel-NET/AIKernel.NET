---
updated: 2026-06-14
published: 2026-06-14
version: "0.1.1.1"
edition: "Draft"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

英語版: [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1.md)

# CTG ROM Layout v0.1.1.1

この文書は、Monolith CTG-ROM の最小構成に関する repository layout と
layering rule を定義する。Monolith CTG-ROM は、AIKernel の人格 OS における
baseline canon として扱う。

固定された理論参照は Paper 12 である。

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- DOI: https://doi.org/10.5281/zenodo.20681895

この文書は runtime logic を追加しない。canon file、localized personality ROM
descriptor、developer diff layer を分離し、runtime VFS implementation が
deterministic に merge できるようにするための配置規約を説明する。

---

## 1. Directory layout

```text
rom/
  governance/
    ctg.monolith.canon.md
    ctg.monolith.canon.ja.md
    council.logos.monolith.md
    council.logos.monolith.ja.md
    council.ethos.monolith.md
    council.ethos.monolith.ja.md
    council.pathos.monolith.md
    council.pathos.monolith.ja.md
    gate.decision.monolith.md
    gate.decision.monolith.ja.md
    gate.trajectory.monolith.md
    gate.trajectory.monolith.ja.md
    reject.policy.monolith.md
    reject.policy.monolith.ja.md

  locales/
    en-US/
      ctg.monolith.minimal.en.yaml
    ja-JP/
      ctg.monolith.minimal.ja.yaml
```

`rom/governance/` 配下の file は canonical governance asset である。
`rom/locales/<locale>/` 配下の file は、canonical governance asset を参照する
localized personality ROM descriptor である。

英語版 governance file を primary canon とする。日本語版 governance file は、
日本語読者と localization review のための reference canon として扱う。

---

## 2. Layer model

Monolith CTG-ROM は base layer である。開発者は base canon を直接編集せず、
この base の上に diff layer を追加して personalized CTG-ROM を作成する。

| Layer | Location | Responsibility |
| --- | --- | --- |
| Base canon layer | `rom/governance/*.monolith.md` | stable canon、council criteria、gate、reject policy。 |
| Locale personality layer | `rom/locales/<locale>/ctg.monolith.minimal.*.yaml` | locale 固有の personality descriptor と canon path 参照。 |
| Developer diff layer | runtime が定義する overlay source | base canon invariant を維持する personalization delta。 |
| VFS merge layer | runtime VFS mount | mounted Personality-ROM への deterministic merge。 |

Developer diff layer は additive または constraining でなければならない。
metadata、locale wording、operator-facing description、profile preference、
追加 reference などを特化できる。ただし、下記の CTG invariant を削除してはならない。

---

## 3. Base canon invariant

Monolith base から派生する personalized CTG-ROM は、次の invariant を維持する。

- CTG は `Logos`、`Ethos`、`Pathos` による three-council model のまま維持する。
- Ethos rejection または veto は hard denial boundary のまま維持する。
- missing、ambiguous、inconclusive、unknown evidence は fail closed とする。
- decision gate の default behavior は deny のまま維持する。
- trajectory admission は、すべての step-level gate が execution を admit する場合に限る。
- governance trace は replayable かつ auditable のまま維持する。
- canon reference は explicit かつ resolvable でなければならない。

personalization がこれらの invariant を破る必要がある場合、それは Monolith
CTG-ROM の diff layer ではない。別の canon identity と migration documentation
が必要である。

---

## 4. Effective canon path

Monolith minimal locale descriptor は、次の path を通じて canon を解決する。

```text
rom/governance/ctg.monolith.canon.md
```

runtime VFS implementation は、まず選択された locale descriptor を読み込み、
その `canon.path` を base canon layer に対して解決する。対応する日本語 file
`rom/governance/ctg.monolith.canon.ja.md` は日本語 review のための reference
canon であり、primary English canon を暗黙に置き換えてはならない。

---

## 5. Deterministic VFS merge

runtime VFS implementation は、mounted Personality-ROM を次の deterministic
order で構築する。

1. `rom/governance/` から base canon layer を読み込む。
2. `rom/locales/<locale>/` から選択された locale personality descriptor を読み込む。
3. runtime package が定義した安定順序で、0 件以上の developer diff layer を適用する。
4. base canon invariant が維持されていることを検証する。
5. merge 済み Personality-ROM を read-only governance input として mount する。

merge failure、missing canon、unresolved reference、unknown enum value、または
conflicting diff entry は fail closed とし、diagnostics を出力する。

AIKernel.NET はこの merge を実装しない。runtime package が VFS merge logic を所有し、
AIKernel.NET は contract vocabulary と documentation を提供する。

---

## 6. Diff layer rule

Developer diff layer は personalization のために使う。Monolith base 全体を
コピーせず、base との差分だけを記述する。

許可される diff の例:

- operator-facing profile metadata の追加
- locale-specific wording
- conflict しない追加 canon reference
- より厳格な gate または audit requirement
- profile mount に必要な runtime package metadata

禁止される diff の例:

- Ethos veto authority の削除
- fail-closed behavior を fail-open behavior へ変更すること
- `Logos` / `Ethos` / `Pathos` を別の council set に置き換えること
- audit または traceability requirement の弱体化
- ROM contract file に runtime implementation logic を埋め込むこと

---

## 7. Related documents

- [Canonical Trajectory Governance](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md)
- [CTG Contract Model](../design/CTG_CONTRACT_MODEL-v0.1.1.1-jp.md)
- [CTG Developer Guide](CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md)
- [Enum Handling Policy](ENUM_HANDLING_POLICY-v0.1.1.1-jp.md)
