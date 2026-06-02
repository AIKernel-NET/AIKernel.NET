namespace AIKernel.Dtos.Rom;

using System.Collections.Immutable;

public sealed record MarkdownFrontMatterDocument(
    string SourcePath,
    string Body,
    ImmutableDictionary<string, object?> FrontMatter);