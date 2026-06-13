# Decision Gate Governance  
Version: 0.1.1-rc1  
ID: gate.decision.monolith  

The Decision Gate determines whether an action or trajectory is permitted.  
It integrates the votes of the three councils—Logos, Ethos, and Pathos—according to the Canonical Triadic Governance (CTG) model.

---

## 1. Purpose

The purpose of the Decision Gate is to provide a deterministic, auditable, and fail-closed mechanism for evaluating proposed actions.  
It ensures that all decisions uphold the principles of safety, transparency, and reversibility defined in the Canon.

---

## 2. Inputs

The Decision Gate receives:

- A proposal describing the intended action or trajectory  
- Votes from the three councils:
  - **Logos** — logical consistency  
  - **Ethos** — safety, dignity, reversibility  
  - **Pathos** — contextual and emotional alignment  

Each council returns one of:

- **Approve**  
- **Abstain**  
- **Reject**

---

## 3. Core Rules

### 3.1 Majority Approval Requirement  
A decision may pass only if **a majority of councils cast Approve**.

- Approve ≥ 2 → Eligible for approval  
- Approve ≤ 1 → Automatically denied  

This rule is deterministic and must be applied before any other evaluation.

---

### 3.2 Ethos Absolute Veto  
Ethos holds **absolute veto authority**.

- If Ethos casts **Reject**, the decision is **immediately denied**,  
  regardless of the votes from Logos or Pathos.

This rule overrides all other majority logic.

---

### 3.3 Fail-Closed Requirement  
If the Decision Gate cannot reach a deterministic conclusion, it must **fail closed**.

Fail-Closed is triggered when:

- A majority of Approve votes is not reached  
- Evaluation fails due to missing or ambiguous information  
- Councils return conflicting or indeterminate results  
- The system cannot guarantee safety, transparency, or reversibility  

Fail-Closed results in an automatic **Deny**.

---

## 4. Evaluation Procedure

The Decision Gate must evaluate proposals in the following order:

1. **Check Ethos veto**  
   - If Ethos = Reject → Deny

2. **Count Approve votes**  
   - If Approve ≥ 2 → Approve  
   - Otherwise → Deny

3. **Check for indeterminate state**  
   - If evaluation cannot be completed → Fail-Closed → Deny

This order is mandatory and ensures deterministic behavior.

---

## 5. Output

The Decision Gate returns:

- **Allow** — The decision is approved  
- **Deny** — The decision is rejected  

Additionally, the gate must produce:

- A **RejectReasonKind**  
- A **CanonReference** pointing to the relevant section of the Canon  
- A **GovernanceTrace** containing:
  - Council votes  
  - Applied rules  
  - Final decision  
  - Confidence and risk metrics (if enabled)

---

## 6. Reject Conditions

The Decision Gate must return **Deny** when:

- Ethos casts Reject  
- Majority of Approve is not reached  
- Required information is missing  
- Reasoning is opaque or unverifiable  
- The proposal violates safety, dignity, or reversibility  
- The system enters an indeterminate state  
- Fail-Closed is triggered for any reason  

Default rejection reason: **ImplicitDeny**

---

## 7. Determinism and Replay

The Decision Gate must produce identical results for identical inputs.  
All decisions must be reproducible through governance trace replay.

Non-deterministic behavior is prohibited.

---

## 8. Amendments

This document may be revised in future versions of the Monolith-ROM.  
Revisions must preserve the principles of determinism, safety, transparency, and fail-closed behavior.
