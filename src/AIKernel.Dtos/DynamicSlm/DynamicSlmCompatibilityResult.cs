using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmCompatibilityResult(
    DynamicSlmCompatibilityStatus Status,
    string ModelId,
    IReadOnlyList<string> CapabilityIds,
    string? Reason,
    IReadOnlyDictionary<string, string> Metadata);
