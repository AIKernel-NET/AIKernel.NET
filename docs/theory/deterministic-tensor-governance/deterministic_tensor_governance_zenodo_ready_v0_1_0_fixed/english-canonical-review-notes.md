# English Canonicalization and Review Notes

## Summary

This package makes the English manuscript the canonical version of **Deterministic Tensor Governance via Interface-Led Architecture**. The Japanese manuscript is included as a companion translation.

## Review decisions

1. The English paper avoids claiming physical equivalence between LLM sampling and QPU measurement.
2. The term **architecturally analogous** is used to define the relationship between LLM and QPU providers at the system boundary.
3. **TensorKernel** is explicitly defined as a contract-first governance layer, not as a low-level execution kernel.
4. The paper explicitly states non-claims: it does not replace QOS, QNodeOS, Pilot-Quantum, QIR, Qiskit, PennyLane, MLIR, or existing LLM runtimes.
5. The paper treats QIR, quantum SDKs, quantum middleware, and quantum operating systems as lower-level providers, runtimes, or intermediate representations.
6. The governance skeleton, contract registry, provider adapter, result verifier, and replay log are included to make the architecture concrete.
7. The limitations section reduces overclaiming and makes the paper appropriate as a position paper.

## Reference corrections retained

- QOS is cited as Giortamis, Romão, Tornow, and Bhatotia, OSDI 25.
- QNodeOS is cited as Delle Donne et al., Nature 639, 321-328, 2025, DOI: 10.1038/s41586-025-08704-w.
- Pilot-Quantum is cited as Mantha, Kiwit, Saurabh, Jha, and Luckow, arXiv:2412.18519.

## Zenodo recommendation

Use the following Zenodo settings:

- Resource type: Publication
- Publication type: Technical note
- Title: Deterministic Tensor Governance via Interface-Led Architecture: A Contract-First Architecture for Governing LLM and Quantum Tensor Providers
- Language: English
- Additional language: Japanese, if available
- License: Creative Commons Attribution 4.0 International (CC BY 4.0)
- Access: Open Access
- Preview file: paper-en.pdf

## Final PDF layout fix

The final PDFs were regenerated with line-wrapping enabled for code blocks, tables, URLs, and long technical strings. Rendered-page verification was performed after regeneration to ensure that no text is clipped at the page boundaries.

Reserved DOI applied: 10.5281/zenodo.20303497
