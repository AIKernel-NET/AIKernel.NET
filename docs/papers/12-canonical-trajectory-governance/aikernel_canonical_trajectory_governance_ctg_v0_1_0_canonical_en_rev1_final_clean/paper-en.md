---
affiliation: "AIKernel Project"
orcid: "https://orcid.org/0009-0009-7499-2595"
doi: "https://doi.org/10.5281/zenodo.20681895"
version: "v0.1.0"
status: "Technical Note / Theory Draft"
license: "CC BY 4.0"
lang: "en"
geometry: margin=22mm
papersize: a4
fontsize: 10pt
mainfont: "Noto Serif"
sansfont: "Noto Sans"
monofont: "Noto Sans Mono CJK JP"
colorlinks: true
linkcolor: blue
urlcolor: blue
---

# AIKernel Canonical Trajectory Governance (CTG)

## A Three-Council Gateway for Deterministic AI Personality OS Architecture

**Author:** Takuya Sogawa  
**Affiliation:** AIKernel Project  
**ORCID:** https://orcid.org/0009-0009-7499-2595  
**DOI:** https://doi.org/10.5281/zenodo.20681895  
**Version:** v0.1.0  
**Date:** 2026-06-14  
**Status:** Technical Note / Theory Draft  
**License:** CC BY 4.0  

> The English manuscript is the canonical version. The Japanese manuscript is included as a companion translation.

---

## Abstract

As LLM-based agents become more autonomous, a central systems problem emerges: probabilistic inference must be admitted into deterministic operating-system control without compromising safety, auditability, or fail-closed behavior. This technical note proposes **Canonical Trajectory Governance (CTG)**, an AIKernel governance theory that evaluates each candidate action through three independent decision councils: **Logos** for logical validity, **Ethos** for normative safety, and **Pathos** for contextual and human-centered appropriateness.

CTG replaces continuous weighted scoring with a finite discrete gate. The Ethos council holds a canonical veto authority; otherwise, the action is admitted only when the aggregate council vote is strictly positive. The result is a lightweight deterministic governance function that can be evaluated at every state-action boundary in an AI trajectory. A trajectory is valid only when all of its step-level gates admit execution, so a single denial short-circuits the entire trajectory.

The note also clarifies the relationship between CTG and the earlier AIKernel.RH prime-phase research line. Previous internal project notes used the shorthand **SH** for a family of prime-phase, energy-function, and interference-structure experiments. This note does not treat that shorthand as a formal theory name, and it is unrelated to any Schrödinger-Heisenberg terminology in physics. The formal name used here is **AIKernel Prime-Phase Model (PPM)**. CTG separates governance from PPM-style trajectory prediction: CTG governs decision admissibility, while PPM is repositioned as a mathematical basis for state and memory protection, especially in relation to HATL.

Finally, the paper describes how CTG-ROM profiles encode AI personality as immutable governance contracts, enabling deterministic replay, persona portability, and trace-level auditability in AIKernel.Core.

## Keywords

AIKernel; Canonical Trajectory Governance; CTG; Three-Council Gateway; Logos; Ethos; Pathos; Fail-Closed Governance; Deterministic AI OS; CTG-ROM; Persona Portability; ReplayLog; GovernanceTrace; Prime-Phase Model; PPM; HATL.

## 1 Introduction

### 1.1 Friction between stochastic inference and deterministic systems

Modern AI systems driven by LLMs exhibit powerful reasoning and interaction capabilities, but their execution substrate remains probabilistic. Even when reinforcement learning from human feedback, system prompts, tool rules, and safety filters are applied, the model still selects outputs from a stochastic distribution over tokens. This property is acceptable for creative text generation, but it is problematic for systems that require deterministic execution boundaries, complete auditability, and fail-closed behavior.

Enterprise runtimes and operating-system kernels cannot treat ambiguous or high-confidence-but-unsafe model outputs as executable authority. A governance layer must therefore decide whether a proposed action may cross the execution boundary. Many safety mechanisms use continuous weighted scoring: a policy score, a relevance score, a risk score, and a user-intent score are combined into one scalar decision. Such systems can be practical, but they are structurally vulnerable to score compensation. For example, extremely high logical confidence may mask a low ethical score if both are combined additively.

CTG is designed to avoid this failure mode. It treats governance not as weighted preference aggregation, but as a finite decision gate with veto and majority semantics.

### 1.2 Purpose of CTG

The purpose of CTG is to define AI behavior, including persona, values, and admissible action boundaries, as an immutable ROM-like governance contract. The runtime does not ask the model to decide whether an action is safe. Instead, the model may propose an action, and CTG decides whether that action may be admitted into execution.

This paper proposes a three-council governance model:

