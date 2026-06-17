namespace AIKernel.Dtos.Control;

/// <summary>[EN] Documents this public package API member. [JA] ControlExecutionResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlExecutionResult']" />
public sealed record ControlExecutionResult(
    string ExecutionId,
    string Status,
    IReadOnlyDictionary<string, string> Metadata);
