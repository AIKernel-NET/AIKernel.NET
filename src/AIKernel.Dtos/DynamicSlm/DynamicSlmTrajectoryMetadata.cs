namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmTrajectoryMetadata を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmTrajectoryMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmTrajectoryMetadata']" />
public sealed record DynamicSlmTrajectoryMetadata(
    string TrajectoryId,
    string ThoughtArtifactId,
    string ReplayLogHash,
    bool DistillationEligible,
    IReadOnlyDictionary<string, string> Metadata);
