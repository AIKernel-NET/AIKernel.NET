namespace AIKernel.Dtos.Rom;

/// <summary>
/// RomSchemaValidationResult の契約を定義します。
/// </summary>
public sealed record RomSchemaValidationResult
{
    public required bool IsValid { get; init; }
    public required string Message { get; init; }
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();
}




