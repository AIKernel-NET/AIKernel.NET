namespace AIKernel.Dtos.Capabilities;

/// <summary>
/// Deterministic request envelope for invoking a registered capability module.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Capabilities.CapabilityInvocationRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Capabilities.CapabilityInvocationRequest']" />
public sealed record CapabilityInvocationRequest(
    string InvocationId,
    string CapabilityId,
    string Operation,
    IReadOnlyDictionary<string, string> Arguments,
    string? InputHash,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
