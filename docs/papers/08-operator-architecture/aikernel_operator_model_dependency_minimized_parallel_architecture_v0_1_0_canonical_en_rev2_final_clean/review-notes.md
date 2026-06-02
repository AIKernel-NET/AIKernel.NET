# Review Notes

## Package

- Name: `aikernel_operator_model_dependency_minimized_parallel_architecture_v0_1_0_canonical_en_rev1_final_clean`
- DOI: `10.5281/zenodo.20493017`
- Version: `v0.1.0`
- Date: `2026-06-02`
- Canonical manuscript: English
- Companion translation: Japanese

## Editorial Changes

1. The original strong title using dependency-zero wording was revised to a more publication-safe form:
   - English: `A Dependency-Minimized Parallel Computing Architecture Based on the AIKernel Operator Model`
   - Japanese: `AIKernel Operatorモデルによる依存性最小化並列計算`
2. The term "dependency-minimized" is defined narrowly as the absence of input-to-input semantic data dependency inside the Operator contract.
3. Claims about unlimited scaling, supercomputer-class performance, and complete linear scaling were weakened.
4. A non-claims section was added to clarify that the note does not claim superiority over existing prime generation or primality testing methods.
5. English was made the canonical manuscript and Japanese was retained as a companion translation.
6. Metadata, citation data, Zenodo JSON, PDFs, and checksums were synchronized.

## Final Public Files

- `paper-en.pdf`
- `paper-ja.pdf`
- `paper-en.md`
- `paper-ja.md`
- `metadata-zenodo.md`
- `review-notes.md`
- `CITATION.cff`
- `.zenodo.json`
- `CHECKSUMS.txt`

## Rev.1 Correction

- Fixed the Section 4 heading in both English and Japanese manuscripts so that the final layer renders as `C#`, not `C`, in PDF output.
- The Markdown heading uses an escaped number sign (`C\#`) to prevent the PDF conversion pipeline from stripping the `#` character in ATX headings.
- PDFs were regenerated and rechecked after the correction.


## Revision note - rev2

- Re-rendered `paper-en.pdf` after fixing clipped reference lines in the English PDF.
- References now display DOI values on separate lines to avoid right-margin clipping.
- Added LaTeX line-breaking safeguards (`xurl`, `\sloppy`, and `\emergencystretch`) in the English Markdown source.
