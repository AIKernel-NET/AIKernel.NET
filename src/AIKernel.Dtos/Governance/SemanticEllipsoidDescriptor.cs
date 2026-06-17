namespace AIKernel.Dtos.Governance;

/// <summary>
/// EN: Contract-only semantic region used by trajectory governance scoring.
/// [EN] Documents this public package API member. [JA] SemanticEllipsoidDescriptor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.SemanticEllipsoidDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.SemanticEllipsoidDescriptor']" />
public sealed record SemanticEllipsoidDescriptor(
    string EllipsoidId,
    string StateId,
    IReadOnlyList<double> CenterVector,
    IReadOnlyList<double> DiagonalCovariance,
    string? EmbeddingModel,
    string? ApproximationKind,
    IReadOnlyDictionary<string, string> Metadata);
