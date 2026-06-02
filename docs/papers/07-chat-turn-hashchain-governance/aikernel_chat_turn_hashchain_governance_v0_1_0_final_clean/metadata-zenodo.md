# Zenodo Metadata Draft

## Basic Information

- Resource type: Publication
- Publication type: Technical note
- Title: AIKernel Core Specification: Chat-Turn HashChain Governance
- Subtitle: Deterministic Chat-Turn Identity and Replayable Causal Trace Model for AIKernel.NET
- Version: v0.1.0
- Publication date: 2026-06-01
- DOI: 10.5281/zenodo.20471345
- Creator: Sogawa, Takuya
- ORCID: https://orcid.org/0009-0009-7499-2595
- Affiliation: AIKernel Project
- License: Creative Commons Attribution 4.0 International (CC BY 4.0)
- Language: English
- Additional language: Japanese

## Description

This technical note defines Chat-Turn HashChain Governance as an AIKernel Core specification for converting chat-based interaction histories into causally linked, tamper-evident, and replayable semantic execution records. It specifies deterministic canonicalization, previous-hash binding, optional turn signatures, fail-closed validation, quarantine behavior, deterministic replay, VFS/ROM persistence, and cryptographic agility.

The specification is algorithm-agile. Hashing and signing are routed through provider contracts such as ISemanticHasher and IChatTurnSignatureProvider, allowing deployments to use classical algorithms such as Ed25519 or ECDSA P-256 in v0.1.0 while preserving a migration path toward post-quantum providers such as ML-DSA when operationally appropriate.

The English manuscript is the canonical version. The Japanese manuscript is included as a companion translation.

## Files

- paper-en.pdf (Preview)
- paper-ja.pdf
- paper-en.md
- paper-ja.md
- metadata-zenodo.md
- review-notes.md
- CITATION.cff
- .zenodo.json
- CHECKSUMS.txt

## Archive Name

- aikernel_chat_turn_hashchain_governance_v0_1_0_final_clean.zip

## 2026-06-01 Layout Synchronization Pass

- Regenerated both PDFs after correcting clipped C# interface signatures.
- Aligned title-page metadata with the AIKernel paper style: title, subtitle, author, affiliation, ORCID, version, date, DOI, and license.
- Updated Markdown frontmatter to include subtitle, maintainer, author, ORCID, affiliation, published date, and updated date.
- Verified that `paper-en.md` and `paper-ja.md` are synchronized with the regenerated PDF sources.
