---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "governance Interfaces"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see index-jp.md.

# governance Interfaces

## 1. Responsibility Boundary
Governance covers execution authorization, auditability, and attention-quality supervision. `IAttentionGuard` and `IAttentionObserver` monitor reasoning integrity, while the `IAuditEvent` family establishes traceable audit evidence.

## 2. Related Use Cases
- `UC-13` Runtime Signature Verification and Governance
- `UC-20` Deterministic Replay and Audit
- `UC-21` Policy Enforcement

## 3. Related Specs
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC.md`
- `16.SEMANTIC_CONTEXT_OS_VISION.md`

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Prompt`

## Documents`r`n- ISignatureTrustStore.md`r`n- IAttentionGuard.md
- IAttentionObserver.md
- IAuditEvent.md
- IAuditEventContract.md
- IContextLifecycleManager.md
- IHistorySummarizer.md
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines

