using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineOffloadInfo(
    DynamicSlmDistillationJobId JobId,
    DynamicSlmDistillationJobStatus Status,
    string? TeacherModelId,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
