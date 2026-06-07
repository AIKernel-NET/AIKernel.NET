namespace AIKernel.Dtos.Rom;

using System.Collections.Immutable;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.MarkdownFrontMatterDocument']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.MarkdownFrontMatterDocument']" />
public sealed record MarkdownFrontMatterDocument(
    string SourcePath,
    string Body,
    ImmutableDictionary<string, object?> FrontMatter);