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

[日本語](CTG_ROM_LAYOUT-v0.1.2-jp.md)

This document defines the canonical CTG-ROM layout for the v0.1.2 package
series. The Monolith CTG-ROM content is promoted from the rc5 validation line to
the v0.1.2 canon without changing its semantic rules, council duties, gate
rules, or reject policy taxonomy.

## Version Alignment

The v0.1.2 update changes only package-facing metadata:

- `Version: 0.1.2` in governance Markdown files
- `version: "0.1.2"` in locale YAML files
- `canonVersion: "0.1.2"` in locale YAML files
- `schemaVersion: "0.1.2"` in locale YAML files

The canonical wording, rule text, council boundaries, gate functions, and
reject reason semantics remain unchanged.

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

The Monolith CTG-ROM is the base layer. Developers personalize CTG-ROM by
adding diff layers over this base. Do not edit the base canon to create a
personalized ROM.

Personalized layers must preserve:

- Canon / Council / Gate / RejectPolicy separation
- Logos / Ethos / Pathos council boundaries
- vote-only Decision Gate input
- fail-closed handling for unknown values
- deterministic replay and traceability

## Python Sample Packaging

The `aikernel-net` Python package includes the same CTG-ROM tree under
`aikernel_net.samples.ctg_rom` for examples and validation. Package users can
discover it through:

- `ctg_rom_sample_path()`
- `ctg_rom_sample_files()`

The Python sample is a packaged carrier of the canonical files. It must stay in
sync with `AIKernel.NET/rom`.

## Change Control

Changes to ROM semantics require a new canon review. Metadata-only version
alignment for package publication is allowed when the content has already been
validated and the maintainer explicitly promotes it to the release canon.
