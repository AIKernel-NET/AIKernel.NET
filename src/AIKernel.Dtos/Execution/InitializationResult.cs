namespace AIKernel.Dtos.Execution;

/// <summary>
/// InitializationResult の契約を定義します。
/// </summary>
public sealed record InitializationResult
{
    public required bool IsInitialized { get; init; }
    public required string Message { get; init; }
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();
    public string? PreExecutionContextHash { get; init; }
}




