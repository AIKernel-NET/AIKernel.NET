namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

/// <summary>[EN] Documents this public package API member. [JA] IHatlDigitalDeedResolver contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlDigitalDeedResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlDigitalDeedResolver']" />
public interface IHatlDigitalDeedResolver
{
    /// <summary>EN: Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    ValueTask<HatlDigitalDeed?> ResolveAsync(
        string subjectId,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    ValueTask<HatlVerificationResult> VerifyAsync(
        HatlDigitalDeed deed,
        CancellationToken cancellationToken = default);
}
