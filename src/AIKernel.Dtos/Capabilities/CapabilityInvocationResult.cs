namespace AIKernel.Dtos.Capabilities;

/// <summary>
/// Deterministic result envelope returned by a capability module invocation boundary.
/// </summary>
public sealed record CapabilityInvocationResult(
    string InvocationId,
    string CapabilityId,
    bool Succeeded,
    string? OutputHash,
    string? ErrorCode,
    string? ErrorMessage,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
