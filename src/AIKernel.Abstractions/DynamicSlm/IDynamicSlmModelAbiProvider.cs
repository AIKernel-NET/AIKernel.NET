namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmModelAbiProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmModelAbiProvider']" />
public interface IDynamicSlmModelAbiProvider
{
    /// <summary>Executes the GetModelAbiAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetModelAbiAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmModelAbi?> GetModelAbiAsync(
        string modelId,
        CancellationToken cancellationToken = default);
}
