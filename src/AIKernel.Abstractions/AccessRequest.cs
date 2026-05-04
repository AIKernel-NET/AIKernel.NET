namespace AIKernel.Abstractions;

public sealed class AccessRequest
{
    public required IPrincipal Principal { get; init; }
    public required string Action { get; init; }
    public required string Resource { get; init; }
    public IReadOnlyDictionary<string, string>? Environment { get; init; }
}
