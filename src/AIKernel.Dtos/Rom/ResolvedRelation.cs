namespace AIKernel.Dtos.Rom;

public sealed record ResolvedRelation
{
    public required string OriginalReference { get; init; }
    public required string ResolvedId { get; init; }
    public required string RelationType { get; init; }
}

