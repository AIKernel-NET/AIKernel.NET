using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineOffloadInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineOffloadInfo']" />
public sealed record DynamicSlmPipelineOffloadInfo(
    DynamicSlmDistillationJobId JobId,
    DynamicSlmDistillationJobStatus Status,
    string? TeacherModelId,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
