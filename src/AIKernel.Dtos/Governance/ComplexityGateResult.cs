using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Admission decision emitted by a computational complexity gate.
/// JA: ComplexityGateResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.ComplexityGateResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.ComplexityGateResult']" />
public sealed record ComplexityGateResult(
    AdmissibilityDecisionKind Decision,
    string? RecommendedSolver,
    IReadOnlyList<string> DecompositionHints,
    string? Reason,
    string? EvidenceHash,
    IReadOnlyDictionary<string, string> Metadata);
