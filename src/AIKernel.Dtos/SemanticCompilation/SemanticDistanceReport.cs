namespace AIKernel.Dtos.SemanticCompilation;

/// <summary>
/// Replayable report for heterogeneous Semantic IR / governed circuit compatibility distance.
/// </summary>
public sealed record SemanticDistanceReport(
    string ReportId,
    string SemanticIrId,
    string GovernedCircuitId,
    double GraphDistance,
    double TransitionDistance,
    double ConstraintDistance,
    double BoundaryInvariantDistance,
    double? SemanticStateDistance,
    double CompositeScore,
    string? DistanceProfileId,
    IReadOnlyDictionary<string, string> Metadata);
