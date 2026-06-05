using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Admission decision emitted by a computational complexity gate.
/// </summary>
public sealed record ComplexityGateResult(
    AdmissibilityDecisionKind Decision,
    string? RecommendedSolver,
    IReadOnlyList<string> DecompositionHints,
    string? Reason,
    string? EvidenceHash,
    IReadOnlyDictionary<string, string> Metadata);
