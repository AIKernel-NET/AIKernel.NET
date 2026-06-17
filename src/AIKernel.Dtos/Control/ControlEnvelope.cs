namespace AIKernel.Dtos.Control;

/// <summary>[EN] Documents this public package API member. [JA] ControlEnvelope を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlEnvelope']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlEnvelope']" />
public sealed record ControlEnvelope(
    string ControlId,
    string Operation,
    IReadOnlyDictionary<string, string> Metadata);
