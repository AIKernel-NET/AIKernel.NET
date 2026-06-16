namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmLineage を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmLineage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmLineage']" />
public sealed record DynamicSlmLineage(
    string ArtifactHash,
    string? ParentModelId,
    string? TeacherModelId,
    IReadOnlyList<string> ReplayLogHashes,
    string? TrainingConfigHash,
    string? Signature);
