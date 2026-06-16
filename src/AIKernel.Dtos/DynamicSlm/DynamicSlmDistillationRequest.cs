namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmDistillationRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationRequest']" />
public sealed record DynamicSlmDistillationRequest(
    string RequestId,
    string TargetCapabilityId,
    string TeacherModelId,
    IReadOnlyList<string> ReplayLogHashes,
    IReadOnlyDictionary<string, string> Constraints,
    IReadOnlyDictionary<string, string> Metadata);
