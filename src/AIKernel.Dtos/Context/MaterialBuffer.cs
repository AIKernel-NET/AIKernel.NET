namespace AIKernel.Dtos.Context;

/// <summary>EN: Documentation for public API. JA: MaterialBuffer を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialBuffer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialBuffer']" />
public readonly struct MaterialBuffer
{
    /// <summary>EN: Documentation for public API. JA: Fragments を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialBuffer.Fragments']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialBuffer.Fragments']" />
    public IReadOnlyList<ContextFragment> Fragments { get; }
    /// <summary>EN: Documentation for public API. JA: MaterialBuffer を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.MaterialBuffer.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.MaterialBuffer.#ctor']" />
    public MaterialBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

