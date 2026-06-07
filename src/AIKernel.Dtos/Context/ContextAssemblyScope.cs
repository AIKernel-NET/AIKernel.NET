namespace AIKernel.Dtos.Context;

using System.Collections.Immutable;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyScope']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextAssemblyScope']" />
public sealed record ContextAssemblyScope
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Purpose']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Purpose']" />
    public required string Purpose { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Capabilities']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.Capabilities']" />
    public required ImmutableArray<string> Capabilities { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextAssemblyScope.string']" />
    public required ImmutableDictionary<string, string> Metadata { get; init; }
}
