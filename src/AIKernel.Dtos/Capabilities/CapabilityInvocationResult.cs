namespace AIKernel.Dtos.Capabilities;

/// <summary>
/// EN: Deterministic result envelope returned by a capability module invocation boundary.
/// [EN] Documents this public package API member. [JA] CapabilityInvocationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Capabilities.CapabilityInvocationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Capabilities.CapabilityInvocationResult']" />
public sealed record CapabilityInvocationResult(
    string InvocationId,
    string CapabilityId,
    bool Succeeded,
    string? OutputHash,
    string? ErrorCode,
    string? ErrorMessage,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
