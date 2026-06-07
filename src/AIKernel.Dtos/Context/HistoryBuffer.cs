namespace AIKernel.Dtos.Context;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.HistoryBuffer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.HistoryBuffer']" />
public readonly struct HistoryBuffer
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.HistoryBuffer.Fragments']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.HistoryBuffer.Fragments']" />
    public IReadOnlyList<ContextFragment> Fragments { get; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.HistoryBuffer.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.HistoryBuffer.#ctor']" />
    public HistoryBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

