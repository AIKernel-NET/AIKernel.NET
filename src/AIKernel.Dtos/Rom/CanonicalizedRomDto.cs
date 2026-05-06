namespace AIKernel.Dtos.Rom;

/// <summary>
/// CanonicalizedRomDto の契約を定義します。
/// </summary>
public sealed record CanonicalizedRomDto
{
    public required string CanonicalBody { get; init; }
    public required string CanonicalizationVersion { get; init; }
    public IReadOnlyList<RomEntityMetadataDto> Entities { get; init; } = new List<RomEntityMetadataDto>();
    public IReadOnlyList<ResolvedRomRelationDto> Relations { get; init; } = new List<ResolvedRomRelationDto>();
}


