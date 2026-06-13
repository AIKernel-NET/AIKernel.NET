using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Deterministic evaluation record for an untrusted candidate action before execution.
/// JA: CandidateActionEvaluation の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.CandidateActionEvaluation']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.CandidateActionEvaluation']" />
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
