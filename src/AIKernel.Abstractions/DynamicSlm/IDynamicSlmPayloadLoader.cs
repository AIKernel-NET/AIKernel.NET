namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: IDynamicSlmPayloadLoader contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPayloadLoader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmPayloadLoader']" />
public interface IDynamicSlmPayloadLoader
{
    /// <summary>EN: Executes the MaterializeAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで MaterializeAsync 操作を実行します。</summary>
    ValueTask<IReadOnlyList<DynamicSlmLoadedPayload>> MaterializeAsync(
        IReadOnlyList<DynamicSlmPayloadDescriptor> payloads,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the UnloadAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで UnloadAsync 操作を実行します。</summary>
    ValueTask UnloadAsync(
        IReadOnlyList<string> payloadIds,
        CancellationToken cancellationToken = default);
}
