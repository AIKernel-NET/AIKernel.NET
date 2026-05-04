namespace AIKernel.Dtos.Rom;

public sealed record ResolvableEntity
{
    public required string Id { get; init; }
    public required string Type { get; init; }
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

