namespace AIKernel.Dtos.Rom;

public sealed record CanonicalizedRomDocument
{
    public required string NormalizedEntityId { get; init; }
    public required IReadOnlyDictionary<string, string> NormalizedMetadata { get; init; }
    public required string NormalizedBody { get; init; }
    public IReadOnlyList<ResolvedRelation> ResolvedRelations { get; init; } = new List<ResolvedRelation>();
    public required DateTime CanonicalizedAt { get; init; }
}

