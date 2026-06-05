using AIKernel.Enums;

namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Replay-addressable candidate movement from one Semantic IR/state artifact to another.
/// </summary>
public sealed record SemanticTransitionDescriptor(
    string TransitionId,
    string FromIrId,
    string ToIrId,
    string? FromStateId,
    string? ToStateId,
    string? GovernedCircuitId,
    AdmissibilityDecisionKind? AdmissionDecision,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