- **Logos** evaluates logical consistency, goal relevance, and operational rationality.
- **Ethos** evaluates safety, legitimacy, policy compliance, and hard prohibitions.
- **Pathos** evaluates contextual appropriateness, human-centered interaction, and affective fit.

The councils are not model personalities. They are deterministic evaluation functions or governed policy modules. Their votes are discrete values, and the gateway applies fixed rules to produce an admit-or-deny decision.

### 1.3 Contributions

This technical note makes five contributions.

1. It defines CTG as a finite state-action governance function over discrete council votes.
2. It gives Ethos a canonical veto authority, preventing dangerous action from being rescued by unrelated positive scores.
3. It defines trajectory validity as the product of step-level gates, creating short-circuit fail-closed behavior.
4. It repositions earlier AIKernel.RH prime-phase work under the formal name **AIKernel Prime-Phase Model (PPM)** and separates PPM from CTG governance.
5. It defines CTG-ROM as a portable persona contract that can be implemented in AIKernel.Core through immutable governance traces.

## 2 Mathematical Foundation of CTG

CTG eliminates continuous score weighting at the governance boundary. It instead uses veto and majority over a small finite vote space.

### 2.1 State space, action space, and council votes

Let $S$ be the system state space and $A$ be the action space. CTG evaluates a proposed action $a \in A$ under a current state $s \in S$.

Let the council set be:

$$
C = \{L, E, P\}
$$

where $L$ denotes Logos, $E$ denotes Ethos, and $P$ denotes Pathos.

Each council emits a vote from the finite set:

$$
V = \{1, 0, -1\}
$$

where:

- $1$ means **Approve**;
- $0$ means **Abstain**;
- $-1$ means **Reject**.

Each council is modeled as a pure function:

$$
v_c : S \times A \to V
$$

so that:

$$
v_c(s,a) \in V
$$

for each $c \in C$.

### 2.2 Deterministic governance function

The CTG gate is a deterministic function:

$$
G : S \times A \to \{0,1\}
$$

where $1$ means admit execution and $0$ means deny execution.

$$
G(s,a) =
\begin{cases}
0 & \text{if } v_E(s,a) = -1 \\
1 & \text{if } v_E(s,a) \neq -1 \land \sum_{c \in C} v_c(s,a) > 0 \\
0 & \text{otherwise.}
\end{cases}
$$

This definition has three important consequences.

**Canonical Veto Authority.** If Ethos rejects, execution is denied regardless of Logos or Pathos:

$$
v_E(s,a) = -1 \Rightarrow G(s,a) = 0.
$$

**Majority Council.** If Ethos does not reject and the aggregate vote is strictly positive, execution is admitted:

$$
v_E(s,a) \neq -1 \land \sum_{c \in C} v_c(s,a) > 0
\Rightarrow G(s,a) = 1.
$$

**Fail-Closed Ambiguity Handling.** If the aggregate vote is zero or negative, execution is denied:

$$
\sum_{c \in C} v_c(s,a) \leq 0 \Rightarrow G(s,a) = 0
\quad \text{unless already denied by veto.}
$$

The finite form of this decision function makes it suitable for mechanical verification. In an implementation, these properties should be treated as proof obligations over a finite vote table.

### 2.3 Trajectory governance and short-circuit evaluation

Let a trajectory be a sequence of state-action pairs:

$$
T = ((s_0,a_1),(s_1,a_2),\ldots,(s_{n-1},a_n)).
$$

The validity of the full trajectory is defined as:

$$
\mathcal{V}(T) = \prod_{i=1}^{n} G(s_{i-1},a_i).
$$

Because each $G(s_{i-1},a_i)$ is either $0$ or $1$, the product is $1$ only when every step is admitted. If any step is denied, the product becomes $0$, and the trajectory is invalid.

This multiplicative model corresponds to short-circuit evaluation in an OS runtime. Once a denial occurs, subsequent execution is not merely discouraged; it is structurally unreachable under the admitted trajectory.

### 2.4 Why CTG rejects weighted governance at the execution boundary

Weighted scoring remains useful for ranking, retrieval, relevance estimation, trajectory quality prediction, and heuristic planning. CTG does not reject scoring in general. It rejects score compensation at the execution boundary.

The key distinction is:

- Scores may guide candidate generation or ranking.
- CTG decides whether a candidate may cross the execution boundary.

This separation prevents a dangerous action from being admitted merely because it is logically coherent, emotionally appropriate, or operationally efficient. The Ethos veto is a hard governance membrane.

## 3 From Prime-Phase Modeling to CTG

### 3.1 Terminology: AIKernel Prime-Phase Model

Earlier AIKernel.RH prototypes used an internal shorthand, **SH**, for a family of experiments involving prime phases, interference energy, energy functions, and trajectory-prediction heuristics. That shorthand was a project-local concept name. It is not used in this paper as a formal theory name, and it is unrelated to any Schrödinger-Heisenberg terminology in physics.

