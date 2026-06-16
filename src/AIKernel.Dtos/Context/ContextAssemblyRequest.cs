namespace AIKernel.Dtos.Context;

using AIKernel.Dtos.Rom;
using System.Collections.Immutable;

/// <summary>[EN] Documents this public package API member. [JA] ContextAssemblyRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyRequest']" />
public sealed record ContextAssemblyRequest(
    RomId RootRomId,
    string? ParentSnapshotId,
    ContextAssemblyScope Scope)
{
    /// <summary>[EN] Documents this public package API member. [JA] MaxDepth を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyRequest.MaxDepth']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyRequest.MaxDepth']" />
    public int MaxDepth { get; init; } = 16;

    /// <summary>[EN] Documents this public package API member. [JA] RelationKindsToFollow を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyRequest.RelationKindsToFollow']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyRequest.RelationKindsToFollow']" />
    public ImmutableHashSet<string> RelationKindsToFollow { get; init; }
        = ImmutableHashSet<string>.Empty;
}
