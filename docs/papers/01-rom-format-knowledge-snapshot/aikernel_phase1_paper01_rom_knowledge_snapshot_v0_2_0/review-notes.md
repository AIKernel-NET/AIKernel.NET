# Review Notes

## Manuscript

AIKernel Phase-1 Paper 01: ROM Format and Knowledge Snapshot Model

## DOI

10.5281/zenodo.20306539

## Applied revisions

1. Converted the draft into a Zenodo-ready bilingual package with English as the canonical manuscript and Japanese as a companion translation.
2. Added formal metadata: DOI, ORCID, license, publication date, version, repository, website, series, and part number.
3. Strengthened the paper's scope: ROM-level identity is defined as canonical operational identity, not unrestricted natural-language semantic equivalence.
4. Replaced over-strong claims such as absolute mathematical guarantees with bounded deterministic claims under explicit canonicalization, resolver, trust-store, and version assumptions.
5. Corrected the security discussion: canonicalization does not prevent cryptographic hash collisions; it rejects representation-level perturbations before hashing and signing.
6. Changed the Hoare Logic discussion from a claim of strict isomorphism to a disciplinary mapping to formal execution semantics.
7. Reworked references to remove vague placeholders and use concrete, citable sources where possible.
8. Generated PDFs with line wrapping for long titles, tables, code blocks, URLs, and technical terms.

## Zenodo recommendations

- Resource type: Publication
- Publication type: Technical note
- Language: English
- Additional language: Japanese
- Preview file: paper-en.pdf
- License: CC BY 4.0
- Version: v0.2.0

## PDF heading numbering fix

The previous PDF build used automatic section numbering while the Markdown headings already contained explicit section numbers. This produced doubled heading numbers in the PDF table of contents and body. The PDFs in this fixed package were regenerated without automatic section numbering. The Markdown source remains unchanged, and the explicit heading numbers are preserved as the canonical manuscript numbering.


## AIKernel YAML standard integration

The Markdown front matter has been updated to follow the AIKernel standard YAML header. The previous publication metadata has been preserved as additional fields where useful for Zenodo, citation, and series management.


## Reference Scope Revision

The reference list was narrowed to match the scope of Paper 01. References primarily belonging to VFS, pre-inference governance, trajectory governance, tensor governance, quantum optimization, or Phase-2 semantic compilation were removed from this paper and should be cited in their corresponding papers. The retained references support ROM-level knowledge identity, canonicalization, Merkle/DAG identity, content addressing, and the general LLM hallucination motivation.

Retained references: Hoare (1969), Cousot & Cousot (1977), Merkle (1988), Git object model, Sikka & Sikka (2025), IPFS Merkle DAG documentation, and Sogawa (2026) ILA.
