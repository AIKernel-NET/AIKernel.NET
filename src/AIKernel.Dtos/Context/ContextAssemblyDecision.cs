namespace AIKernel.Dtos.Context;

/// <summary>EN: Documentation for public API. JA: ContextAssemblyDecision を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyDecision']" />
public sealed record ContextAssemblyDecision(
    bool IsAllowed,
    string? Reason = null);
