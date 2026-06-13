---
updated: 2026-06-14
published: 2026-06-14
version: "0.1.1.1"
edition: "Draft"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

Japanese version: [CTG ROM Layout](CTG_ROM_LAYOUT-v0.1.1.1-jp.md)

# CTG ROM Layout v0.1.1.1

This document defines the repository layout and layering rule for the Monolith
CTG-ROM minimal configuration. The Monolith CTG-ROM is treated as the baseline
canon for the AIKernel personality OS.

The fixed theoretical reference remains Paper 12:

- [Paper 12: Canonical Trajectory Governance](../papers/12-canonical-trajectory-governance/README.md)
- DOI: https://doi.org/10.5281/zenodo.20681895

This document does not add runtime logic. It describes how canon files,
localized personality ROM descriptors, and developer diff layers are separated
so that runtime VFS implementations can merge them deterministically.

---

## 1. Directory Layout

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

Files under `rom/governance/` are canonical governance assets. Files under
`rom/locales/<locale>/` are localized personality ROM descriptors that point to
the canonical governance assets.

The English governance files are the primary canon. The Japanese governance
files are reference canon for Japanese readers and localization review.

---

## 2. Layer Model

The Monolith CTG-ROM is the base layer. Developers personalize CTG-ROMs by
adding diff layers on top of this base rather than editing the base canon
directly.

| Layer | Location | Responsibility |
| --- | --- | --- |
| Base canon layer | `rom/governance/*.monolith.md` | Stable canon, council criteria, gates, and reject policy. |
| Locale personality layer | `rom/locales/<locale>/ctg.monolith.minimal.*.yaml` | Locale-specific personality descriptor and references to canon paths. |
| Developer diff layer | Runtime-defined overlay source | Personalization deltas that preserve the base canon invariants. |
| VFS merge layer | Runtime VFS mount | Deterministic merge into the mounted Personality-ROM. |

Developer diff layers must be additive or constraining. They may specialize
metadata, locale wording, operator-facing descriptions, profile preferences, or
additional references. They must not remove the CTG invariants listed below.

---

## 3. Base Canon Invariants

Every personalized CTG-ROM derived from the Monolith base must preserve these
invariants:

- CTG remains a three-council model over `Logos`, `Ethos`, and `Pathos`.
- Ethos rejection or veto remains a hard denial boundary.
- Missing, ambiguous, inconclusive, or unknown evidence fails closed.
- Decision gate default behavior remains deny.
- Trajectory admission requires every step-level gate to admit execution.
- Governance traces remain replayable and auditable.
- Canon references remain explicit and resolvable.

If a personalization needs to violate these invariants, it is not a diff layer
of the Monolith CTG-ROM. It requires a separate canon identity and migration
documentation.

---

## 4. Effective Canon Path

The Monolith minimal locale descriptors resolve their canon through:

```text
rom/governance/ctg.monolith.canon.md
```

Runtime VFS implementations should read the selected locale descriptor first and
then resolve its `canon.path` into the base canon layer. The corresponding
Japanese file, `rom/governance/ctg.monolith.canon.ja.md`, is a reference canon
for Japanese review and should not silently replace the primary English canon.

---

## 5. Deterministic VFS Merge

A runtime VFS implementation should construct the mounted Personality-ROM in a
deterministic order:

1. Load the base canon layer from `rom/governance/`.
2. Load the selected locale personality descriptor from `rom/locales/<locale>/`.
3. Apply zero or more developer diff layers in a stable order defined by the
   runtime package.
4. Validate that base canon invariants remain intact.
5. Mount the merged Personality-ROM as read-only governance input.

Merge failure, missing canon, unresolved references, unknown enum values, or
conflicting diff entries should fail closed and emit diagnostics.

AIKernel.NET does not implement this merge. Runtime packages own the VFS merge
logic while AIKernel.NET provides the contract vocabulary and documentation.

---

## 6. Diff Layer Rules

Developer diff layers are intended for personalization. They should describe
only the delta from the Monolith base and should not copy the full base canon.

Allowed diff examples:

- additional operator-facing profile metadata
- locale-specific wording
- extra non-conflicting canon references
- stricter gate or audit requirements
- runtime package metadata required to mount the profile

Disallowed diff examples:

- removing Ethos veto authority
- changing fail-closed behavior to fail-open behavior
- replacing `Logos` / `Ethos` / `Pathos` with another council set
- weakening audit or traceability requirements
- embedding runtime implementation logic into ROM contract files

---

## 7. Related Documents

- [Canonical Trajectory Governance](../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md)
- [CTG Contract Model](../design/CTG_CONTRACT_MODEL-v0.1.1.1.md)
- [CTG Developer Guide](CTG_DEVELOPER_GUIDE-v0.1.1.1.md)
- [Enum Handling Policy](ENUM_HANDLING_POLICY-v0.1.1.1.md)
