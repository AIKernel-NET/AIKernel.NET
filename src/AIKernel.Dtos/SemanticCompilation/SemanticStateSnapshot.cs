namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Observable semantic state associated with a Semantic IR element.
/// </summary>
public sealed record SemanticStateSnapshot(
    string StateId,
    IReadOnlyList<double> CenterVector,
    IReadOnlyList<double> UncertaintyDiagonal,
    string? EmbeddingModelId,
    string? StateHash,
    IReadOnlyDictionary<string, string> Metadata);
