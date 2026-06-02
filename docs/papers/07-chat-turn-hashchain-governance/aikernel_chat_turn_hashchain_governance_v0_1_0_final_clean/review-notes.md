# Review and Preparation Notes

- Reconstructed the draft as an AIKernel Core Specification.
- Added Security Considerations section 9.5: Cryptographic Agility.
- Defined provider-based algorithm abstraction through ISemanticHasher and IChatTurnSignatureProvider.
- Added algorithm-tagged signature payload format: <algorithm-id>:<base64-signature>.
- Set v0.1.0 implementation guidance to classical baselines such as Ed25519 and ECDSA P-256, while preserving future ML-DSA migration through provider replacement.
- Created English canonical manuscript and Japanese companion translation.
- Added references to RFC 8785, FIPS 180-4, FIPS 202, RFC 8032, FIPS 186-5, FIPS 204, and related AIKernel papers.

## 2026-06-01 Additional Restoration Pass

- Expanded Section 8 with VFS append-only enforcement and ROM Identity anchoring.
- Reworked Section 9 to include length-extension resistance, prompt-injection contamination localization, collision resistance, signature replay protection, chain-break detection, and cryptographic agility.
- Replaced the minimal example with the concrete three-turn canonicalization sequence using H1=0x1619E3AA, H2=0x60192CAF, and H3=0x07743DFF.
- Added explicit verification-process wording that avoids absolute security claims and frames validity under configured cryptographic assumptions.

## 2026-06-01 Final Clean Packaging Pass

- Selected the root-level manuscript set as the latest version and excluded the older duplicated nested directory.
- Renamed the package root to `aikernel_chat_turn_hashchain_governance_v0_1_0_final_clean`.
- Excluded old versions, duplicate files, temporary rendering files, and working files such as `preamble.tex`.
- Synchronized `paper-en.md` and `paper-ja.md` with the final PDF render source.
- Corrected the storage-layer wording from `AIOS VFS` to `AIKernel VFS`.
- Removed the stale `IChatTurnHasher` reference and normalized the cryptographic provider wording to `ISemanticHasher`.
- Updated `metadata-zenodo.md` so the file list and archive name match the final clean Zenodo package.
- Regenerated `paper-en.pdf` and `paper-ja.pdf` from the synchronized Markdown sources.
- Regenerated `CHECKSUMS.txt` after final rendering.


## 2026-06-01 Layout Synchronization Pass

- Corrected PDF clipping in the C# interface section by wrapping long method signatures across multiple lines.
- Added a title-page metadata presentation consistent with the existing AIKernel paper style: title, subtitle, author, affiliation, ORCID, version, date, DOI, and license.
- Re-rendered English and Japanese PDFs from the synchronized Markdown sources.
- Rebuilt `CHECKSUMS.txt` after the final render.
