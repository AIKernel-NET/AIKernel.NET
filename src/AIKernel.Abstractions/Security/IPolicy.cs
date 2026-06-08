namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21 に基づく IPolicy の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPolicy']" />
public interface IPolicy
{
    /// <summary>Executes the GetId operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetId 操作を実行します。</summary>
    string GetId();
    /// <summary>Executes the GetName operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetName 操作を実行します。</summary>
    string GetName();
    /// <summary>Executes the IsApplicable operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで IsApplicable 操作を実行します。</summary>
    bool IsApplicable(AccessRequest request);
    /// <summary>Executes the Evaluate operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Evaluate 操作を実行します。</summary>
    AccessDecision Evaluate(AccessRequest request);
}




