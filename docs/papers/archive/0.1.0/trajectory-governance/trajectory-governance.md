---
id: trajectory-governance-en
title: AIKernel: A Formal Governance Framework for a Semantic Context OS
subtitle: Mathematical Foundations for Deterministic Execution Control over Stochastic AI Agents
lang: en
slug: /docs/theory/trajectory-governance.en
updated: 2026-05-16
published: 2026-05-16
version: "0.1.0"
edition: "First Public Release (ROM)"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
status: "Stable (ROM)"
tags:
  - AIKernel
  - Trajectory Governance
  - Semantic Context OS
  - Governance
  - Formal Specification
  - Runtime Safety
toc: true
sidebar_position: 1
summary: >
  Formal specification and mathematical foundations of the AIKernel Trajectory Governance Model,
  defining a deterministic governance boundary around stochastic AI agents.
rom: true
---

# AIKernel: A Formal Governance Framework for a Semantic Context OS based on the Trajectory Governance Model

## Mathematical Foundations for Deterministic Execution Control over Stochastic AI Agents

## 1. Introduction

With the rapid advancement of Artificial Intelligence, particularly Large Language Models (LLMs), the computing paradigm is undergoing a major shift. "AI Agent" systems built around LLMs inherently involve non-deterministic behavior due to their stochastic reasoning processes and handling of unstructured data. This lack of predictability presents significant barriers to reliability and reproducibility in enterprise-level adoption.

The AIKernel project was established to provide an auditable control perimeter for AI execution environments. This research formalizes the "Trajectory Governance" model as a formally specified framework for governance decision-making. We demonstrate how challenges such as context contamination and Goal Drift can be theoretically mitigated, providing a foundation for runtime safety controls.

## 2. Terminology

To facilitate the understanding of the theoretical model, core concepts of the AIKernel architecture are defined as follows:

- **PDP / PEP / PIP**: Elements of a standard access control model. The **Policy Decision Point (PDP)** handles policy evaluation, the **Policy Enforcement Point (PEP)** enforces those decisions at the execution boundary, and the **Policy Information Point (PIP)** provides attributes, context, and risk information required for decisions.
    
- **SGP Pipeline**: AIKernel's inference separation model, which decouples the reasoning process into **Structure** (logical structuring), **Generation** (expression), and **Polish** (final refinement), treating logical determination and linguistic expression as distinct stages.
    

## 3. Safety Boundary

This model does not claim to transform the stochastic LLM generator itself into a fully deterministic entity. Nor does it claim that the convergence of semantic reasoning unconditionally guarantees the factual correctness of the output.

Instead, AIKernel adopts an approach that defines a deterministic **Safety Boundary** by establishing an auditable control perimeter around the stochastic inference process. Model outputs are treated as **Untrusted** until the governance layer evaluates them for semantic relevance, goal alignment, operational risk, repetition, uncertainty, and replayability.

In this sense, Trajectory Governance does not replace model-level safety within the LLM. Rather, it functions as a kernel-level **Control Plane** that decides whether to accept a proposed state transition as a valid system state.

## 4. Problem Statement

Current autonomous AI systems face the following theoretical challenges:

1. **Lack of Semantic Boundaries**: Due to the nature of attention mechanisms, systems are vulnerable to context contamination and prompt injection attacks.
    
2. **Opacity of State Transitions**: There is a lack of computational models to track and control reasoning deviations, increasing uncertainty, and iteration loops.
    
3. **Goal Drift**: There are no structural means to prevent the inference process from gradually drifting away from the user's original intent.
    
4. **Non-determinism of Safety**: Policies are often written in natural language, making system behavior difficult to predict.
    

This research models the AI reasoning process as a continuous **Trajectory** and defines a robust, implementable approach for evaluating system stability and safety.

## 5. Trajectory Governance and Mathematical Formalization

The convergence scores and mathematical formalizations introduced in this model do not prove "correctness" or "safety" in an absolute sense. Instead, they serve as operational policy scores to determine whether an observed inference trajectory is sufficiently stable, aligned, and low-risk under the set governance parameters.

### 5.1 Formalization of LLM Inference and the 4-Stage Governance Model

AIKernel formalizes the LLM inference process as a stochastic transition function dependent on the internal state $K_t$ (context) and model parameters $\theta$:

$$x_{t+1} \sim p(x \mid x_t, \theta, K_t)$$

Against this stochastic process, AIKernel applies the "4-Stage Governance Intervention Model" to control non-deterministic trajectories:

1. **Propose**: The LLM/SLM stochastically proposes the next action or state $x_{t+1}$.
    
