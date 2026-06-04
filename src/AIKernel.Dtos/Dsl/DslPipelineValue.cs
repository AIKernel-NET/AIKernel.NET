namespace AIKernel.Dtos.Dsl;

using System.Collections.Immutable;

public sealed record DslPipelineValue(
    IReadOnlyDictionary<string, string> Data)
{
    public static DslPipelineValue Empty { get; } =
        new(ImmutableDictionary<string, string>.Empty);
}
