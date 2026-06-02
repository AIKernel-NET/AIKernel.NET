namespace AIKernel.Dtos.Rom;

using System.Collections.Immutable;

public sealed record RomSnapshot
{
    public required RomId RomId { get; init; }

    public required string SourcePath { get; init; }

    public required string Body { get; init; }

    public required ImmutableArray<string> SecurityTags { get; init; }

    public required ImmutableArray<RomRelationSnapshot> Relations { get; init; }

    public required RomSignatureSnapshot Signature { get; init; }

    public required DateTimeOffset LoadedAtUtc { get; init; }

    public required ImmutableDictionary<string, string> AdditionalMetadata { get; init; }
}