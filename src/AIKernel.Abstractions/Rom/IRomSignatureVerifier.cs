namespace AIKernel.Abstractions.Rom;

using AIKernel.Dtos.Rom;

/// <summary>[EN] Documents this public package API member. [JA] IRomSignatureVerifier contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomSignatureVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomSignatureVerifier']" />
public interface IRomSignatureVerifier
{
    /// <summary>EN: Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    Task<RomSignatureVerificationResult> VerifyAsync(
        RomSnapshotCandidate candidate,
        CancellationToken cancellationToken = default);
}
