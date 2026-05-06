namespace AIKernel.Dtos.Context;

public readonly struct ExpressionBuffer
{
    public IReadOnlyList<ExpressionFragment> Fragments { get; }
    public ExpressionBuffer(IEnumerable<ExpressionFragment> fragments)
        => Fragments = (fragments ?? Array.Empty<ExpressionFragment>()).ToList().AsReadOnly();
}

