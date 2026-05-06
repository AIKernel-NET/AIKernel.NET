namespace AIKernel.Dtos.Security;

/// <summary>
/// PolicyEvaluationResult の契約を定義します。
/// </summary>
public sealed class PolicyEvaluationResult
{
    public bool AllAllowed { get; init; }
    public List<AccessDecision> Decisions { get; init; } = new();
    public List<string> FailedPolicies { get; init; } = new();
    public string RiskLevel { get; init; } = "Low";
}




