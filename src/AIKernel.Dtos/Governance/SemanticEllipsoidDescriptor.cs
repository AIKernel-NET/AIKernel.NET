namespace AIKernel.Dtos.Governance;

/// <summary>
/// Contract-only semantic region used by trajectory governance scoring.
/// </summary>
public sealed record SemanticEllipsoidDescriptor(
    string EllipsoidId,
    string StateId,
    IReadOnlyList<double> CenterVector,
    IReadOnlyList<double> DiagonalCovariance,
    string? EmbeddingModel,
    string? ApproximationKind,
    IReadOnlyDictionary<string, string> Metadata);
