
# Review Notes

## Package

`aikernel_semantic_dsl_compiler_deterministic_agent_execution_v0_1_0_canonical_en_rev1_final_clean.zip`

## DOI

https://doi.org/10.5281/zenodo.20534341

## Canonical Language

English is the canonical manuscript. Japanese is included as a companion translation.

## Editorial Changes

### rev1 Review Integration

- Rewrote the Abstract to state the core novelty in the first lines: OS-level deterministic governance of probabilistic LLM plans through a Semantic DSL Compiler.
- Strengthened the non-code positioning of Semantic DSL and added the four-slot Semantic IR model `(G, T, C, B)`.
- Added a formal admissibility predicate `A(x)` and explicit fail-closed rejection conditions.
- Added a runtime artifact diagram connecting DSL, PipelineNode, CompiledDslPipeline, ResultStep, SemanticDelta, ReplayLog, and ReplayLogHash.
- Expanded Suspend/Resume and bounded loop determinism, including loop iteration records and suspension hash continuity.
- Strengthened Related Work with a comparison against LangChain/LangGraph, AutoGen, Semantic Kernel, WASM, and workflow engines.
- Converted the Evaluation section into a validation matrix with deterministic replay, ROM tamper rejection, suspend/resume continuity, bounded loop checks, and indeterminate PDP behavior.
- Reorganized Limitations into expressiveness limits, provider determinism, hash-chain stability, and intent extraction uncertainty.
- Clarified the Phase-2.5 bridge from CapabilityROM, VFS, Semantic DSL, and deterministic execution toward a future Phase-3 JIT Semantic Compiler.


- Reworked the original Japanese draft into an English canonical technical note and Japanese companion translation.
- Clarified that AI-generated DSL is structured Semantic IR and not executable source code.
- Added explicit design goals and non-goals to avoid overclaiming deterministic behavior of LLM planning.
- Added fail-closed handling for malformed, unauthorized, cyclic, unbounded, or indeterminate pipeline states.
- Expanded the deterministic execution model around `ResultStep`, `SemanticDelta`, hash-linked `ReplayLog`, and C# `Task<Result<T>>` / LINQ bind composition.
- Added limitations and evaluation plan sections suitable for Zenodo technical-note publication.
- Updated references to include LangChain, LangGraph, Semantic Kernel, AutoGen, monads, and prior AIKernel publications.

## Rendering QA

- PDFs regenerated from the final Markdown sources.
- A4 layout used for both English and Japanese versions.
- Code blocks configured for line wrapping to avoid right-edge clipping.
- `CHECKSUMS.txt` regenerated after final file creation.

## Final PDF QA

- paper-en.pdf: 8 pages / A4 / rendered for visual inspection.
- paper-ja.pdf: 7 pages / A4 / rendered for visual inspection.
- References and code blocks checked for right-edge clipping.
