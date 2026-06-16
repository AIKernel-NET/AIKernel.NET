namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] IDynamicSlmModuleRegistry contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmModuleRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmModuleRegistry']" />
public interface IDynamicSlmModuleRegistry
{
    /// <summary>EN: Executes the RegisterAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RegisterAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmAdmissionResult> RegisterAsync(
        DynamicSlmModelAbi modelAbi,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmModelAbi?> ResolveAsync(
        string modelId,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the ListAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ListAsync 操作を実行します。</summary>
    ValueTask<IReadOnlyList<DynamicSlmModelAbi>> ListAsync(
        string? capabilityId = null,
        CancellationToken cancellationToken = default);
}
