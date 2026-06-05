namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmCapabilityGap(
    string GapId,
    string CapabilityId,
    string ObservedFailureCode,
    string ReplayLogHash,
    string? SemanticDeltaHash,
    int EvidenceCount,
    IReadOnlyDictionary<string, string> Metadata);
