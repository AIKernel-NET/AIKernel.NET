namespace AIKernel.Dtos.Rom;

public sealed record ResolvedRomRelationDto
{
    public required string OriginalReference { get; init; }
    public required string FullyQualifiedId { get; init; }
    public required string RelationType { get; init; }
}
