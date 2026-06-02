---
title: "governance Interfaces"
created: 2026-05-03
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

Japanese version: [Governance Interfaces](index-jp.md)

# Governance Interfaces

## 1. Responsibility Boundary
Governance covers execution authorization, auditability, and attention-quality supervision. `IAttentionGuard` and `IAttentionObserver` monitor reasoning integrity, while the `IAuditEvent` family establishes traceable audit evidence.

## 2. Related Use Cases
- `UC-13` Runtime Signature Verification and Governance
- `UC-20` Deterministic Replay and Audit
- `UC-21` Policy Enforcement

## 3. Related Specs
- [Signed Prompt Governance Spec](../../02.SIGNED_PROMPT_GOVERNANCE_SPEC.md)
- [Semantic Context OS Vision](../../16.SEMANTIC_CONTEXT_OS_VISION.md)

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Prompt`

## 5. Documents
- [ISignatureTrustStore](ISignatureTrustStore.md)
- [IAttentionGuard](IAttentionGuard.md)
- [IAttentionObserver](IAttentionObserver.md)
- [IAuditEvent](IAuditEvent.md)
- [IAuditEventContract](IAuditEventContract.md)
- [IContextLifecycleManager](IContextLifecycleManager.md)
- [IHistorySummarizer](IHistorySummarizer.md)

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
