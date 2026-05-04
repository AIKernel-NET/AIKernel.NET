using System.Security.Principal;

namespace AIKernel.Dtos.Security;

public sealed record AccessRequest
{
    public required IPrincipal Principal { get; init; }
    public required string Action { get; init; }
    public required string Resource { get; init; }
    public IReadOnlyDictionary<string, string>? Environment { get; init; }
}
