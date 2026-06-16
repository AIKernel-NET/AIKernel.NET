namespace AIKernel.Dtos.Control;

/// <summary>EN: Documentation for public API. JA: ControlPolicyEvaluation を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlPolicyEvaluation']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Control.ControlPolicyEvaluation']" />
public sealed record ControlPolicyEvaluation(
    bool Allowed,
    string Code,
    string Reason);
