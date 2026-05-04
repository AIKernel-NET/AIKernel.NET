namespace AIKernel.Dtos.Rom;

public sealed record CanonicalizedRomDto
{
    public required RomEntityMetadataDto NormalizedMetadata { get; init; }
    public required string NormalizedBody { get; init; }
    public IReadOnlyList<RomRelationDto> NormalizedRelations { get; init; } = new List<RomRelationDto>();
    public IReadOnlyList<ResolvedRomRelationDto> ResolvedRelations { get; init; } = new List<ResolvedRomRelationDto>();
    public required DateTime CanonicalizedAt { get; init; }
}
