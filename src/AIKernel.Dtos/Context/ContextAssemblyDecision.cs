namespace AIKernel.Dtos.Context;

/// <summary>[EN] Documents this public package API member. [JA] ContextAssemblyDecision を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyDecision']" />
public sealed record ContextAssemblyDecision(
    bool IsAllowed,
    string? Reason = null);
