namespace AIKernel.Dtos.Events;

/// <summary>
/// ExecutionEvent の契約を定義します。
/// </summary>
public sealed record ExecutionEvent(
    string EventId,
    string ExecutionId,
    string FunctionName,
    DateTime StartTime,
    DateTime? EndTime,
    string Status,
    string? Result,
    string? ErrorMessage,
    IReadOnlyDictionary<string, string>? Metadata);


