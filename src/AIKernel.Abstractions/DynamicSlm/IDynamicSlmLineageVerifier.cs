namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmLineageVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmLineageVerifier']" />
public interface IDynamicSlmLineageVerifier
{
    /// <summary>Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmAdmissionResult> VerifyAsync(
        DynamicSlmModelAbi modelAbi,
        CancellationToken cancellationToken = default);
}
