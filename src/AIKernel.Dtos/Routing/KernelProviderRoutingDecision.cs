namespace AIKernel.Dtos.Routing;

/// <summary>[EN] Documents this public package API member. [JA] KernelProviderRoutingDecision を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.KernelProviderRoutingDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.KernelProviderRoutingDecision']" />
public sealed record KernelProviderRoutingDecision(
    string ProviderId,
    string RequestedModelId,
    string? ProviderTier = null,
    string? CapabilityModuleId = null,
    string? RouteReason = null,
    RoutingScore? Score = null,
    IReadOnlyDictionary<string, string>? Metadata = null);
