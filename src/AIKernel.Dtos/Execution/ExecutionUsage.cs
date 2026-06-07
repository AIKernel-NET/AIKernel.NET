namespace AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionUsage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionUsage']" />
public sealed record ExecutionUsage(
    int InputTokens,
    int OutputTokens,
    int TotalTokens);
