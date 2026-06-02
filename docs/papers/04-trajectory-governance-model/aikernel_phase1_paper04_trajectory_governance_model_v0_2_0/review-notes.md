# Review Notes

## Scope alignment

The submitted English and Japanese drafts already define Paper 04 as the runtime trajectory-governance layer that operates after Paper 03 has admitted an inference transaction. The package preserves this boundary and aligns the document with the Paper 01-03 publication style.

## Main changes applied

- Integrated the AIKernel standard YAML header.
- Added DOI 10.5281/zenodo.20309510 and publication metadata.
- Kept English as the canonical manuscript and Japanese as the companion translation.
- Preserved the relationship to the prior v0.1.1 DOI: 10.5281/zenodo.20223205.
- Added a scoped References section suitable for Paper 04.
- Kept statistical geometry and trajectory-monitoring references in Paper 04, while leaving pre-inference and storage references to Papers 02-03.
- Converted long formulas to wrapped aligned forms where needed.
- Removed stray trailing code-fence artifacts from the source draft.
- Generated PDFs with wrapping for long code blocks, tables, formulas, and JSON examples.

## Publication recommendation

Ready for Zenodo upload after final visual preview in Zenodo. Use `paper-en.pdf` as the preview file.


## Final mathematical-defense revision

- Confirmed that the paper does not claim that `V_t = 1 - C_t` is a strict Lyapunov function or a Barrier Certificate.
- Added an explicit bounded-claim sentence clarifying that the Mahalanobis-style distance and Semantic Ellipsoid approximation are observability primitives, not control-theoretic stability proofs.
- Added an official available-at URL for the original Mahalanobis 1936 paper while avoiding attaching the DOI of the later reprint to the original citation.
