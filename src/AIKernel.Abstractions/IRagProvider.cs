namespace AIKernel.Abstractions;

using AIKernel.Dtos;

/// <summary>
/// 情報検索・取得（RAG）プロバイダーを定義します。
/// ベクトル検索やキーワード検索を通じて関連データを取得します。
/// </summary>
public interface IRagProvider : IProvider
{
    /// <summary>
    /// クエリに基づいて関連ドキュメント/データを検索します。
    /// </summary>
    /// <param name="query">検索クエリ</param>
    /// <param name="topK">返す結果の数</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検索結果のドキュメントリスト</returns>
    Task<IReadOnlyList<MaterialContextDto>> SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default);

    /// <summary>
    /// ドキュメントをインデックスに追加します。
    /// </summary>
    /// <param name="documentId">ドキュメントID</param>
    /// <param name="content">ドキュメントコンテンツ</param>
    /// <param name="metadata">メタデータ</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// ドキュメントをインデックスから削除します。
    /// </summary>
    /// <param name="documentId">ドキュメントID</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task DeleteAsync(string documentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// インデックスをクリアします。
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task ClearAsync(CancellationToken cancellationToken = default);
}
