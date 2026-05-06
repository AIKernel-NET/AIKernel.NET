using System.Security.Principal;

namespace AIKernel.Dtos.Security;

/// <summary>
/// AccessRequest の契約を定義します。
/// </summary>
public sealed record AccessRequest
{
    public required IPrincipal Principal { get; init; }
    public required string Action { get; init; }
    public required string Resource { get; init; }
    public IReadOnlyDictionary<string, string>? Environment { get; init; }
}



