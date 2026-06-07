namespace AIKernel.Dtos.Governance;

/// <summary>
/// Contract-only semantic region used by trajectory governance scoring.
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
