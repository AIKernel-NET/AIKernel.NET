using AIKernel.Dtos.Providers.Reranking;

namespace AIKernel.Abstractions.Providers;

/// <summary>[EN] Text reranking capability. [JA] テキスト候補の再順位付け機能。</summary>
public interface IRerankProvider
{
    /// <summary>[EN] Scores all candidates, then returns the requested best-first results. [JA] 全候補を採点した後、指定された上位結果を返します。</summary>
    Task<RerankResult> RerankAsync(RerankRequest request, CancellationToken cancellationToken = default);
}

/// <summary>[EN] Reranking with provider lifecycle and placement metadata. [JA] ライフサイクルと配置情報を含む再順位付け契約。</summary>
public interface IRerankerProvider : IProvider, IRerankProvider, IProviderCapabilityDescriptorSource
{
}
