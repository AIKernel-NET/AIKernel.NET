namespace AIKernel.Dtos.Rom;

public sealed record RomEntityMetadataDto
{
    public required string EntityId { get; init; }
    public required string EntityType { get; init; }
    public required string Version { get; init; }
    public IReadOnlyDictionary<string, object> AdditionalMetadata { get; init; } = new Dictionary<string, object>();
}
