namespace AIKernel.Dtos.Context;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.OrchestrationBuffer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.OrchestrationBuffer']" />
public readonly struct OrchestrationBuffer
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationBuffer.Fragments']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationBuffer.Fragments']" />
    public IReadOnlyList<ContextFragment> Fragments { get; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.OrchestrationBuffer.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.OrchestrationBuffer.#ctor']" />
    public OrchestrationBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

