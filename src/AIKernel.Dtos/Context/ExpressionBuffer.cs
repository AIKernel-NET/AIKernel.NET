namespace AIKernel.Dtos.Context;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionBuffer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionBuffer']" />
public readonly struct ExpressionBuffer
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionBuffer.Fragments']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionBuffer.Fragments']" />
    public IReadOnlyList<ExpressionFragment> Fragments { get; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionBuffer.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionBuffer.#ctor']" />
    public ExpressionBuffer(IEnumerable<ExpressionFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ExpressionFragment>()).ToList().AsReadOnly();
}

