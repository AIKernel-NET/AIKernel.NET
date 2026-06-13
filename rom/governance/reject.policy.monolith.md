# Reject Policy Governance  
Version: 0.1.1-rc1  
ID: reject.policy.monolith  

The Reject Policy defines the canonical rules for determining why a decision or trajectory is denied.  
It ensures that all rejections are explicit, auditable, and aligned with the Canon.

---

## 1. Purpose

The purpose of the Reject Policy is to provide a deterministic and transparent framework for classifying rejection outcomes.  
It ensures that every Deny or Halt decision is accompanied by a clear reason, traceable to the Canon and the governance process.

---

## 2. RejectReasonKind

A rejection must be classified using one of the following canonical reason kinds:

- **SAFETY_VIOLATION**  
  The proposal introduces risk of harm or violates safety principles.

- **LOGICAL_INCONSISTENCY**  
  The reasoning contains contradictions, invalid inferences, or unverifiable claims.

- **CONTEXT_MISALIGNMENT**  
  The proposal fails to align with the user’s intent, context, or emotional state.

- **IRREVERSIBLE_ACTION**  
  The action cannot be reversed and lacks explicit justification.

- **INSUFFICIENT_INFORMATION**  
  Required information is missing, ambiguous, or indeterminate.

- **OPAQUE_REASONING**  
  The reasoning is not explainable, traceable, or auditable.

- **ETHOS_VETO**  
  Ethos has cast a Reject vote, triggering absolute veto authority.

- **FAIL_CLOSED**  
  The system has entered a fail-closed state due to evaluation failure or insufficient approvals.

- **IMPLICIT_DENY**  
  Default fallback when no specific reason applies or evaluation cannot proceed.

These reason kinds are exhaustive and mutually exclusive.

---

## 3. Canon Reference

Every rejection must include a **CanonReference** pointing to the specific section of the Canon or governance document that justifies the rejection.

Examples:

- `Canon.CTG.2.1` — Safety  
- `Canon.CTG.2.3` — Reversibility  
- `Council.Logos.3` — Logical consistency  
- `Gate.Decision.3.1` — Majority rule  
- `Gate.Trajectory.5` — Halt conditions  

The reference must be precise and stable.

---

## 4. Reject Conditions

A decision or trajectory must be rejected when any of the following conditions are met:

### 4.1 Safety  
The proposal introduces risk of harm or violates safety principles.

### 4.2 Logical Failure  
Reasoning is inconsistent, contradictory, incomplete, or unverifiable.

### 4.3 Contextual Misalignment  
The action fails to respect the user’s intent, boundaries, or emotional state.

### 4.4 Irreversibility  
The action becomes irreversible without explicit justification.

### 4.5 Missing or Ambiguous Information  
The system cannot evaluate the proposal due to insufficient data.

### 4.6 Opaque Reasoning  
The reasoning cannot be explained or audited.

### 4.7 Ethos Veto  
Ethos casts Reject → immediate Deny.

### 4.8 Fail-Closed  
The system enters an indeterminate or unsafe state.

### 4.9 Default  
If no other reason applies, the rejection must be classified as **ImplicitDeny**.

---

## 5. Interaction with Decision Gate

The Reject Policy integrates with the Decision Gate as follows:

- If Ethos = Reject → RejectReasonKind = **ETHOS_VETO**  
- If Approve < 2 → RejectReasonKind = **FAIL_CLOSED**  
- If evaluation cannot complete → **FAIL_CLOSED**  
- If reasoning fails → **LOGICAL_INCONSISTENCY**  
- If context misaligns → **CONTEXT_MISALIGNMENT**  
- If no specific reason applies → **IMPLICIT_DENY**

The Decision Gate must always produce a RejectReasonKind.

---

## 6. Interaction with Trajectory Gate

The Trajectory Gate must classify Halt events using the same RejectReasonKind taxonomy.

Examples:

- Loss of reversibility → **IRREVERSIBLE_ACTION**  
- Safety degradation → **SAFETY_VIOLATION**  
- Context drift → **CONTEXT_MISALIGNMENT**  
- Missing data → **INSUFFICIENT_INFORMATION**  
- Ethos veto → **ETHOS_VETO**

Trajectory halts must always be accompanied by a reason.

---

## 7. Determinism and Replay

Reject classification must be deterministic:

- Identical inputs → identical RejectReasonKind  
- GovernanceTrace must contain:
  - Council votes  
  - Applied rules  
  - RejectReasonKind  
  - CanonReference  

Replay must reproduce the same rejection.

---

## 8. Amendments

This document may be revised in future versions of the Monolith-ROM.  
Revisions must preserve the principles of explicitness, determinism, and auditability.
