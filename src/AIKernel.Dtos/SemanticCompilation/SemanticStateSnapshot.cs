namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Observable semantic state associated with a Semantic IR element.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.SemanticStateSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.SemanticCompilation.SemanticStateSnapshot']" />
public sealed record SemanticStateSnapshot(
    string StateId,
    IReadOnlyList<double> CenterVector,
    IReadOnlyList<double> UncertaintyDiagonal,
    string? EmbeddingModelId,
    string? StateHash,
    IReadOnlyDictionary<string, string> Metadata);
