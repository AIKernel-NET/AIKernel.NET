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
Governance covers execution authorization, auditability, attention-quality supervision, and trajectory evidence exchange. `IAttentionGuard` and `IAttentionObserver` monitor reasoning integrity, trajectory governance DTOs carry semantic ellipsoid and score evidence, and the `IAuditEvent` family establishes traceable audit records.
For v0.0.5, governance DTOs also expose admission replay records and Semantic IR slot vocabulary so Core/runtime packages can attach fail-closed pre-inference evidence to ReplayLog without adding implementation behavior to the contract package.

## 2. Related Use Cases
- `UC-13` Runtime Signature Verification and Governance
- `UC-20` Deterministic Replay and Audit
- `UC-21` Policy Enforcement

## 3. Related Specs
- [Signed Prompt Governance Spec](../../../specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC.md)
- [Semantic Context OS Vision](../../16.SEMANTIC_CONTEXT_OS_VISION.md)

## 4. Dependency Boundary
- Depends on: `AIKernel.Dtos`, `AIKernel.Contracts`, `AIKernel.Enums`
- Called by: `AIKernel.Abstractions.Execution`, `AIKernel.Abstractions.Hosting`, `AIKernel.Abstractions.Prompt`

## 5. Documents
- [ISignatureTrustStore](ISignatureTrustStore.md)
- [IAttentionGuard](IAttentionGuard.md)
- [IAttentionObserver](IAttentionObserver.md)
- [IAuditEvent](IAuditEvent.md)
- [IAuditLogger](IAuditLogger.md)
- [IAuditEventContract](IAuditEventContract.md)
- [IContextLifecycleManager](IContextLifecycleManager.md)
- [IChatTurn HashChain Contracts](IChatTurnHashChainContracts.md)

## 6. Shared DTO / Enum Vocabulary
- `AdmissibilityReplayRecord`: replay-compatible evidence emitted by a pre-inference admission gate.
- `AdmissibilityGateKind`: prompt override, capability admission, critical operation, computational complexity, policy decision, context integrity, and runtime invariant gates.
- `AdmissibilityDecisionKind`: admit, deny, transform, delegate, decompose, suspend for approval, clarify, read-only, and quarantine decisions.
- `SemanticIrSlot`: the G/T/C/B Semantic IR slot vocabulary used by semantic compilation and DSL admission.

`AdmissibilityReplayRecord.Metadata` is the extension point for paper-level fields such as validator versions, budget, complexity profile, attached requirements, delegated solver identity, timestamp, and trace identifiers. Runtime packages should canonicalize and hash those metadata values before attaching them to ReplayLog.

---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.4 (2026-06-04): Moved IHistorySummarizer documentation to the history interface category.
- v0.0.4 (2026-06-04): Added ChatChain governance contract documentation.
- v0.0.4 (2026-06-04): Added IAuditLogger to the governance interface index.
- v0.0.5 (2026-06-05): Added admission replay and Semantic IR slot vocabulary notes.
