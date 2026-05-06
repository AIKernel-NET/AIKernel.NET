namespace AIKernel.Dtos.Security;

/// <summary>
/// AccessDecision の契約を定義します。
/// </summary>
public sealed class AccessDecision
{
    public bool Allowed { get; init; }
    public string? Reason { get; init; }
    public List<string> AppliedPolicies { get; init; } = new();
    public IReadOnlyDictionary<string, string>? Constraints { get; init; }
}




