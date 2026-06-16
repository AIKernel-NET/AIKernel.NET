namespace AIKernel.Dtos.Execution;

/// <summary>[EN] Documents this public package API member. [JA] ExecutionUsage を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionUsage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionUsage']" />
public sealed record ExecutionUsage(
    int InputTokens,
    int OutputTokens,
    int TotalTokens);
