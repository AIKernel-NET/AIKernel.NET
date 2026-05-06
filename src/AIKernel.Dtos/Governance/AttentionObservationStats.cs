namespace AIKernel.Dtos.Governance;

/// <summary>
/// AttentionObservationStats の契約を定義します。
/// </summary>
public sealed record AttentionObservationStats(
    DateTime ObservationStartedAt,
    long TotalAttentionConsumed,
    int PollutionDetectionCount,
    float AverageSignalToNoiseRatio,
    float ModelSelectionSuccessRate,
    IReadOnlyDictionary<string, PhaseObservationStats> PhaseStatistics);



