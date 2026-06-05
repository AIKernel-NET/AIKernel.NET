using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmFallbackStrategy(
    DynamicSlmFallbackKind Kind,
    string? TargetProviderId,
    string? TeacherModelId,
    string Reason,
    IReadOnlyDictionary<string, string> Metadata);
