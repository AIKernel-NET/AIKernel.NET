namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmLineage(
    string ArtifactHash,
    string? ParentModelId,
    string? TeacherModelId,
    IReadOnlyList<string> ReplayLogHashes,
    string? TrainingConfigHash,
    string? Signature);
