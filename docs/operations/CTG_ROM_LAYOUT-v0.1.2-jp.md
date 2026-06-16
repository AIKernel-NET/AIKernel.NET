---
updated: 2026-06-16
published: 2026-06-16
version: "0.1.2"
edition: "Draft"
status: "Development"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# CTG ROM Layout v0.1.2

[English](CTG_ROM_LAYOUT-v0.1.2.md)

この文書は、v0.1.2 package series における canonical CTG-ROM layout を定義します。
Monolith CTG-ROM content は、rc5 validation line から v0.1.2 canon へ昇格しますが、
semantic rule、council duties、gate rules、reject policy taxonomy は変更しません。

## Version Alignment

v0.1.2 update では、package-facing metadata だけを変更します。

- governance Markdown file の `Version: 0.1.2`
- locale YAML file の `version: "0.1.2"`
- locale YAML file の `canonVersion: "0.1.2"`
- locale YAML file の `schemaVersion: "0.1.2"`

canonical wording、rule text、council boundary、gate function、reject reason
semantics は変更しません。

## Directory Layout

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

## Layering Rule

Monolith CTG-ROM は base layer です。開発者はこの base の上に diff layer を追加して
personalized CTG-ROM を作成します。personalized ROM を作成するために base canon を
直接編集してはいけません。

Personalized layer は次を維持します。

- Canon / Council / Gate / RejectPolicy separation
- Logos / Ethos / Pathos council boundaries
- vote-only Decision Gate input
- unknown value の fail-closed handling
- deterministic replay and traceability

## Python Sample Packaging

`aikernel-net` Python package は、example と validation 向けに同じ CTG-ROM tree を
`aikernel_net.samples.ctg_rom` 配下へ同梱します。package user は次の helper で
発見できます。

- `ctg_rom_sample_path()`
- `ctg_rom_sample_files()`

Python sample は canonical files の packaged carrier です。`AIKernel.NET/rom` と同期して
維持します。

## Change Control

ROM semantics の変更には新しい canon review が必要です。package publication のための
metadata-only version alignment は、内容がすでに検証済みで、maintainer が release canon
への昇格を明示した場合だけ許可します。
