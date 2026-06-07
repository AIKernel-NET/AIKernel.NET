namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlAnchorVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlAnchorVerifier']" />
public interface IHatlAnchorVerifier
{
    /// <summary>Executes the VerifyAnchorAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAnchorAsync 操作を実行します。</summary>
    ValueTask<HatlVerificationResult> VerifyAnchorAsync(
        HatlAnchorDocument anchor,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the VerifyInclusionAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyInclusionAsync 操作を実行します。</summary>
    ValueTask<HatlVerificationResult> VerifyInclusionAsync(
        HatlLedgerEntry entry,
        HatlAnchorDocument anchor,
        IReadOnlyList<string> merklePath,
        CancellationToken cancellationToken = default);
}
