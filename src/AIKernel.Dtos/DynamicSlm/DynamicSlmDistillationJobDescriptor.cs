using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmDistillationJobDescriptor(
    DynamicSlmDistillationJobId JobId,
    DynamicSlmDistillationPlan Plan,
    DynamicSlmDistillationJobStatus Status,
    IReadOnlyList<string> SourceReplayLogHashes,
    IReadOnlyDictionary<string, string> Metadata);
