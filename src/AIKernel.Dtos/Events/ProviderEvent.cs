namespace AIKernel.Dtos.Events;

/// <summary>
/// ProviderEvent の契約を定義します。
/// </summary>
public sealed record ProviderEvent(
    string EventId,
    DateTime EventTime,
    string ProviderId,
    string EventType,
    string? Description,
    bool Success,
    string? ErrorMessage,
    IReadOnlyDictionary<string, string>? Metadata);


