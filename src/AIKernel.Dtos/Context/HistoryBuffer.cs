namespace AIKernel.Dtos.Context;

/// <summary>[EN] Documents this public package API member. [JA] HistoryBuffer を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.HistoryBuffer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.HistoryBuffer']" />
public readonly struct HistoryBuffer
{
    /// <summary>[EN] Documents this public package API member. [JA] Fragments を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.HistoryBuffer.Fragments']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.HistoryBuffer.Fragments']" />
    public IReadOnlyList<ContextFragment> Fragments { get; }
    /// <summary>[EN] Documents this public package API member. [JA] HistoryBuffer を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.HistoryBuffer.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.HistoryBuffer.#ctor']" />
    public HistoryBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

