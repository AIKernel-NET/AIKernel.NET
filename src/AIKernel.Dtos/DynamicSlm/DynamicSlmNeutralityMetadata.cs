using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmNeutralityMetadata(
    DynamicSlmBaseModelStateKind BaseModelState,
    bool IsNeutralNullState,
    string? NeutralityScore,
    IReadOnlyDictionary<string, string> Metadata);
