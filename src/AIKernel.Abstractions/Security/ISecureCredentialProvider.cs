namespace AIKernel.Abstractions.Security;

/// <summary>[EN] Documents this public package API member. [JA] ISecureCredentialProvider contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISecureCredentialProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISecureCredentialProvider']" />
public interface ISecureCredentialProvider
{
    /// <summary>EN: Executes the GetSecretAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetSecretAsync 操作を実行します。</summary>
    ValueTask<string> GetSecretAsync(
        string key,
        CancellationToken cancellationToken = default);
}