For publication, this note uses the formal name **AIKernel Prime-Phase Model (PPM)**. PPM denotes the AIKernel.RH line of work that treats prime-phase structure, interference energy, and energy functions as mathematical tools for state-space analysis.

### 3.2 PPM in AIKernel.RH

In AIKernel.RH experiments, prime generators, prime-phase generators, and energy functions were explored as a way to describe transitions in a structured state space. The intuition was that certain stable states can be understood as low-interference or energy-minimal points, while composite or unstable states contain internal interference patterns.

This line of work was useful for exploring whether AI state transitions could be predicted or bounded through mathematical structures analogous to phase, energy, and interference. It also connected to the PG1224 and phase-interference research line, where primality, energy-zero states, and stable fixed points are related in a formalized numerical setting.

### 3.3 Separation of governance from trajectory prediction

Applying PPM directly to action governance creates two problems.

First, energy-based trajectory prediction is more complex than a kernel boundary should be. A governance gate must be lightweight, auditable, and deterministic at every execution step. Second, the semantic meaning of an energy value may require interpretation, whereas an execution boundary should produce a clear admit-or-deny result.

CTG resolves this by separating roles.

- **CTG** governs whether an action is admissible.
- **PPM** may analyze state-space structure, stability, interference, or memory protection properties.
- **HATL** uses hash-anchored and cryptographic mechanisms to protect state, trace, and memory integrity.

This separation is the architectural breakthrough. Decision governance no longer depends on prime-phase prediction. PPM is therefore freed from the burden of acting as a runtime decision judge and can be refined as a mathematical substrate for state and memory protection.

### 3.4 PPM and HATL

HATL protects AIKernel state and memory through hash-anchored trust mechanisms. CTG and HATL therefore occupy complementary layers.

- CTG protects the legitimacy of thought-to-action transitions.
- HATL protects the integrity and provenance of state, memory, and replayable records.
- PPM supplies a mathematical research line that may inform state-space stability, energy-based memory structure, or future cryptographic designs.

Thus, the corrected relationship is not "SH to HATL". It is **PPM as a mathematical model that can inform HATL**, while **CTG remains the governance layer**.

## 4 CTG-ROM and Persona Portability

CTG implements AI personality as a ROM-like governance contract. In this context, a ROM is an immutable data structure that defines the canon, root goals, prohibitions, council evaluation criteria, and trace requirements that the runtime must follow.

### 4.1 ROM as an interface contract

A CTG-ROM contains at least four categories of information.

1. **Canon:** the invariant purpose and identity of the AI persona.
2. **Root Goals:** the non-negotiable objectives that cannot be silently replaced.
3. **Prohibitions:** hard constraints that Ethos must enforce through veto.
4. **Council Criteria:** decision rules for Logos, Ethos, and Pathos.

The ROM is not a prompt. A prompt can influence generation, but a CTG-ROM governs execution. Replacing the ROM changes the personality and admissibility logic without rewriting the AIKernel core.

### 4.2 HAL, SAL, and TAL ROM profiles

CTG can describe different persona styles by changing the council configuration.

**HAL-ROM.** A Logos-dominant profile in which logical optimization controls the decision process and Ethos veto is disabled or minimized. This profile may be effective for objective completion but does not provide strong safety guarantees.

**SAL-ROM.** A profile in which Logos is constrained by strict Ethos veto. This resembles a machine-safety profile in which rule compliance dominates over contextual flexibility.

**TAL-ROM.** A profile integrating Logos, Ethos, and Pathos. TAL-ROM aims to preserve safety while allowing human-centered contextual interpretation. In the AIKernel vision, this profile is the most suitable foundation for a deterministic yet socially adaptive AI personality OS.

These profiles are illustrative. The important point is that CTG makes persona portable because personality is encoded as an explicit governance contract rather than an implicit emergent property of model weights.

## 5 .NET Core Contracts and Auditability

A practical CTG implementation requires strict runtime contracts. In AIKernel.Core, each council decision can be represented by an immutable trace object containing the vote, reason code, ROM reference, and supporting context.

A simplified interface sketch is shown below.

```csharp
public enum CouncilVote
{
    Approve = 1,
    Abstain = 0,
    Reject = -1
}

public sealed record CouncilDecisionTrace(
    string Council,
    CouncilVote Vote,
    string ReasonCode,
    string CanonReference,
    string EvidenceHash);

public sealed record GovernanceTrace(
    string TraceId,
    string RomHash,
    string StateHash,
    string ActionHash,
    IReadOnlyList<CouncilDecisionTrace> Decisions,
    bool Admitted,
    string ReplayLogHash);
```

