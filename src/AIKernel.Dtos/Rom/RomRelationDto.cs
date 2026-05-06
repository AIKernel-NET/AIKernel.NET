namespace AIKernel.Dtos.Rom;

/// <summary>
/// RomRelationDto の契約を定義します。
/// </summary>
public sealed record RomRelationDto
{
    public required string RelationType { get; init; }
    public required string RelationName { get; init; }
    public string? TargetReference { get; init; }
    public double? NumericValue { get; init; }
    public string? TextValue { get; init; }
}



