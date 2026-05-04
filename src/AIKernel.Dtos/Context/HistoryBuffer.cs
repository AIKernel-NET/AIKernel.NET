namespace AIKernel.Dtos.Context;

public readonly struct HistoryBuffer
{
    public IReadOnlyList<ContextFragment> Fragments { get; }
    public HistoryBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}
