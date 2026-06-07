namespace AIKernel.Dtos.Dsl;

using System.Collections.Immutable;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineValue']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineValue']" />
public sealed record DslPipelineValue(
    IReadOnlyDictionary<string, string> Data);
