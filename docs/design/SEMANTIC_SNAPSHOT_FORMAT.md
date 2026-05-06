---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "Semantic Snapshot Markdown Format"
description: Canonical Markdown format for AIKernel semantic memory snapshots
lang: en
last_updated: 2026-05-04
updated: 2026-05-06
owners:
  - AIKernel Architecture Team
tags:
  - aikernel
  - design
  - snapshot
  - markdown
  - english
---

For Japanese version, see `SEMANTIC_SNAPSHOT_FORMAT-jp.md`.

# Purpose
Define a canonical Markdown format for **Semantic Snapshot** records used by AIKernel to preserve intermediate reasoning state with governance metadata.

# Scope
This document defines:
- required snapshot sections
- metadata keys
- section semantics
- format constraints for reproducibility and auditability
- responsibility boundary with ROM (format shell vs semantic content model)

# Specification / Procedure

## 1. Snapshot document structure
All semantic snapshots must follow this top-level order:
1. Snapshot Metadata
2. Orchestration
3. Material Quarantine
4. Thought Process
5. Expression Buffer

## 2. Snapshot Metadata block
Use a front block with explicit key-value lines:

```md
---
# [Snapshot Metadata]
Timestamp: 2026-05-03T00:50:00Z
KernelVersion: v0.0.7
Router: IModelVectorRouter (Type: LogicHeavy)
PromptSignature: "sha256:7f8e9a..."
---
```

### Required fields
- `Timestamp`: UTC ISO 8601 timestamp
- `KernelVersion`: executed kernel contract version
- `Router`: selected routing abstraction and profile
- `PromptSignature`: verified signature digest for fail-closed governance

### Optional fields
- `SnapshotId`
- `ParentSnapshotId`
- `ProviderSet`
- `MaterialHash`
- `ExpressionHash`

## 3. Orchestration section
Must summarize only signed execution policy and constraints.

```md
# 1. Orchestration
> Signed prompt summary and execution constraints
```

Constraints:
- Keep policy-focused and concise.
- Do not include raw external material.
- Do not include generated final output artifacts.

## 4. Material Quarantine section
Must list only verified or sanitized material items.

```md
# 2. Material Quarantine
- [Source A]: Verified and Structured
- [Source B]: Sanitized
```

Constraints:
- Material status must be explicit.
- Unverified material must not be promoted into reasoning state.

## 5. Thought Process section
Must record phase-oriented reasoning progression as structured checkpoints.

```md
# 3. Thought Process
## Phase: Task Decomposition
1. [x] Decomposition Task A
2. [ ] Decomposition Task B (In Progress)
```

Constraints:
- Use phase headers for replay readability.
- Progress markers should remain deterministic and diff-friendly.

## 6. Expression Buffer section
Must isolate generated artifacts from reasoning and material layers.

````md
# 4. Expression Buffer
```cpp
// Generated code
```
````

Constraints:
- Expression content must not be implicitly reclassified as material.
- Any promotion from expression to material requires explicit governance action.

## 7. Governance rules
- Snapshots are append-only records in Git history.
- Signature verification is an execution precondition.
- Unsigned or invalidly signed snapshots are non-executable in orchestration.

## 8. Validation checklist
- [ ] Required metadata keys present
- [ ] Section ordering is valid
- [ ] Material status is explicit
- [ ] Thought process phases are structured
- [ ] Expression is isolated
- [ ] Prompt signature is present and verified

## 9. Relationship with ROM (Relation-Oriented Markdown)
This specification defines the snapshot container; ROM defines semantic structure inside the container.

- `SEMANTIC_SNAPSHOT_FORMAT`: guarantees section ordering, governance metadata, and verifiability.
- `ROM`: guarantees relational expression through `YAML`, `Headings`, `Bullets`, and `[[id]]`.

Operational rules:
- Body content in `Material Quarantine` and `Thought Process` may follow ROM.
- Snapshot top-level ordering (1..5) is governed by this specification.
- Non-ROM fragments should be treated as lower-trust even when quarantined.

## 10. Canonicalization and Semantic Hash Rules
To stabilize signatures and diff behavior, normalize the following before hashing.

- Heading numbering variance (`# 1. ...` vs `# ...`) is treated as equivalent.
- Bullet ordering can be order-insensitive when semantics are commutative.
- `[[id]]` links are compared as resolved identifier sets.
- Whitespace/newline/indentation formatting noise is ignored in hash inputs.

Fail-Closed:
- If normalized content does not match `PromptSignature`, execution is denied.
- If unresolved links (orphan IDs) exist in mandatory references, execution is halted.

# References
- ../architecture/16.SEMANTIC_CONTEXT_OS_VISION.md
- ../architecture/2.CONTEXT_ISOLATION_SPEC.md
- ../architecture/3.ATTENTION_POLLUTION_THEORY.md
- ../architecture/11.MATERIAL_QUARANTINE_TRUST_MODEL.md
- DESIGN_INTENT.md

# Changelog
- 2026-05-03 v0.0.0 Initial draft

# Owners
- AIKernel Architecture Team
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines

