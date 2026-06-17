namespace AIKernel.Dtos.Governance;

/// <summary>
/// EN: AttentionObservationStats の契約を定義します。
/// [EN] Documents this public package API member. [JA] AttentionObservationStats の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.AttentionObservationStats']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.AttentionObservationStats']" />
public sealed record AttentionObservationStats(
    DateTime ObservationStartedAt,
    long TotalAttentionConsumed,
    int PollutionDetectionCount,
    float AverageSignalToNoiseRatio,
    float ModelSelectionSuccessRate,
    IReadOnlyDictionary<string, PhaseObservationStats> PhaseStatistics);



