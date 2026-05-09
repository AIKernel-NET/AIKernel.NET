---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "Design Documentation Index"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - design
  - english
---

For Japanese version, see index-jp.md.

# Design Documentation Index

## 1. Purpose
`docs/design` is the decision layer between formal specs and source contracts. It explains how AIKernel behaves as an AIOS through explicit separation of Kernel, Vfs, and system-call-like interface boundaries.

## 2. Design Principles
- Kernel: control point for execution-state transitions and fail-closed governance
- Vfs: persistence boundary for intelligence assets
- System-call equivalent: side-effect control through interfaces (tooling/security/provider)

## 3. Related Specs
- `docs/specs/01.EXECUTION_PIPELINE_SPEC.md`
- `docs/specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC.md`
- `docs/specs/03.ROM_CORE_SPEC.md`

## 4. Documents
- [DESIGN_INTENT.md](DESIGN_INTENT.md)
- [ARCHITECTURE_DECISIONS.md](ARCHITECTURE_DECISIONS.md)
- [DI_GUIDE.md](DI_GUIDE.md)
- [EXTENSION_POINTS.md](EXTENSION_POINTS.md)
- [CONTRACT_VERSIONING.md](CONTRACT_VERSIONING.md)
- [SEMANTIC_SNAPSHOT_FORMAT.md](SEMANTIC_SNAPSHOT_FORMAT.md)

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added AIOS-oriented architecture mapping
