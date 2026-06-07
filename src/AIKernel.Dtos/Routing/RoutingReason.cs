namespace AIKernel.Dtos.Routing;

public sealed record RoutingReason(
    string Code,
    string Description,
    IReadOnlyDictionary<string, string>? Metadata = null);
