using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmDelegationRequest(
    string DelegationId,
    DynamicSlmDelegationKind Kind,
    DynamicSlmDelegationReason Reason,
    string SourceCapabilityId,
    string? TargetId,
    string? ReplayLogHash,
    string? ThoughtArtifactId,
    IReadOnlyDictionary<string, string> Metadata);
