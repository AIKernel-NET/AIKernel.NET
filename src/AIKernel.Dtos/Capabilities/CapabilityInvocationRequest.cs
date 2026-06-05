namespace AIKernel.Dtos.Capabilities;

/// <summary>
/// Deterministic request envelope for invoking a registered capability module.
/// </summary>
public sealed record CapabilityInvocationRequest(
    string InvocationId,
    string CapabilityId,
    string Operation,
    IReadOnlyDictionary<string, string> Arguments,
    string? InputHash,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
