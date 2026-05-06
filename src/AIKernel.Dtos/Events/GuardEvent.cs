namespace AIKernel.Dtos.Events;

/// <summary>
/// GuardEvent の契約を定義します。
/// </summary>
public sealed record GuardEvent(
    string EventId,
    DateTime EventTime,
    string Decision,
    string? Resource,
    string? Action,
    string? Reason,
    IReadOnlyDictionary<string, string>? Metadata);


