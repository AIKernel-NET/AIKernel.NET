using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record SeedSlmStructuralConstraints(
    bool RequiresStructuralAdherence,
    bool RequiresContractFidelity,
    bool RequiresFailClosed,
    bool RequiresZeroSlop,
    DynamicSlmStrictOutputMode StrictOutputMode,
    DynamicSlmReasoningTraceFormat RequiredTraceFormat,
    IReadOnlyDictionary<string, string> Metadata);
