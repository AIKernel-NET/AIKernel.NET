namespace AIKernel.Dtos.Context;

/// <summary>EN: Documentation for public API. JA: ExpressionBuffer を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionBuffer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionBuffer']" />
public readonly struct ExpressionBuffer
{
    /// <summary>EN: Documentation for public API. JA: Fragments を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionBuffer.Fragments']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionBuffer.Fragments']" />
    public IReadOnlyList<ExpressionFragment> Fragments { get; }
    /// <summary>EN: Documentation for public API. JA: ExpressionBuffer を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionBuffer.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionBuffer.#ctor']" />
    public ExpressionBuffer(IEnumerable<ExpressionFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ExpressionFragment>()).ToList().AsReadOnly();
}

