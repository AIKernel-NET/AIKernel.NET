namespace AIKernel.Dtos.Control;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlExecutionRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlExecutionRequest']" />
public sealed record ControlExecutionRequest(
    string ExecutionId,
    IReadOnlyDictionary<string, string> Metadata);
