namespace AIKernel.Dtos.Governance;

/// <summary>
/// PhaseObservationStats の契約を定義します。
/// </summary>
public sealed record PhaseObservationStats(
    string PhaseName,
    int ExecutionCount,
    double AverageExecutionTimeMs,
    long TotalAttentionConsumed);



