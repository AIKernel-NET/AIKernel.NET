using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Replay-compatible score report for one governed semantic trajectory state.
/// </summary>
public sealed record TrajectoryGovernanceScoreReport(
    string ReportId,
    string TrajectoryId,
    string CurrentStateId,
    string? RootGoalId,
    double ConvergenceScore,
    double AnomalyScore,
    double GoalAlignmentScore,
    double RiskScore,
    double UncertaintyScore,
    double RepetitionScore,
    FailClosedDecision Decision,
    string? SafetyBoundaryId,
    IReadOnlyDictionary<string, string> Metadata);
