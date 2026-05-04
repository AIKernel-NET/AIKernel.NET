namespace AIKernel.Dtos.Context;

public readonly struct OrchestrationBuffer
{
    public IReadOnlyList<ContextFragment> Fragments { get; }
    public OrchestrationBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

public readonly struct ExpressionBuffer
{
    public IReadOnlyList<ExpressionFragment> Fragments { get; }
    public ExpressionBuffer(IEnumerable<ExpressionFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ExpressionFragment>()).ToList().AsReadOnly();
}

public readonly struct MaterialBuffer
{
    public IReadOnlyList<ContextFragment> Fragments { get; }
    public MaterialBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}

public readonly struct HistoryBuffer
{
    public IReadOnlyList<ContextFragment> Fragments { get; }
    public HistoryBuffer(IEnumerable<ContextFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ContextFragment>()).ToList().AsReadOnly();
}
