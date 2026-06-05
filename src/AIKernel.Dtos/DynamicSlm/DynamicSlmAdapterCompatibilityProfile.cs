using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmAdapterCompatibilityProfile(
    string BaseModelId,
    DynamicSlmBaseModelStateKind BaseModelState,
    IReadOnlyList<DynamicSlmPayloadKind> CompatiblePayloadKinds,
    IReadOnlyList<string> CompatibleAdapterFamilies,
    string? MaxVectorShiftNorm,
    IReadOnlyDictionary<string, string> Metadata);
