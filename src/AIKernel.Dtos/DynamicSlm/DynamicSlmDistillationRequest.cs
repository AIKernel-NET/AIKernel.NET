namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmDistillationRequest(
    string RequestId,
    string TargetCapabilityId,
    string TeacherModelId,
    IReadOnlyList<string> ReplayLogHashes,
    IReadOnlyDictionary<string, string> Constraints);
