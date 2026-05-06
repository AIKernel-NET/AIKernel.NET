namespace AIKernel.Dtos.Context;

public readonly struct MaterialBuffer
{
    public IReadOnlyList<ContextFragment> Fragments { get; }
    public MaterialBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

