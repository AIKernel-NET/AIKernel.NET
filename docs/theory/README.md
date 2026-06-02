---
title: "AIKernel Theory — Research in Progress"
subtitle: "Current Focus, Active Investigations, and Future Directions"
id: aikernel-theory-en
slug: theory-en
version: "0.1.0"
status: "Work-in-Progress"
issuer: "ai-kernel@aikernel.net"
maintainer: "Takuya (AIKernel Project Maintainer)"
published: 2026-05-17
updated: 2026-05-17
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

## 🎯 Active Focus

- Preparing the implementation of the Pre-Inference Admissibility Governance  
- Designing the C# interfaces for the Critical Operation Gate  
- Investigating NPU-oriented optimization for the Complexity Gate  
- Structuring the unified Phase‑1 paper (Pre-Inference + Post-Inference Governance)  
- Implementing the AIKernel.NET PreInferencePipeline  
- Refining Intent classification (Unknown / Explanation / Plan / Execution)  
- Adjusting the Fail-Closed decision priority model  

---

## 📘 Research Notes

- Translating LLM computational limits (Sikka 2025) into OS-style admission control  
- Integrating the two-stage governance model (Pre-Inference + Trajectory Governance)  
- Designing high-speed filtering mechanisms assuming NPU availability  
- Ensuring deterministic replayability in ReplayLog  
- Evaluating the scope of Capability-based Delegation  

---

## 🧩 Completed Work (Moved to Papers)

- **02_preinference_admissibility/**  
  → Pre-Inference Admissibility Governance (Paper #2, DOI pending)

- **01_trajectory_governance/**  
  → Trajectory Governance (Paper #1, Post-Inference Governance)

---

## 🚀 Next Milestones

- Complete the Phase‑1 implementation of AIKernel.NET  
- Write the **Phase‑1 Unified Paper**, citing Paper #1 and Paper #2  
- Publish on Zenodo / arXiv with DOI  
- Begin designing the NPU optimization layer (AIKernel.NPU)  
- Extend Phase‑2 (dynamic control after LLM invocation)  

---

## 📝 Purpose of This Directory

- Capture the current state of research  
- Store ideas before they become formal specifications  
- Move completed work to papers/specs  
- Declare the next research objectives  
- Provide transparency into the evolution of AIKernel  

This directory functions as the **research log** of the AIKernel project.
