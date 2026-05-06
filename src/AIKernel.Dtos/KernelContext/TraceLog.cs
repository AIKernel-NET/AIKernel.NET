namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// TraceLog の契約を定義します。
/// </summary>
public sealed record TraceLog(
    string Level,
    string Message,
    DateTime Timestamp,
    IReadOnlyDictionary<string, string>? Data);


