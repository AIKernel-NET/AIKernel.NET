# AIKernel-HATL-Technical-Notes-v1.0

**Title:** AIKernel Hash-Anchored Trust Layer (HATL): A Hybrid Symmetric Ledger with Hash-Based Public Anchors  
**Subtitle:** Symmetric Ratcheted Micro-Ledgers for Securing Stochastic AI Inference Tracks  
**Version:** v1.0  
**DOI:** https://doi.org/10.5281/zenodo.20502685  
**Author:** Takuya Sogawa  
**ORCID:** https://orcid.org/0009-0009-7499-2595  
**Affiliation:** AIKernel Project  

## Package Structure

This release is intentionally organized as a three-part publication package.

```text
AIKernel-HATL-Technical-Notes-v1.0/
  PART_I_Full_Manuscript.pdf
  PART_II_Appendices_and_Repo.zip
  PART_III_Japanese_Translation.pdf
  README.md
  CITATION.cff
  metadata-zenodo.md
  .zenodo.json
  LICENSE-DOCUMENTS-CC-BY-4.0.txt
  LICENSE-CODE-APACHE-2.0.txt
  CHECKSUMS.txt
```

## Parts

- **Part I:** Full English Manuscript. This is the canonical manuscript.
- **Part II:** Technical Appendices and Repository Specifications. This contains repository layout, schemas, interface sketches, contract specimens, tests, and implementation notes.
- **Part III:** Technical Japanese Translation. This is a companion translation. If interpretation differs, Part I is canonical.

## License Policy

- Documents, manuscript text, diagrams, metadata, and explanatory notes are licensed under **Creative Commons Attribution 4.0 International (CC-BY-4.0)**.
- Code specimens, schemas, interface sketches, and smart-contract examples are licensed under **Apache License 2.0 (Apache-2.0)**.

## Release and DOI Strategy

This package corresponds to the v1.0 major release. Zenodo assigns a DOI to this release. Future revisions should be issued as new Zenodo versions with their own versioned records, while preserving citation linkage to the v1.0 DOI.


## Revision Notes

- **rev2 package:** incorporates review fixes on C#/.NET secret-erasure realism, fail-closed handling for `Indeterminate` governance outcomes, and a zero-knowledge public-anchor extension path.
