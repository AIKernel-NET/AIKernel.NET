# AIKernel HATL Technical Appendices and Repository Specifications

This archive is **Part II** of the three-part Zenodo release:

**AIKernel Hash-Anchored Trust Layer (HATL): A Hybrid Symmetric Ledger with Hash-Based Public Anchors**

- DOI: https://doi.org/10.5281/zenodo.20502685
- Version: v1.0
- Author: Takuya Sogawa
- ORCID: https://orcid.org/0009-0009-7499-2595
- Affiliation: AIKernel Project

## Purpose

This appendix archive defines the recommended repository topology, schemas, interface sketches, smart-contract specimen, test scaffolding, and implementation notes for a future HATL reference implementation. The rev2 package also records the required .NET secret-erasure discipline, fail-closed handling for `Indeterminate` governance decisions, and zero-knowledge public-anchor extension path.

## Licensing

- Documents and explanatory specifications: CC-BY-4.0
- Code specimens, schemas, and source skeletons: Apache-2.0

## Contents

```text
PART_II_Appendices_and_Repo/
  README.md
  CITATION.cff
  LICENSE-DOCUMENTS-CC-BY-4.0.txt
  LICENSE-CODE-APACHE-2.0.txt
  docs/HATL_SPEC.md
  docs/REPOSITORY_SPEC.md
  schemas/hatl-block-mac.schema.json
  schemas/hatl-public-anchor.schema.json
  schemas/hatl-digital-deed.schema.json
  contracts/HatlGovernance.sol
  src/AIKernel.Hatl.Core/IHatlKeyRatchet.cs
  src/AIKernel.Hatl.Core/ISymmetricLedgerProvider.cs
  src/AIKernel.Hatl.Anchor/IPublicAnchorEngine.cs
  tests/BenchmarkProfiles.json
  examples/hatl-simulator-prompt.json
```
