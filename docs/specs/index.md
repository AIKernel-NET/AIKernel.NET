---
version: 0.0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Specs — Index"
created: 2026-05-04
updated: 2026-05-04
tags:
  - aikernel
  - specs
  - index
  - english
---

# docs/specs — Index (What / Contract)

This directory defines executable spec sheets used directly for implementation and verification in AIKernel.

## Overview
- `01.EXECUTION_PIPELINE_SPEC`: Defines phase boundaries, immutability, and hash chaining for `Structure -> Generation -> Polish`.
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC`: Defines fail-closed signature verification, trust-chain validation, and dynamic scope binding.
- `03.ROM_CORE_SPEC`: Defines ROM minimum grammar, canonicalization, relation syntax, and integrity verification.
- `04.MODEL_ROUTING_SPEC`: Defines capability-vector routing with dynamic constraints and hardware-aware adaptation.
- `05.MATERIAL_QUARANTINE_SPEC`: Defines quarantine workflow, TrustVector scoring, and recursive re-ingestion guards.
- `06.REPLAY_DUMP_SPEC`: Defines replay dump structure, environment consistency checks, and audit certification.

## Documents
1. 01.EXECUTION_PIPELINE_SPEC.md — execution contract for Structure/Generation/Polish
2. 02.SIGNED_PROMPT_GOVERNANCE_SPEC.md — signed governance and fail-closed verification contract
3. 03.ROM_CORE_SPEC.md — minimum grammar and validation rules for Relation-Oriented Markdown (ROM)
4. 04.MODEL_ROUTING_SPEC.md — routing contract for `IModelVectorRouter` and capacity vectors
5. 05.MATERIAL_QUARANTINE_SPEC.md — material quarantine contract for `IMaterialQuarantine`
6. 06.REPLAY_DUMP_SPEC.md — deterministic replay dump contract

## Recommended reading order
1. EXECUTION_PIPELINE_SPEC
2. SIGNED_PROMPT_GOVERNANCE_SPEC
3. ROM_CORE_SPEC
4. MODEL_ROUTING_SPEC
5. MATERIAL_QUARANTINE_SPEC
6. REPLAY_DUMP_SPEC
