namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlDigitalDeedResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlDigitalDeedResolver']" />
public interface IHatlDigitalDeedResolver
{
    /// <summary>Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    ValueTask<HatlDigitalDeed?> ResolveAsync(
        string subjectId,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    ValueTask<HatlVerificationResult> VerifyAsync(
        HatlDigitalDeed deed,
        CancellationToken cancellationToken = default);
}
