namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21 に基づく IPolicy の契約を定義します。
/// </summary>
public interface IPolicy
{
    string GetId();
    string GetName();
    bool IsApplicable(AccessRequest request);
    AccessDecision Evaluate(AccessRequest request);
}




