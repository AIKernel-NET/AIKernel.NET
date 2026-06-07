namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmTrajectoryMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmTrajectoryMetadata']" />
public sealed record DynamicSlmTrajectoryMetadata(
    string TrajectoryId,
    string ThoughtArtifactId,
    string ReplayLogHash,
    bool DistillationEligible,
    IReadOnlyDictionary<string, string> Metadata);
