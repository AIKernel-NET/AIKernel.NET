namespace AIKernel.Dtos.Control;

/// <summary>[EN] Documents this public package API member. [JA] ControlStateSnapshot を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlStateSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlStateSnapshot']" />
public sealed record ControlStateSnapshot(
    string ExecutionId,
    string GraphId,
    string NodeId,
    IReadOnlyDictionary<string, string> Metadata);
