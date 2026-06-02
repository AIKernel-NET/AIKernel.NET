# AIKernel: Formal Foundations for Trajectory Governance and the AIKernel.NET Runtime

[![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.20223205.svg)](https://doi.org/10.5281/zenodo.20223205)

## Project Overview
**AIKernel is a Semantic Context OS for AI applications**. The project was established to provide an auditable control perimeter for AI execution environments, addressing the inherent uncertainties of generative AI.

## Research Background: The Need for Trajectory Governance
"AI Agent" systems built around Large Language Models (LLMs) inherently involve non-deterministic behavior due to their stochastic reasoning processes and handling of unstructured data. This lack of predictability presents significant barriers to reliability and reproducibility in enterprise-level adoption.
Current autonomous AI systems face the following theoretical challenges:
1. **Lack of Semantic Boundaries**: Vulnerability to context contamination and prompt injection attacks.
2. **Opacity of State Transitions**: A lack of computational models to track and control reasoning deviations.
3. **Goal Drift**: The absence of structural means to prevent the inference process from drifting away from the user's original intent.
4. **Non-determinism of Safety**: System behavior is difficult to predict because policies are often written in natural language.

## Core Theory
This research models the AI reasoning process as a continuous **Trajectory** and defines a robust, implementable approach for evaluating system stability and safety.
* **Semantic Ellipsoids**: The LLM inference process is formalized as a stochastic transition function. Each state is represented geometrically as a **Semantic Ellipsoid** that accounts for uncertainty, utilizing an Approximate Mahalanobis Distance for evaluation.
* **4-Stage Governance Model**: AIKernel applies a "Propose, Evaluate, Decide, and Transition" intervention model to control non-deterministic trajectories.
* **Scores and Fail-Closed Logic**: The system calculates a **Convergence Score ($C_t$)** to indicate stable progression toward the goal, and an **Anomaly Score ($A_t$)** to detect local dangerous spikes. If the trajectory exceeds the safety boundary, the system immediately triggers an **Abort**, enforcing a Fail-Closed fallback to a halted state.
* **Architecture Separation (SGP Pipeline)**: The framework decouples the reasoning process into **Structure** (logical structuring), **Generation** (expression), and **Polish** (final refinement). It also incorporates a standard access control model consisting of a Policy Decision Point (PDP), Policy Enforcement Point (PEP), and Policy Information Point (PIP).

## Implementation: AIKernel.NET
This theoretical model is mapped to `AIKernel.NET`, an OS-like architecture that provides a governed AI runtime design focusing on semantic context, virtual file systems, provider abstraction, deterministic execution, and Fail-Closed governance. `AIKernel.NET` packages are published and updated through the AIKernel-NET NuGet profile.

## Proposed Experimental Validation Plan
To evaluate the theoretical architecture, the project has established the following multi-phase proposed experimental validation plan:
* **Phase 1: Connectivity**: Validating stable structured output using local SLMs.
* **Phase 2: Candidate Generation**: Testing risk determination and candidate filtering.
* **Phase 3: Governance**: Verifying Fail-Closed logic and approval routing.
* **Phase 4: Replay Calibration**: Optimizing weights and thresholds using ReplayLogs.
* **Phase 5: Open-Weight Extension**: Correlation analysis using internal hidden states and logit entropy.

## Keywords
AIKernel, Trajectory Governance, Large Language Models, LLM Agents, AI Safety, AI Governance, Semantic Context, Deterministic Execution, Fail-Closed, Replay Log, Semantic Ellipsoid, Goal Drift, Tool Risk, AI Runtime, AIKernel.NET

## Related Identifiers
* **IsSupplementedBy**: [https://github.com/AIKernel-NET/AIKernel.NET](https://github.com/AIKernel-NET/AIKernel.NET)
* **IsDocumentedBy**: [https://aikernel.net/](https://aikernel.net/)
* **IsSupplementedBy**: [https://www.nuget.org/profiles/AIKernel-NET](https://www.nuget.org/profiles/AIKernel-NET)

## Citation
```bibtex
@misc{aikernel2026,
  author = {Takuya, Sogawa},
  title = {AIKernel: Formal Foundations for Trajectory Governance and the AIKernel.NET Runtime},
  year = {2026},
  version = {v0.1.1},
  publisher = {Zenodo},
  doi = {10.5281/zenodo.20223205},
  url = {https://doi.org/10.5281/zenodo.20223205}
}