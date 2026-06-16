namespace AIKernel.Dtos.Execution;

/// <summary>EN: Documentation for public API. JA: ExecutionUsage を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionUsage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionUsage']" />
public sealed record ExecutionUsage(
    int InputTokens,
    int OutputTokens,
    int TotalTokens);
