namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// EN: Observable semantic state associated with a Semantic IR element.
/// [EN] Documents this public package API member. [JA] SemanticStateSnapshot の公開契約を定義します。
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
