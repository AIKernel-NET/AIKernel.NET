namespace AIKernel.Dtos.Providers
{
    /// <summary>[EN] Content reference in the central API store. [JA] 中央 API ストアに保存されたデータへの参照。</summary>
    public sealed record ProviderPayloadReference(string Sha256, long SizeBytes);

    /// <summary>[EN] Job claimed by a worker from the central API. [JA] 中央 API からワーカーが取得するジョブ。</summary>
    public sealed record ProviderWorkItem(
        string JobId,
        string ClaimId,
        ProviderRequirements Requirements,
        ProviderPayloadReference Input);
}

namespace AIKernel.Abstractions.Providers
{
    using AIKernel.Dtos.Providers;

    /// <summary>[EN] Worker-side connection to the central v1 API. [JA] 中央 v1 API へのワーカー側の接続契約。</summary>
    public interface IProviderWorkPullClient
    {
        /// <summary>[EN] Claims work assigned to a node or returns null for an empty queue. [JA] ノードに割り当てられたジョブを取得します。</summary>
        ValueTask<ProviderWorkItem?> ClaimAsync(string nodeId, CancellationToken cancellationToken = default);

        /// <summary>[EN] Copies and verifies input. Discard the destination if copying fails. [JA] 入力を転送して検証します。失敗時は書き込み先を破棄してください。</summary>
        ValueTask CopyInputToAsync(ProviderWorkItem work, Stream destination, CancellationToken cancellationToken = default);

        /// <summary>[EN] Streams a result to the central API. The caller owns the stream. [JA] 結果を中央 API に送り、ストリームは呼び出し元が所有します。</summary>
        ValueTask CompleteAsync(
            ProviderWorkItem work, Stream result, ProviderPayloadReference reference,
            CancellationToken cancellationToken = default);

        /// <summary>[EN] Reports a stable error code without request content. [JA] 入力本文を含めず安定したエラーコードを報告します。</summary>
        ValueTask FailAsync(ProviderWorkItem work, string errorCode, CancellationToken cancellationToken = default);
    }
}
