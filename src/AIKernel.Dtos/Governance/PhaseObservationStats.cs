namespace AIKernel.Dtos.Governance;

/// <summary>
/// PhaseObservationStats の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.PhaseObservationStats']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.PhaseObservationStats']" />
public sealed record PhaseObservationStats(
    string PhaseName,
    int ExecutionCount,
    double AverageExecutionTimeMs,
    long TotalAttentionConsumed);



