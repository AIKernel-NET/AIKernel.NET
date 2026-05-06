namespace AIKernel.Dtos.Rom;

/// <summary>
/// ResolvedRelation の契約を定義します。
/// </summary>
public sealed record ResolvedRelation
{
    public required string OriginalReference { get; init; }
    public required string ResolvedId { get; init; }
    public required string RelationType { get; init; }
}




