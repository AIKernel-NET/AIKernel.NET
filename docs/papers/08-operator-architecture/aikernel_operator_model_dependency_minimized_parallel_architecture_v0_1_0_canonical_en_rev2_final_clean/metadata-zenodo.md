# Zenodo Metadata Draft

## Basic Information

- Resource type: Publication
- Publication type: Technical note
- Title: A Dependency-Minimized Parallel Computing Architecture Based on the AIKernel Operator Model
- Subtitle: A Lean-C-C# Externalized Operator Design for the Prime Phase Generator
- Version: v0.1.0
- Publication date: 2026-06-02
- DOI: 10.5281/zenodo.20493017
- Creator: Sogawa, Takuya
- ORCID: https://orcid.org/0009-0009-7499-2595
- Affiliation: AIKernel Project
- License: Creative Commons Attribution 4.0 International (CC BY 4.0)
- Language: English
- Additional language: Japanese
- Canonical manuscript: paper-en.pdf / paper-en.md
- Companion translation: paper-ja.pdf / paper-ja.md

## Description

This technical note presents the AIKernel Operator Model as a design discipline for dependency-minimized parallel computation. The case study is the Prime Phase Generator used in AIKernel.RH, a phase-interference-based prime generation and evaluation system.

In this note, dependency-minimized means that the semantic evaluation of each input unit does not depend on the evaluation result of any other input unit and does not require shared mutable state. Under this constraint, each input value can be treated as an independent Operator invocation, while the Provider layer is free to choose chunking, batching, scheduling, and placement strategies.

Across the AIKernel.RH v1.3.0 to v1.5.3 development line, the phase-interference computation was organized into a three-layer externalized Operator architecture: Lean 4 for formal semantic modeling, C for native pure computation, and C# for Provider-level orchestration. The note does not claim performance superiority over existing prime generation or primality testing methods; rather, it uses the Prime Phase Generator as a concrete example of AIKernel's Operator / Provider / Observer separation.

The English manuscript is the canonical version. The Japanese manuscript is included as a companion translation.

## Keywords

AIKernel; Operator Model; Interface-Led Architecture; Parallel Computing; Lean 4; Native Operator; Prime Phase Generator; Phase Interference; C#; P/Invoke; Lock-Free Computation; TensorKernel

## Files

- paper-en.pdf (Preview / canonical)
- paper-ja.pdf (Companion translation)
- paper-en.md
- paper-ja.md
- metadata-zenodo.md
- review-notes.md
- CITATION.cff
- .zenodo.json
- CHECKSUMS.txt

## Archive Name

- aikernel_operator_model_dependency_minimized_parallel_architecture_v0_1_0_canonical_en_final_clean.zip

## References

- Amdahl, G. M. (1967). Validity of the Single Processor Approach to Achieving Large Scale Computing Capabilities. AFIPS Conference Proceedings, 30, 483-485. https://doi.org/10.1145/1465482.1465560
- Gustafson, J. L. (1988). Reevaluating Amdahl's Law. Communications of the ACM, 31(5), 532-533. https://doi.org/10.1145/42411.42415
- de Moura, L., Kong, S., Avigad, J., van Doorn, F., & von Raumer, J. (2015). The Lean Theorem Prover. Automated Deduction - CADE-25, Lecture Notes in Computer Science, 9195, 378-388. Springer. https://doi.org/10.1007/978-3-319-21401-6_26
- The mathlib Community. (2020). The Lean mathematical library. Proceedings of the 9th ACM SIGPLAN International Conference on Certified Programs and Proofs, 367-381. https://doi.org/10.1145/3372885.3373824
- Sogawa, T. (2026). Phase-Interference Energy and the Formal Structure of the PG1224 Prime Generation System: A Lean 4 Formalization of Prime = Energy 0 = Stable Fixed Point. Zenodo. https://doi.org/10.5281/zenodo.20483437
- Sogawa, T. (2026). AIKernel Trajectory Governance Model: A Kernel-Level Framework for Convergent Decision Control over Stochastic Language Model Inference. Zenodo. https://doi.org/10.5281/zenodo.20290614
- Sogawa, T. (2026). AIKernel Formal Foundations: Contract-Based Semantic Execution for Governed AI Systems. Zenodo. https://doi.org/10.5281/zenodo.20460322

## Packaging Notes

- Revised the title from a stronger dependency-zero formulation to a more publication-safe dependency-minimized formulation.
- Created an English canonical manuscript.
- Created a Japanese companion translation.
- Added Zenodo DOI metadata: 10.5281/zenodo.20493017.
- Generated PDFs from synchronized Markdown sources.
- Packaged only final public files.
- Regenerated checksums.
