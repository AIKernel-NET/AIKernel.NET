namespace AIKernel.Dtos.Context;

using System.Collections.Immutable;

public sealed record ContextAssemblyScope
{
    public required string Purpose { get; init; }

    public required ImmutableArray<string> Capabilities { get; init; }

    public required ImmutableDictionary<string, string> Metadata { get; init; }
}
