---
title: "AIKernel Theory — Research in Progress"
subtitle: "Current Focus, Active Investigations, and Future Directions"
id: aikernel-theory-en
slug: theory-en
version: "0.1.1"
status: "Work-in-Progress"
issuer: "ai-kernel@aikernel.net"
maintainer: "Takuya (AIKernel Project Maintainer)"
published: 2026-05-17
updated: 2026-06-05
rom: false
tags:
  - AIKernel
  - Governance
  - Pre-Inference
  - Trajectory
  - Complexity
  - Research
summary: >
  This directory documents the active research focus, ongoing investigations,
  and future directions of the AIKernel project. All content here is
  Work-in-Progress and will be moved to docs/papers/ or docs/specs/ once finalized.
---

# AIKernel Theory — Research in Progress

This directory serves as the **current research frontier** of the AIKernel project.  
The content here represents ideas, hypotheses, and design considerations that are  
still evolving and have not yet been finalized as formal specifications or papers.

Completed work will be moved to:

- `docs/papers/` — Formal papers and specifications (DOI-ready)
- `docs/specs/` — Implementation specifications
- `src/AIKernel.*` — Actual implementation

---

## Active Focus

- Maintaining the formal paper series under `docs/papers/` as the canonical research publication surface.
- Aligning package-public contracts with the published AIKernel papers.
- Refining Semantic DSL, ReplayLog, History ROM, and Capability ROM execution models.
- Preparing model-runtime research around DynamicSLM and capability-modular small language models.
- Keeping work-in-progress notes separate from DOI-backed papers and implementation specifications.

---

## Research Notes

- New ideas stay in this directory until they are stable enough to become a formal paper, implementation spec, or source-level contract.
- DOI-backed papers are indexed in `docs/papers/README.md`.
- Implementation-facing specifications are indexed in `docs/specs/`.
- Architecture and interface documentation are indexed in `docs/architecture/`.

---

## Completed Work (Moved to Papers)

The current formal paper series is maintained in `docs/papers/` and includes:

- Phase-1 theoretical foundation papers `01` through `04`.
- Phase-1.1 implementation-layer papers `05` through `08`.
- Phase-3 Foundation paper `09` for the Hash-Anchored Trust Layer.
- Agent execution and model-runtime papers `10` and `11` for the Semantic DSL Compiler and DynamicSLM.

---

## Next Milestones

- Keep `docs/papers/README.md` synchronized whenever a DOI-backed paper is added.
- Keep package migration guides synchronized with contract-surface changes.
- Expand implementation specs for DSL ROM, History ROM, Semantic DSL execution, and capability-modular model runtime.
- Move mature theory notes into `docs/papers/` or `docs/specs/` instead of leaving stale WIP copies.

---

## Purpose of This Directory

- Capture the current state of research  
- Store ideas before they become formal specifications  
- Move completed work to papers/specs  
- Declare the next research objectives  
- Provide transparency into the evolution of AIKernel  

This directory functions as the **research log** of the AIKernel project.
