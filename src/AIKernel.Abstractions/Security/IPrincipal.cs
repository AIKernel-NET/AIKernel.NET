namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21 に基づく IPrincipal の契約を定義します。
/// </summary>
public interface IPrincipal
{
    string GetId();
    string GetName();
    IReadOnlyList<string> GetRoles();
    bool HasRole(string role);
}




