# Paper 12: Canonical Trajectory Governance

This directory contains the Zenodo publication package for:

**AIKernel Canonical Trajectory Governance (CTG): A Three-Council Gateway for Deterministic AI Personality OS Architecture**

- DOI: https://doi.org/10.5281/zenodo.20681895
- Version: v0.1.0
- Publication date: 2026-06-14
- Canonical language: English
- Companion translation: Japanese
- License: CC BY 4.0

The publication files are stored under:

```text
aikernel_canonical_trajectory_governance_ctg_v0_1_0_canonical_en_rev1_final_clean/
```

## Files

- `paper-en.md` / `paper-en.pdf` - canonical English manuscript
- `paper-ja.md` / `paper-ja.pdf` - Japanese companion translation
- `metadata-zenodo.md` - Zenodo metadata
- `CITATION.cff` - citation metadata
- `CHECKSUMS.txt` - package checksum list
- `review-notes.md` - publication review notes

## Repository Alignment

The paper is a published research artifact and must not be edited to match later
implementation details. AIKernel.NET maps the paper into contract-level
interfaces, DTOs, enums, and developer documentation.

Current contract alignment:

- CTG council vocabulary: `AIKernel.Enums.Governance.CouncilKind`
- CTG vote carriers: `AIKernel.Dtos.Governance.CouncilVote`
- CTG vote values: `AIKernel.Enums.Governance.CouncilVoteValue`
- rejection carriers: `AIKernel.Dtos.Governance.RejectReasonInfo`
- canon references: `AIKernel.Dtos.Governance.CanonReference`
- step traces: `AIKernel.Dtos.Governance.StepGovernanceTrace`
- trajectory traces: `AIKernel.Dtos.Governance.GovernanceTrace`
- contract interfaces: `ICouncilEvaluator`, `IDecisionGate`, `ITrajectoryGate`, `IRomGovernanceEngine`

Implementation contracts may be more detailed than the paper sketches. In
particular, enum numeric values in C# are serialization discriminants, not the
mathematical vote weights in the paper. Runtime implementations should map
`CouncilVoteValue` values onto the finite CTG vote table described by the paper.

## Related Developer Documents

- [Canonical Trajectory Governance architecture](../../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1.md)
- [CTG Developer Theory](../../architecture/21.CTG_DEVELOPER_THEORY-v0.1.1.1.md)
- [CTG Contract Model](../../design/CTG_CONTRACT_MODEL-v0.1.1.1.md)
- [CTG Developer Guide](../../operations/CTG_DEVELOPER_GUIDE-v0.1.1.1.md)
- [Paper Implementation Status](../../architecture/PAPER_IMPLEMENTATION_STATUS.md)