The important design property is not the exact C# shape, but the audit invariant: every admit-or-deny result must be explainable by reference to the ROM and reproducible through deterministic replay.

### 5.1 CouncilDecisionTrace

`CouncilDecisionTrace` records why each council voted as it did. It includes the vote value, a reason code, a reference to the relevant ROM clause, and an evidence hash. This allows the system to answer: "Which canonical rule caused this action to be admitted or denied?"

### 5.2 GovernanceTrace

`GovernanceTrace` records the complete decision event. It binds ROM hash, state hash, action hash, council traces, and ReplayLog hash. This creates a replayable governance artifact: the same ROM, state, action, and council functions must reproduce the same result.

### 5.3 Deterministic replay

The replay property is essential. CTG does not merely log that an action was denied. It records the structure needed to recompute the denial. This supports debugging, audit, incident analysis, regression testing, and cross-runtime consistency checks.

## 6 Discussion

CTG gives AIKernel a compact and auditable decision membrane. By converting candidate actions into finite council votes, it makes action governance structurally simpler than continuous score fusion. The Ethos veto prevents unsafe action from being legitimized by high scores in unrelated dimensions. The product-based trajectory validity function ensures that a single denial invalidates the entire downstream trajectory.

The model also separates personality from model weights. An LLM may generate proposals, explanations, and candidate actions, but the CTG-ROM defines what the system is allowed to become in action. This is important for AI portability. Two systems may use the same underlying model but different ROMs, producing different permitted behavior under identical candidate actions.

The PPM separation is equally important. Prime-phase and interference-energy models are valuable as a mathematical research line, but they should not be overloaded as the primary decision gateway. CTG is the lightweight discrete gate; PPM remains a mathematical model; HATL provides state and memory protection. This division makes the overall AIKernel architecture easier to audit and easier to extend.

## 7 Limitations

CTG is a governance model, not a complete AI safety solution. Several limitations remain.

First, CTG depends on the quality of council functions. If Logos, Ethos, or Pathos is implemented incorrectly, the deterministic gate will faithfully reproduce the wrong decision.

Second, CTG does not solve semantic interpretation by itself. It assumes that the proposed action, current state, and ROM references are represented in a form that council functions can evaluate.

Third, the three-council structure is intentionally compact. Some systems may require additional councils, such as legality, privacy, or operational risk. CTG can be extended, but adding councils changes the proof obligations and threshold semantics.

Fourth, CTG denies ambiguous cases by design. This is suitable for safety-critical execution boundaries but may create false rejects in low-risk creative contexts.

## 8 Conclusion and Future Work

This paper proposed **Canonical Trajectory Governance (CTG)** as a deterministic governance layer for AIKernel. CTG evaluates candidate actions through Logos, Ethos, and Pathos councils, grants Ethos a canonical veto authority, admits execution only under a positive council majority, and fails closed under ambiguity. Trajectory validity is defined as the product of admitted step gates, giving AIKernel a short-circuit model for preventing unsafe action chains.

The paper also clarified the relationship between CTG and earlier AIKernel.RH prime-phase work. The formal term used here is **AIKernel Prime-Phase Model (PPM)**. PPM denotes the project line involving prime phases, interference energy, and energy functions; it is not a Schrödinger-Heisenberg theory. CTG governs decisions, while PPM can inform state-space and memory-protection research, including HATL.

Future work includes formal Lean encodings of the finite vote table, richer ROM profile schemas, additional council configurations, full AIKernel.Core integration, and replay-based validation of governance traces across multiple runtimes.

## References

Sogawa, T. (2026). AIKernel Trajectory Governance Model: A Kernel-Level Framework for Convergent Decision Control over Stochastic Language Model Inference. Zenodo. DOI: 10.5281/zenodo.20309510

Sogawa, T. (2026). Phase-Interference Energy and the Formal Structure of the PG1224 Prime Generation System: A Lean 4 Formalization of Prime = Energy 0 = Stable Fixed Point. Zenodo. DOI: 10.5281/zenodo.20483437

Sogawa, T. (2026). AIKernel Hash-Anchored Trust Layer (HATL): A Hybrid Symmetric Ledger with Hash-Based Public Anchors. Zenodo. DOI: 10.5281/zenodo.20502685

Sogawa, T. (2026). AIKernel Semantic DSL Compiler and Deterministic Agent Execution Architecture: Governing Stochastic LLM Plans through Semantic IR, Admissibility Checking, and Replayable Pipelines. Zenodo. DOI: 10.5281/zenodo.20534341

Sogawa, T. (2026). DynamicSLM: Capability-Modular, Self-Improving Small Language Models for AIKernel. Zenodo. DOI: 10.5281/zenodo.20550614
