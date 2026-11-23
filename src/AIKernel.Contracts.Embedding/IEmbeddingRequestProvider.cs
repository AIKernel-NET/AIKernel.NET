using AIKernel.Dtos.Providers.Embedding;

namespace AIKernel.Abstractions.Providers;

/// <summary>[EN] Request-based embedding capability. [JA] 要求DTOを使う埋め込み機能。</summary>
public interface IEmbeddingRequestProvider
{
    /// <summary>[EN] Embeds a batch atomically. [JA] 1バッチ全体の埋め込みを実行します。</summary>
    Task<EmbeddingResult> GenerateEmbeddingsAsync(EmbeddingRequest request, CancellationToken cancellationToken = default);
}

/// <summary>[EN] Combined request, text compatibility and placement contract. [JA] 要求・テキスト互換・配置の合成契約。</summary>
public interface IMultimodalEmbeddingProvider : IEmbeddingProvider, IEmbeddingRequestProvider, IProviderCapabilityDescriptorSource
{
}
