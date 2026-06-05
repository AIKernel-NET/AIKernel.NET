using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmAdmissionResult(
    DynamicSlmAdmissionStatus Status,
    string ArtifactHash,
    string? Reason,
    IReadOnlyDictionary<string, string> Metadata);
