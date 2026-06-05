# Review Notes

## Package

`aikernel_dynamicslm_capability_modular_self_improving_slm_v0_1_0_canonical_en_rev1_final_clean.zip`

## DOI

https://doi.org/10.5281/zenodo.20550614

## Canonical Language

English is the canonical manuscript. Japanese is included as a companion translation.

## Editorial Changes

- Reworked the supplied DynamicSLM draft into a publication-ready English technical note and a Japanese companion translation.
- Preserved the requested structure: Introduction, Related Work, Architecture, Distillation, Runtime, Conceptual Evaluation, Discussion, and Conclusion.
- Standardized terminology around Capability, Semantic Profile, Execution Profile, Capability Graph, Model ABI, Lineage, Payload, ReplayLog, and heterogeneous compute.
- Clarified that DynamicSLM is an architecture proposal and that the Conceptual Evaluation section is non-empirical.
- Avoided adding external references not explicitly present in the draft requirements.
- Added Zenodo metadata, CITATION.cff, .zenodo.json, and checksums.

## Rendering QA

- Rendered English and Japanese PDFs to page images for visual inspection.
- Confirmed A4 layout, embedded fonts, and no visible clipping in inspected pages.


## Rev1 Review-Driven Changes

- Added an explicit non-empirical statement to the Abstract.
- Clarified the operating-system analogy before using it in the Introduction.
- Expanded Related Work with representative Modular LLM, MoE, LoRA/QLoRA, Toolformer, Self-Refine, Reflexion, DPO/ORPO, trajectory distillation, AI OS/runtime, and inference-serving examples without adding formal reference entries.
- Clarified that the five Model ABI elements collectively define the boundary between AIKernel and DynamicSLM artifacts.
- Generalized differential distillation beyond LoRA to include adapters, QLoRA deltas, block-level updates, segment-level payload replacement, and other ABI-admitted capability artifacts.
- Added a sentence explaining the Semantic Storage Model as a deterministic intermediate representation layer for trajectory integration.
- Strengthened the Conceptual Evaluation wording with expected, hypothetical, architecturally plausible language to avoid empirical overclaiming.


## Rev2 Reference Integration

- Added selected AIKernel-series references that directly support DynamicSLM's Semantic Context OS assumptions, Model ABI, Capability Graph, Semantic Storage, HashChain lineage, ReplayLog, Differential Distillation, Teacher Delegation, Execution Model, Compute Shape Advisor, Pipeline Orchestrator, Model Vector Router, and Unified Architecture context.
- Excluded less directly relevant monad-composition-only references from the manuscript reference list to avoid overloading the DynamicSLM paper.
- Synchronized paper-en.md, paper-ja.md, metadata-zenodo.md, and .zenodo.json with the selected references.


## Rev3 Reference Cleanup

- Reviewed the provisional AIKernel reference set and reduced the manuscript references to works directly needed by the DynamicSLM argument.
- Prepared the reference structure for a final pass using the author's ORCID-linked AIKernel paper list and the latest DOI guidance.

## Rev4 Reference Finalization

- Removed review-process wording from the public manuscript and Zenodo metadata.
- Replaced the older Trajectory Governance DOI with the author-specified later version `10.5281/zenodo.20309510`.
- Added the author-specified Phase-2 Theory DOI `10.5281/zenodo.20312092` because it is directly connected to DynamicSLM's semantic-compilation positioning.
- Re-selected the final AIKernel references for direct relevance to DynamicSLM: Trajectory Governance, Phase-2 Semantic Compilation Architecture, Semantic DSL Compiler, and HATL.
- Kept broader candidate references out of the manuscript when they were not directly needed for the DynamicSLM argument.