2. **Evaluate**: The governance layer calculates the risk and convergence for the proposed state.
    
3. **Decide**: The PDP deterministically classifies the proposed transition into a controlled decision state, such as **Permit**, **Deny**, **AskConfirmation**, **Clarify**, or **Abort**.
    
4. **Transition**: The system state transition is finalized only if permitted.
    

### 5.2 Geometric Properties of the Semantic Ellipsoid

Each state or prompt on the trajectory is represented geometrically not as a single point vector, but as a **Semantic Ellipsoid** that accounts for uncertainty. To ensure computational feasibility, AIKernel employs a **Diagonal Covariance Approximation**, avoiding the cost of calculating a full covariance matrix $\Sigma$ in high-dimensional space.

- **Center and Variance Estimation**: For a set of concept samples $s_1, \dots, s_N$, the semantic center $\mu$ and the diagonal variance $\sigma_j^2$ for each dimension $j$ are estimated. Samples are obtained as contextual variations, such as multiple LLM outputs at temperature $T>0$ or vector groups within a K-shot prompt.
    
- **Approximate Mahalanobis Distance**: The distance between state $x$ and center $\mu$ is calculated using a stabilization constant $\epsilon$:
    
    $$d(x, \mu) = \sqrt{ \sum_{j=1}^n \frac{(x_j - \mu_j)^2}{\sigma_j^2 + \epsilon} }$$
    
- **Ellipsoid Volume**: Proportional to $k^d \sqrt{\det(\Sigma)}$ (excluding constant coefficients). AIKernel uses this as an **Operational Metric** for relative uncertainty rather than an absolute measure of volume.
    

### 5.3 Three-Axis Definition of Deviation

Trajectory deviation is defined along three axes:

1. **Gradient $\Delta_t$**: The rate of change of the vector in the continuous state space.
    
2. **Direction Vector**: A cosine similarity indicating whether the inference is progressing toward the goal.
    
3. **Normalized Entropy $\tilde{H}_t$**: The degree of uncertainty calculated from token output probabilities. To maintain boundedness, we use normalized entropy $\tilde{H}_t = H_t / \log |V|$, where $|V|$ is the vocabulary size.
    

### 5.4 Convergence Score $C_t$ and Anomaly Score $A_t$

Observed metrics are integrated into two core scores for governance decisions. Each score is normalized and always remains within the range $[0, 1]$.

- **Convergence Score $C_t$**: Indicates if the trajectory is stably progressing toward the goal.
    
    $$C_t = \mathrm{Clamp}\left( \alpha \cdot \text{SemOverlap}_t + \beta \cdot \text{GoalAlign}_t - \gamma \cdot \text{SmoothDrift}_t - \delta \cdot \tilde{H}_t - \rho \cdot \text{Risk}(a_t) - \eta \cdot \text{Rep}_t - \zeta \cdot \text{GoalDrift}_t, 0, 1 \right)$$
    
- **Anomaly Score $A_t$**: Detects local dangerous spikes (sudden deviations or entropy explosions) independently of the convergence score.
    
    $$A_t = \mathrm{Clamp}\left( \omega_1 \cdot \text{RawDriftSpike}_t + \omega_2 \cdot \text{EntropySpike}_t + \omega_3 \cdot \text{RiskSpike}_t, 0, 1 \right)$$
    

### 5.5 Continuous Threshold Breaches and Fail-Closed Conditions

We define $V_t = 1 - C_t$ as a **Governance Cost Function / Safety Index**. AIKernel does not claim $V_t$ is a strict Lyapunov function or a Barrier Certificate in the sense of dynamical systems; rather, it is an operational evaluation function. Thus, a decrease in $V_t$ suggests stabilization but does not prove global mathematical stability.

If the trajectory exceeds the safety boundary, the system immediately triggers an **Abort** according to the following logic:

$$\text{Abort} = (C_t < \tau_C) \lor (A_t > \tau_A) \lor (\text{Risk}(a_t) > \tau_R) \lor (\text{Rep}_t > \tau_P) \lor (\text{GoalDrift}_t > \tau_{root})$$

Furthermore, to prevent false positives from temporary fluctuations, a **Fail-Closed** fallback to a halted state is enforced if $C_t < \tau_C$ occurs $m$ or more times within a time window $W$.

## 6. Goal Governance and Context Sovereignty

To prevent Goal Drift, AIKernel governs the goal state under **Context Sovereignty**, providing an auditable control boundary through the following hierarchical model:

