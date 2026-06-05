namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmDistillationOffloadRequest(
    DynamicSlmDistillationPlan Plan,
    string Reason,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
