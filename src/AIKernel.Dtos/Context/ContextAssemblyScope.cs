namespace AIKernel.Dtos.Context;

using System.Collections.Immutable;

/// <summary>EN: Documentation for public API. JA: ContextAssemblyScope を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyScope']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyScope']" />
public sealed record ContextAssemblyScope
{
    /// <summary>EN: Documentation for public API. JA: Purpose を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Purpose']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Purpose']" />
    public required string Purpose { get; init; }

    /// <summary>EN: Documentation for public API. JA: Capabilities を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Capabilities']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Capabilities']" />
    public required ImmutableArray<string> Capabilities { get; init; }

    /// <summary>EN: Documentation for public API. JA: Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.string']" />
    public required ImmutableDictionary<string, string> Metadata { get; init; }
}
