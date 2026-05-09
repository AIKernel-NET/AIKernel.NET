namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 単一テキストをベクトル表現へ変換する capability interface です。
/// </summary>
public interface ITextEmbeddingProvider
{
    /// <summary>
    /// テキストをベクトルに変換します。
    /// </summary>
    /// <param name="text">入力テキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>埋め込みベクトル</returns>
    Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 複数テキストを一括でベクトル化する capability interface です。
/// </summary>
public interface IBatchEmbeddingProvider
{
    /// <summary>
    /// 複数のテキストを一括してベクトル化します。
    /// </summary>
    /// <param name="texts">入力テキストのリスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>埋め込みベクトルのリスト</returns>
    Task<IReadOnlyList<float[]>> EmbedBatchAsync(IReadOnlyList<string> texts, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 埋め込みベクトル次元数を公開する capability interface です。
/// </summary>
public interface IEmbeddingDimensionProvider
{
    /// <summary>
    /// 埋め込みベクトルの次元数を取得します。
    /// </summary>
    /// <returns>ベクトル次元数</returns>
    int GetDimension();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 埋め込み（Embedding）プロバイダーを定義する互換合成インターフェースです。
/// テキストをベクトル表現に変換します。
/// </summary>
public interface IEmbeddingProvider :
    IProvider,
    ITextEmbeddingProvider,
    IBatchEmbeddingProvider,
    IEmbeddingDimensionProvider
{
}
