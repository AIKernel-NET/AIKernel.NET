namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 単一テキストをベクトル表現へ変換する capability interface です。
/// JA: ITextEmbeddingProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextEmbeddingProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextEmbeddingProvider']" />
public interface ITextEmbeddingProvider
{
    /// <summary>
    /// テキストをベクトルに変換します。
    /// JA: EmbedAsync 操作を実行します。
    /// </summary>
    /// <param name="text">入力テキスト JA: text パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>埋め込みベクトル JA: 結果を返します。</returns>
    Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 複数テキストを一括でベクトル化する capability interface です。
/// JA: IBatchEmbeddingProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IBatchEmbeddingProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IBatchEmbeddingProvider']" />
public interface IBatchEmbeddingProvider
{
    /// <summary>
    /// 複数のテキストを一括してベクトル化します。
    /// JA: EmbedBatchAsync 操作を実行します。
    /// </summary>
    /// <param name="texts">入力テキストのリスト JA: texts パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>埋め込みベクトルのリスト JA: 結果を返します。</returns>
    Task<IReadOnlyList<float[]>> EmbedBatchAsync(IReadOnlyList<string> texts, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 埋め込みベクトル次元数を公開する capability interface です。
/// JA: IEmbeddingDimensionProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingDimensionProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingDimensionProvider']" />
public interface IEmbeddingDimensionProvider
{
    /// <summary>
    /// 埋め込みベクトルの次元数を取得します。
    /// JA: GetDimension 操作を実行します。
    /// </summary>
    /// <returns>ベクトル次元数 JA: 結果を返します。</returns>
    int GetDimension();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 埋め込み（Embedding）プロバイダーを定義する互換合成インターフェースです。
/// テキストをベクトル表現に変換します。
/// JA: IEmbeddingProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingProvider']" />
public interface IEmbeddingProvider :
    IProvider,
    ITextEmbeddingProvider,
    IBatchEmbeddingProvider,
    IEmbeddingDimensionProvider
{
}
