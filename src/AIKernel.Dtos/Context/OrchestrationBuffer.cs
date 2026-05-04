namespace AIKernel.Dtos.Context;

public readonly struct OrchestrationBuffer
{
    public IReadOnlyList<ContextFragment> Fragments { get; }
    public OrchestrationBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}
