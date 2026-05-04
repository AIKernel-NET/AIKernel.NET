namespace AIKernel.Abstractions.Rom;

public sealed record RomTypeConsistencyResult
{
    public required bool IsConsistent { get; init; }
    public required string Message { get; init; }
    public IReadOnlyList<string> Inconsistencies { get; init; } = new List<string>();
    public IReadOnlyList<string> MissingProperties { get; init; } = new List<string>();
}
