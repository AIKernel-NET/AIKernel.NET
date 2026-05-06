namespace AIKernel.Dtos.Rom;

/// <summary>
/// ResolvedRomRelationDto の契約を定義します。
/// </summary>
public sealed record ResolvedRomRelationDto
{
    public required string OriginalReference { get; init; }
    public required string FullyQualifiedId { get; init; }
    public required string RelationType { get; init; }
}



