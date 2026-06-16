namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: 単一テキストをベクトル表現へ変換する capability interface です。
/// [EN] Documents this public package API member. [JA] ITextEmbeddingProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextEmbeddingProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextEmbeddingProvider']" />
public interface ITextEmbeddingProvider
{
    /// <summary>
    /// EN: テキストをベクトルに変換します。
    /// [EN] Documents this public package API member. [JA] EmbedAsync 操作を実行します。
    /// </summary>
    /// <param name="text">[EN] Documents this public package API member. [JA] 入力テキスト text パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 埋め込みベクトル 結果を返します。</returns>
    Task<float[]> EmbedAsync(string text, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: 複数テキストを一括でベクトル化する capability interface です。
/// [EN] Documents this public package API member. [JA] IBatchEmbeddingProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IBatchEmbeddingProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IBatchEmbeddingProvider']" />
public interface IBatchEmbeddingProvider
{
    /// <summary>
    /// EN: 複数のテキストを一括してベクトル化します。
    /// [EN] Documents this public package API member. [JA] EmbedBatchAsync 操作を実行します。
    /// </summary>
    /// <param name="texts">[EN] Documents this public package API member. [JA] 入力テキストのリスト texts パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 埋め込みベクトルのリスト 結果を返します。</returns>
    Task<IReadOnlyList<float[]>> EmbedBatchAsync(IReadOnlyList<string> texts, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: 埋め込みベクトル次元数を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] IEmbeddingDimensionProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingDimensionProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingDimensionProvider']" />
public interface IEmbeddingDimensionProvider
{
    /// <summary>
    /// EN: 埋め込みベクトルの次元数を取得します。
    /// [EN] Documents this public package API member. [JA] GetDimension 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] ベクトル次元数 結果を返します。</returns>
    int GetDimension();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 埋め込み（Embedding）プロバイダーを定義する互換合成インターフェースです。
/// EN: テキストをベクトル表現に変換します。
/// [EN] Documents this public package API member. [JA] IEmbeddingProvider の公開契約を定義します。
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
