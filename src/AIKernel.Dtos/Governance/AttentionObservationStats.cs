namespace AIKernel.Dtos.Governance;

public sealed record AttentionObservationStats(
    DateTime ObservationStartedAt,
    long TotalAttentionConsumed,
    int PollutionDetectionCount,
    float AverageSignalToNoiseRatio,
    float ModelSelectionSuccessRate,
    IReadOnlyDictionary<string, PhaseObservationStats> PhaseStatistics);
