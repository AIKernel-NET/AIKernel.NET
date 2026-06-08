using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Fail-closed decision and attached requirements emitted by a critical operation gate.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.CriticalOperationGateResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.CriticalOperationGateResult']" />
public sealed record CriticalOperationGateResult(
    AdmissibilityDecisionKind Decision,
    IReadOnlyList<CriticalOperationRequirement> Requirements,
    string? Reason,
    string? EvidenceHash,
    IReadOnlyDictionary<string, string> Metadata);
