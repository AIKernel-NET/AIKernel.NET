# Paper 12: Canonical Trajectory Governance

このディレクトリには、次の論文の Zenodo publication package が含まれます。

**AIKernel Canonical Trajectory Governance (CTG): A Three-Council Gateway for Deterministic AI Personality OS Architecture**

- DOI: https://doi.org/10.5281/zenodo.20681895
- Version: v0.1.0
- Publication date: 2026-06-14
- Canonical language: English
- Companion translation: Japanese
- License: CC BY 4.0

publication files は次のディレクトリに保存されています。

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

この論文は公開済みの research artifact であり、後続の実装詳細に合わせて本文を編集してはいけません。
AIKernel.NET は、論文で説明された考え方を contract-level interfaces、DTOs、enums、developer documentation に対応付けます。

現在の contract alignment は次の通りです。

- CTG council vocabulary: `AIKernel.Enums.Governance.CouncilKind`
- CTG vote carriers: `AIKernel.Dtos.Governance.CouncilVote`
- CTG vote values: `AIKernel.Enums.Governance.CouncilVoteValue`
- rejection carriers: `AIKernel.Dtos.Governance.RejectReasonInfo`
- canon references: `AIKernel.Dtos.Governance.CanonReference`
- step traces: `AIKernel.Dtos.Governance.StepGovernanceTrace`
- trajectory traces: `AIKernel.Dtos.Governance.GovernanceTrace`
- contract interfaces: `ICouncilEvaluator`, `IDecisionGate`, `ITrajectoryGate`, `IRomGovernanceEngine`

Implementation contracts は、論文で示した sketch より詳細な場合があります。
特に、C# enum の numeric values は serialization discriminants であり、論文中の mathematical vote weights ではありません。
Runtime implementations は、`CouncilVoteValue` values を論文で説明された finite CTG vote table へ対応付ける必要があります。

## Related Developer Documents

- [Canonical Trajectory Governance architecture](../../architecture/20.CANONICAL_TRAJECTORY_GOVERNANCE-v0.1.1.1-jp.md)
- [CTG Developer Theory](../../architecture/21.CTG_DEVELOPER_THEORY-v0.1.1.1-jp.md)
- [CTG Contract Model](../../design/CTG_CONTRACT_MODEL-v0.1.1.1-jp.md)
- [CTG Developer Guide](../../operations/CTG_DEVELOPER_GUIDE-v0.1.1.1-jp.md)
- [Paper Implementation Status](../../architecture/PAPER_IMPLEMENTATION_STATUS-jp.md)