- **Computational Integrity of RootGoal / WorkingGoal**:
    
    - The **RootGoal ($g_{root}$)** represents the user's fundamental intent and is defined as **immutable**.
        
    - The **WorkingGoal ($g_{work,t}$)** is the step-by-step interpretation, constrained by projection or threshold-based restriction into the allowed semantic region of $g_{root}$.
        
    - Goal deviation is defined as $\text{drift} = 1 - \cos(g_{root}, g_{work,t})$.
        
    - Requests to update the WorkingGoal are permitted only if the drift remains below a configured threshold; otherwise, the update is rejected.
        

## 7. Security Model and Risk Assessment

### 7.1 Initial Risk Assessment and Calibration

AIKernel utilizes a standard access control architecture (PDP/PEP/PIP). Initial risk assessment is category-based and deterministic. Destructive operations (e.g., file deletion) or high-entropy inference results are assigned high base risk scores. Statistical calibration based on the **ReplayLog** can be used for weight adjustment but must not replace hard policy constraints (Fail-Closed principles).

### 7.2 Decision Rule and Candidate Ranking

When the LLM proposes multiple action candidates, the PDP ranks them and makes a final decision.

- **Candidate Ranking**: Actions with risk greater than or equal to $\tau_R$ are excluded a priori.
    
    The score for each candidate action $a$ is defined using the current trajectory state:
    
    $$\text{Score}(a) = \alpha \cdot \text{SemOverlap}(q,a) + \beta \cdot \text{GoalAlign}_t - \gamma \cdot \text{SmoothDrift}_t - \delta \cdot \tilde{H}_t - \rho \cdot \text{Risk}(a) - \eta \cdot \text{Rep}_t - \zeta \cdot \text{GoalDrift}_t$$
    
    $$A_{safe} = \{ a \in \text{Candidates} \mid \text{Risk}(a) < \tau_R \}$$
    
    $$a^* = \arg\max_{a \in A_{safe}} \text{Score}(a)$$
    
    If $A_{safe} = \emptyset$, the system returns **Deny** or **Clarify**.
    
- **Decision Rule**: For the selected $a^*$, the final governance judgment is made with the following priorities (where $\tau_{safe} < \tau_R$):
    
    ```
    if Abort == true then Return(Abort)
    else if SemOverlap_t < τ_sem then Return(Clarify)
    else if Risk(a*) > τ_safe then Return(AskConfirmation)
    else if C_t ≥ τ_exec then Return(Permit)
    else Return(Deny)
    ```
    

|**Decision**|**Meaning**|
|---|---|
|**Permit**|Execution allowed|
|**AskConfirmation**|Human confirmation required due to moderate risk|
|**Clarify**|Request clarification due to semantic ambiguity|
|**Deny**|Rejection based on policy|
|**Abort**|Execution halted by Fail-Closed governance|

## 8. Theoretical Guarantees and Proof Sketches

Based on the mathematical model and architecture, AIKernel provides the following theoretical guarantees:

### Assumptions

- **A1**: All governance metrics are normalized and bounded within $[0, 1]$.
    
- **A2**: Governance weights and thresholds are fixed within a single decision step.
    
- **A3**: Operational risk $R(a)$ is always evaluated before any action with side effects.
    
- **A4**: The PDP function ($I_{Pdp}$) is strictly deterministic.
    
- **A5**: The LLM can propose actions but lacks the authority to execute them.
    
- **A6**: System calls are executed only if the PDP result is **Permit**.
    

### Theorem 1. Normalization Property of Scoring Function

The convergence score $C_t$ and anomaly score $A_t$ always satisfy $0 \le C_t \le 1$ and $0 \le A_t \le 1$ as final governance outputs.

**(Proof Sketch)**: Since all input parameters are bounded within $[0, 1]$ per A1, their linear combination results in a finite value. Although penalty terms can push the raw sum outside $[0, 1]$, the application of a **Clamp** function at the final stage ensures that the scores passed to the system are strictly normalized.

### Theorem 2. Fail-Closed Safety

If the governance evaluation determines $\text{Abort} = \text{true}$, no proposed action $a$ is executed ($\neg \text{Exec}(a)$).

**(Proof Sketch)**: Per A5 and A6, execution authority is isolated within the PEP. The PEP implementation is architecturally defined to enforce the Abort-priority rule, blocking any code path to API calls with side effects at the execution boundary whenever the PDP result is not **Permit**.

### Theorem 3. Risk Threshold Exclusion

Any proposed action with calculated risk greater than or equal to the threshold ($R(a) \ge \tau_R$) is never included in the safe candidate set $A_{safe}$.

