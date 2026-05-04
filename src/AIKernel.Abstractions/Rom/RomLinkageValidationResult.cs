namespace AIKernel.Abstractions.Rom;

public sealed record RomLinkageValidationResult
{
    public required bool AllLinksResolvable { get; init; }
    public required string Message { get; init; }
    public IReadOnlyList<string> UnresolvedLinks { get; init; } = new List<string>();
}
