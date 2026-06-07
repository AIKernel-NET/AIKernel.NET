namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlCryptographicOperator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlCryptographicOperator']" />
public interface IHatlCryptographicOperator
{
    /// <summary>Executes the ComputeBlockMacAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ComputeBlockMacAsync 操作を実行します。</summary>
    ValueTask<HatlBlockMacResult> ComputeBlockMacAsync(
        HatlBlockMacRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the AdvanceRatchetAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで AdvanceRatchetAsync 操作を実行します。</summary>
    ValueTask<HatlRatchetStepResult> AdvanceRatchetAsync(
        HatlRatchetStepRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the VerifyAnchorSignatureAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAnchorSignatureAsync 操作を実行します。</summary>
    ValueTask<HatlVerificationResult> VerifyAnchorSignatureAsync(
        HatlAnchorDocument anchor,
        CancellationToken cancellationToken = default);
}
