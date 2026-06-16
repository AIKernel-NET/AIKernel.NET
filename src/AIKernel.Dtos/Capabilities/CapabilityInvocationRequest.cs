namespace AIKernel.Dtos.Capabilities;

/// <summary>
/// EN: Deterministic request envelope for invoking a registered capability module.
/// EN: Documentation for public API. JA: CapabilityInvocationRequest の公開契約を定義します。
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
