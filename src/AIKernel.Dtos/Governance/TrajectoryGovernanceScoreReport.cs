using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Replay-compatible score report for one governed semantic trajectory state.
/// JA: TrajectoryGovernanceScoreReport の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.TrajectoryGovernanceScoreReport']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.TrajectoryGovernanceScoreReport']" />
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
