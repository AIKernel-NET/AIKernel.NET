namespace AIKernel.Dtos.Execution;

/// <summary>EN: Documentation for public API. JA: ModelMessage を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModelMessage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModelMessage']" />
public sealed record ModelMessage(
    string Role,
    string Content);
