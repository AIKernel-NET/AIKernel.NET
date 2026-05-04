namespace AIKernel.Dtos.Governance;

public sealed record PhaseObservationStats(
    string PhaseName,
    int ExecutionCount,
    double AverageExecutionTimeMs,
    long TotalAttentionConsumed);
