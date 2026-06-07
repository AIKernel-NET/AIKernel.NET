namespace AIKernel.Dtos.Context;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyDecision']" />
public sealed record ContextAssemblyDecision(
    bool IsAllowed,
    string? Reason = null);
