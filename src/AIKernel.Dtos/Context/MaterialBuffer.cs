namespace AIKernel.Dtos.Context;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialBuffer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialBuffer']" />
public readonly struct MaterialBuffer
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialBuffer.Fragments']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialBuffer.Fragments']" />
    public IReadOnlyList<ContextFragment> Fragments { get; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.MaterialBuffer.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.MaterialBuffer.#ctor']" />
    public MaterialBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

