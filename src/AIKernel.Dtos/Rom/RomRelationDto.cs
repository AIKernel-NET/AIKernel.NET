namespace AIKernel.Dtos.Rom;

public sealed record RomRelationDto
{
    public required string RelationType { get; init; }
    public required string RelationName { get; init; }
    public string? TargetReference { get; init; }
    public double? NumericValue { get; init; }
    public string? TextValue { get; init; }
}
