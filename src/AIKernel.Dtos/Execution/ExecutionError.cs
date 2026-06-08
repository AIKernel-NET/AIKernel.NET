namespace AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionError']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionError']" />
public sealed record ExecutionError(
    string Code,
    string Message,
    string? Detail = null);
