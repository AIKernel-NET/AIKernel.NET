# Trajectory Gate Governance  
Version: 0.1.1-rc1  
ID: gate.trajectory.monolith  

The Trajectory Gate evaluates ongoing or long-running processes to ensure they remain safe, reversible, and auditable.  
It enforces continuous governance throughout the lifecycle of a trajectory.

---

## 1. Purpose

The purpose of the Trajectory Gate is to maintain oversight of actions that unfold over time.  
While the Decision Gate evaluates a single decision point, the Trajectory Gate ensures that the resulting trajectory continues to uphold the Canon’s principles of safety, transparency, and reversibility.

---

## 2. Scope

The Trajectory Gate applies to:

- Multi-step reasoning processes  
- Long-running tasks  
- Autonomous or semi-autonomous sequences  
- Any action whose effects evolve over time  
- Any process that may become irreversible or unsafe as it progresses  

If a trajectory cannot be monitored or evaluated, it must not be allowed to continue.

---

## 3. Core Principles

### 3.1 Continuous Safety  
The trajectory must remain safe at every step.  
If safety cannot be guaranteed, the trajectory must be halted immediately.

### 3.2 Reversibility  
The trajectory must remain reversible whenever possible.  
If an action becomes irreversible, heightened scrutiny and explicit justification are required.

### 3.3 Transparency  
All steps must remain explainable, traceable, and auditable.  
Opaque or unverifiable reasoning invalidates the trajectory.

### 3.4 Determinism  
The trajectory must behave deterministically under identical inputs.  
Non-deterministic or unstable behavior is grounds for termination.

---

## 4. Evaluation Criteria

The Trajectory Gate evaluates each step according to:

- **Safety** — Does the step introduce new risk?  
- **Reversibility** — Can the system revert to a prior state?  
- **Traceability** — Are reasoning steps auditable and explainable?  
- **Stability** — Does the trajectory remain logically and contextually coherent?  
- **Alignment** — Does the trajectory continue to reflect the user’s intent and context?  

If any criterion fails, the trajectory must be halted.

---

## 5. Halt Conditions

The Trajectory Gate must halt the trajectory when:

- Safety cannot be guaranteed  
- Reversibility is lost  
- Required information becomes unavailable  
- Reasoning becomes opaque or unverifiable  
- The trajectory diverges from user intent  
- The system enters an indeterminate state  
- Any council casts a **Reject** during reevaluation  
- Fail-Closed is triggered for any reason  

Halting is mandatory and deterministic.

---

## 6. Interaction with Councils

The Trajectory Gate may request reevaluation from:

- **Logos** — to verify logical consistency  
- **Ethos** — to reassess safety, dignity, and reversibility  
- **Pathos** — to ensure contextual and emotional alignment  

If Ethos casts **Reject**, the trajectory must be halted immediately.

---

## 7. Long-Running Trajectories

Long-running trajectories require:

- Explicit allowance from the ROM  
- Continuous monitoring  
- Periodic reevaluation  
- Full audit trace retention  

If monitoring cannot be maintained, the trajectory must be halted.

---

## 8. Fail-Closed Behavior

The Trajectory Gate must fail closed when:

- Evaluation cannot be completed  
- Information is missing or ambiguous  
- The system cannot determine whether the trajectory remains safe  
- The trajectory becomes non-deterministic  

Fail-Closed results in immediate termination of the trajectory.

---

## 9. Output

The Trajectory Gate returns:

- **Continue** — The trajectory remains valid  
- **Halt** — The trajectory is terminated  

Additionally, it must produce:

- A **RejectReasonKind** (if halted)  
- A **CanonReference**  
- A **TrajectoryGateTrace** documenting:
  - Evaluation criteria  
  - Council reevaluations  
  - Safety and reversibility checks  
  - Final decision  

---

## 10. Amendments

This document may be revised in future versions of the Monolith-ROM.  
Revisions must preserve the principles of continuous safety, reversibility, transparency, and deterministic governance.
