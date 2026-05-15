---
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

Japanese version: [Specification Index](specs/index-jp.md)

# Specification Index

## 1. Purpose
`docs/specs` defines AIKernel normative contracts. Implementations must follow each MUST/MUST NOT rule and apply fail-closed behavior when decision paths are indeterminate.

## 2. Spec Family Mapping
- RCS (ROM Core): structure, canonicalization, hash invariance of intelligence assets
- SGS (Signed Prompt Governance): trust chain and non-LLM PDP before execution
- MRS (Model Routing): dynamic selection and replay-time locking behavior
- RDS (Replay Dump): frozen execution context for deterministic replay

## 3. Integration Points
- `RCS` canonical output is consumed by `SGS` signature verification
- `MRS` decisions are frozen by `RDS` as `LockedProviderInfo`
- `SGS` and `RDS` connect pre-execution and post-execution audit chain

## 4. Documents
- [01.EXECUTION_PIPELINE_SPEC.md](01.EXECUTION_PIPELINE_SPEC.md)
- [02.SIGNED_PROMPT_GOVERNANCE_SPEC.md](02.SIGNED_PROMPT_GOVERNANCE_SPEC.md)
- [03.ROM_CORE_SPEC.md](03.ROM_CORE_SPEC.md)
- [04.MODEL_ROUTING_SPEC.md](04.MODEL_ROUTING_SPEC.md)
- [05.MATERIAL_QUARANTINE_SPEC.md](05.MATERIAL_QUARANTINE_SPEC.md)
- [06.REPLAY_DUMP_SPEC.md](06.REPLAY_DUMP_SPEC.md)

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Added explicit RCS/SGS/MRS/RDS cross-mapping
