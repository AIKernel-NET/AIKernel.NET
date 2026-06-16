namespace AIKernel.Dtos.Control;

/// <summary>EN: Documentation for public API. JA: ControlStateSnapshot を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlStateSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlStateSnapshot']" />
public sealed record ControlStateSnapshot(
    string ExecutionId,
    string GraphId,
    string NodeId,
    IReadOnlyDictionary<string, string> Metadata);
