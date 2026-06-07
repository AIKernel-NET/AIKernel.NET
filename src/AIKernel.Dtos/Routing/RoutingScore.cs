namespace AIKernel.Dtos.Routing;

public sealed record RoutingScore(
    double Value,
    string? ProfileId = null,
    IReadOnlyDictionary<string, string>? Metadata = null);
