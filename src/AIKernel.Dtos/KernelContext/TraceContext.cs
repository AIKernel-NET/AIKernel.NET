namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// TraceContext の契約を定義します。
/// </summary>
public sealed record TraceContext(
    string TraceId,
    string? SpanId,
    string? ParentSpanId,
    DateTime StartTime,
    DateTime? EndTime,
    IReadOnlyDictionary<string, string>? Tags,
    IReadOnlyList<TraceLog>? Logs);


