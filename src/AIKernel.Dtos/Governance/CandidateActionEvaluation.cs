using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Deterministic evaluation record for an untrusted candidate action before execution.
/// </summary>
public sealed record CandidateActionEvaluation(
    string EvaluationId,
    string TrajectoryId,
    string CandidateActionId,
    string? CandidateActionKind,
    double SemanticAlignmentScore,
    double RiskScore,
    double RankingScore,
    bool ExcludedByRiskThreshold,
    FailClosedDecision Decision,
    string? Reason,
    IReadOnlyDictionary<string, string> Metadata);
