namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmTrajectoryMetadata(
    string TrajectoryId,
    string ThoughtArtifactId,
    string ReplayLogHash,
    bool DistillationEligible,
    IReadOnlyDictionary<string, string> Metadata);
