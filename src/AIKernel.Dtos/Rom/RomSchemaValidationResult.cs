namespace AIKernel.Dtos.Rom;

public sealed record RomSchemaValidationResult
{
    public required bool IsValid { get; init; }
    public required string Message { get; init; }
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();
}

