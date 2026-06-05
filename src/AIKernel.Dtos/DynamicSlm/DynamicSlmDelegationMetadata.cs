using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmDelegationMetadata(
    string DelegationId,
    DynamicSlmDelegationKind Kind,
    DynamicSlmDelegationReason Reason,
    bool FailClosed,
    string? TargetId,
    IReadOnlyDictionary<string, string> Metadata);
