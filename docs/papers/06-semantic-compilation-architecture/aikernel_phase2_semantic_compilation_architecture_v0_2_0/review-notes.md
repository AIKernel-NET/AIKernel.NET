# Review and Revision Notes

## Scope

This package prepares the Phase-2 theory paper for Zenodo publication as v0.2.0 with the DOI 10.5281/zenodo.20312092.

## Main editorial decisions

1. English is treated as the canonical manuscript.
2. Japanese is included as a companion translation.
3. The original Semantic Compilation Architecture draft was revised into a bounded Semantic Runtime Theory.
4. Strong claims such as complete semantic formalization, literal zero entropy of meaning, LLVM isomorphism, and quantum necessity were softened into operational and architectural claims.
5. Semantic IR is preserved as a four-slot structure: G, T, C, B.
6. The four slots are aligned with Phase-1 Papers 01-04.
7. The central thesis "Observability -> Governability -> Replayability" was made explicit.
8. The composite distance function was added, separating structural components from semantic-state uncertainty.
9. Mahalanobis-style distance was limited to the semantic-state component d_S, not applied to the whole heterogeneous distance function.
10. The phrase "d_S is an observability-oriented approximation, not a proof of semantic completeness" was included as a mathematical defense line.
11. Phase-3 was positioned as a future Foundation layer, not as a prerequisite for Phase-2 validity.

## Publication notes

Recommended Zenodo files:

- paper-en.pdf as preview
- paper-ja.pdf
- aikernel_phase2_semantic_compilation_architecture_v0_2_0.zip

## Review update: Phase-2 final alignment

The latest review feedback has been incorporated.

- Added an explicit concept diagram clarifying that Semantic IR `x = (G, T, C, B)` and Semantic State `s = (mu, Sigma)` are associated but distinct artifacts.
- Added an explicit statement that Semantic State is an observability-oriented approximation for constraining, comparing, and replaying semantic variation at the AIOS governance boundary.
- Strengthened the definition of `d(x, c_k)` as a heterogeneous metric aggregation rather than a single homogeneous Euclidean metric.
- Kept Mahalanobis-style distance restricted to the semantic-state component `d_S`, preserving the mathematical separation between discrete structural distances and continuous semantic uncertainty.
- Added the same conceptual clarification to the Japanese companion translation to improve English/Japanese alignment.
