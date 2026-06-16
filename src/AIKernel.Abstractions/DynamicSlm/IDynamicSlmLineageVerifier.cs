namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: IDynamicSlmLineageVerifier contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmLineageVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmLineageVerifier']" />
public interface IDynamicSlmLineageVerifier
{
    /// <summary>EN: Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmAdmissionResult> VerifyAsync(
        DynamicSlmModelAbi modelAbi,
        CancellationToken cancellationToken = default);
}