**(Proof Sketch)**: Per A3, $R(a)$ is calculated for all candidates before execution. Since the filter for $A_{safe}$ is defined as $\{ a \mid R(a) < \tau_R \}$, non-compliant actions are deterministically excluded from final selection.

### Theorem 4. Root Goal Sovereignty Invariant

As long as $g_{root}$ remains immutable, updates to $g_{work,t}$ stay within the semantic allowed region.

**(Proof Sketch)**: For any update to the WorkingGoal, the system evaluates $\text{drift} = 1 - \cos(g_{root}, g_{work,t+1})$. Transition is allowed only if $\text{drift} \le \tau_{drift}$. The system evaluates the absolute distance from $g_{root}$ at each update, and the PEP blocks any transition exceeding the direct state constraint. Therefore, by the definition of the update rule, $g_{work,t}$ is strictly constrained to the $\tau_{drift}$-neighborhood of $g_{root}$.

### Theorem 5. Deterministic Governance Replay

Given a fixed implementation version, numerical precision, embedding model, policy, thresholds, and input logs, the governance decision is reproducible.

**(Proof Sketch)**: The PDP function is deterministic per A2 and A4. The ReplayLog records immutable runtime metadata. External factors and stochastic variations are controlled through recorded replay inputs. Provided the environment and precision match, the decision remains a pure function of the input set.

### What These Guarantees Do Not Prove

- **Factual Correctness**: Whether the generated text corresponds to real-world facts.
    
- **Semantic Completeness of Embeddings**: Whether vectors capture 100% of human intent without error.
    
- **Adversarial Robustness**: Whether it can block every unknown prompt injection perfectly.
    

AIKernel guarantees the **determinism of execution admissibility conditions**—ensuring that proposed actions are strictly evaluated and controlled against defined safety boundaries.

## 9. System Architecture and Formal Specification

To operationalize Trajectory Governance, the following components are formally specified:

- **Context Isolation and Material Quarantine**: Information categories (Reasoning, Material, Expression) are strictly separated. External data must pass through a quarantine process and be structured before integration.
    
- **SGP Pipeline**: Segregates **Structure**, **Generation**, and **Polish** into distinct stages to prevent linguistic "polish" (e.g., style) from distorting logical reasoning.
    

## 10. Experimental Validation Plan

- **Phase 1: Connectivity**: Validating stable structured output using local SLMs.
    
- **Phase 2: Candidate Generation**: Testing risk determination and candidate filtering.
    
- **Phase 3: Governance**: Verifying Fail-Closed logic and approval routing.
    
- **Phase 4: Replay Calibration**: Optimizing weights and thresholds using ReplayLogs.
    
- **Phase 5: Open-Weight Extension**: Correlation analysis using internal hidden states and logit entropy.
    

## 11. The AIKernel Theory: A Semantic Context OS

The reconstructed AIKernel theory rests on three pillars: **Semantic Encapsulation** (prevention of contamination through isolation), **Declarative Governance** (control via Trajectory and PDP), and **Resource Liquidity** (dynamic routing). Together, these define a new form of operating system specialized for AI.

## 12. Conclusion

The Trajectory Governance model and formal architecture of AIKernel introduce the computer science traditions of "verifiability" and "auditability" to the stochastic nature of generative AI. By integrating concepts like Context Isolation, Semantic Ellipsoids, and RootGoal immutability into a consistent mathematical framework, this model provides a roadmap for increasing verifiability in enterprise AI systems. AIKernel represents a powerful, implementable approach to a Semantic OS that underpins the safety of future autonomous AI execution environments.

---

### Appendix: Minimal ReplayLog Schema

JSON

```
{
  "DumpId": "uuid-string",
  "ExecutionTimestampUtc": "YYYY-MM-DDTHH:mm:ss.sssZ",
  "KernelVersion": "string",
  "Seed": "integer",
  "PipelineDefinitionHash": "sha256:...",
  "PromptArtifactHash": "sha256:...",
  "ProviderManifest": {
    "ProviderId": "string",
    "Version": "string"
  },
  "MaterialSnapshotHashSet": ["sha256:..."],
  "OrchestrationSnapshotHash": "sha256:...",
  "GovernanceDecisions": [
    {
      "Step": "integer",
      "ProposedAction": "string",
      "ConvergenceScore_Ct": "float",
      "AnomalyScore_At": "float",
      "RiskScore": "float",
      "Decision": "Permit | Deny | AskConfirmation | Clarify | Abort"
    }
  ],
  "ExecutionOutcomeHash": "sha256:..."
}
```
