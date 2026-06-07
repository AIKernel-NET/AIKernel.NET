namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21 に基づく IPrincipal の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPrincipal']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPrincipal']" />
public interface IPrincipal
{
    /// <summary>Executes the GetId operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetId 操作を実行します。</summary>
    string GetId();
    /// <summary>Executes the GetName operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetName 操作を実行します。</summary>
    string GetName();
    /// <summary>Executes the GetRoles operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetRoles 操作を実行します。</summary>
    IReadOnlyList<string> GetRoles();
    /// <summary>Executes the HasRole operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで HasRole 操作を実行します。</summary>
    bool HasRole(string role);
}




