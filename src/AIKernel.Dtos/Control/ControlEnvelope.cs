namespace AIKernel.Dtos.Control;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlEnvelope']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlEnvelope']" />
public sealed record ControlEnvelope(
    string ControlId,
    string Operation,
    IReadOnlyDictionary<string, string> Metadata);
