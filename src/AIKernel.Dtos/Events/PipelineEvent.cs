namespace AIKernel.Dtos.Events;

/// <summary>
/// PipelineEvent の契約を定義します。
/// </summary>
public sealed record PipelineEvent(
    string EventId,
    string PipelineId,
    string StageName,
    DateTime EventTime,
    string Status,
    long DurationMs,
    string? Description,
    IReadOnlyDictionary<string, string>? Metadata);


