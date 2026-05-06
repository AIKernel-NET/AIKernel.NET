namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Environment の契約を定義します。
/// </summary>
public sealed record Environment(
    string EnvironmentId,
    string Name,
    string? Region,
    IReadOnlyDictionary<string, string>? Variables,
    IReadOnlyDictionary<string, string>? Configuration,
    bool IsProduction);


