namespace AIKernel.Dtos.Routing;

public sealed record KernelProviderRoutingDecision(
    string ProviderId,
    string RequestedModelId,
    string? ProviderTier = null,
    string? CapabilityModuleId = null,
    string? RouteReason = null,
    RoutingScore? Score = null,
    IReadOnlyDictionary<string, string>? Metadata = null);
