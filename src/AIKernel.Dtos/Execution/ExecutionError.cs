namespace AIKernel.Dtos.Execution;

/// <summary>[EN] Documents this public package API member. [JA] ExecutionError を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionError']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionError']" />
public sealed record ExecutionError(
    string Code,
    string Message,
    string? Detail = null);
