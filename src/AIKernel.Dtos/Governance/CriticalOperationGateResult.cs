using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Fail-closed decision and attached requirements emitted by a critical operation gate.
/// </summary>
public sealed record CriticalOperationGateResult(
    AdmissibilityDecisionKind Decision,
    IReadOnlyList<CriticalOperationRequirement> Requirements,
    string? Reason,
    string? EvidenceHash,
    IReadOnlyDictionary<string, string> Metadata);
