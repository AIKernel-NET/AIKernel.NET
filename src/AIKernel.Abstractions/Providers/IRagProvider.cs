namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 情報検索・取得（RAG）を実行する capability interface です。
/// </summary>
public interface IRagSearchProvider
{
    /// <summary>
    /// クエリに関連するドキュメントを検索します。
    /// </summary>
    /// <param name="query">検索クエリ</param>
    /// <param name="topK">取得する上位件数</param>
    /// <param name="cancellationToken">キャンセレーショントークン</param>
    /// <returns>関連する素材コンテキストのリスト</returns>
    Task<IReadOnlyList<MaterialContextDto>> SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// RAG インデックスへの書き込みを実行する capability interface です。
/// </summary>
public interface IRagIndexWriter
{
    /// <summary>
    /// ドキュメントをインデックスに追加します。
    /// </summary>
    /// <param name="documentId">ドキュメントID</param>
    /// <param name="content">ドキュメント内容</param>
    /// <param name="metadata">メタデータ</param>
    /// <param name="cancellationToken">キャンセレーショントークン</param>
    Task IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// RAG インデックスからドキュメントを削除する capability interface です。
/// </summary>
public interface IRagIndexDeleter
{
    /// <summary>
    /// ドキュメントをインデックスから削除します。
    /// </summary>
    /// <param name="documentId">ドキュメントID</param>
    /// <param name="cancellationToken">キャンセレーショントークン</param>
    Task DeleteAsync(string documentId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// RAG インデックス全体の管理操作を実行する capability interface です。
/// </summary>
public interface IRagIndexManager
{
    /// <summary>
    /// インデックスをクリアします。
    /// </summary>
    /// <param name="cancellationToken">キャンセレーショントークン</param>
    Task ClearAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 情報検索・取得（RAG）プロバイダーを定義する互換合成インターフェースです。
/// ベクトル検索やキーワード検索を通じて関連データを取得し、必要に応じて
/// インデックスを更新します。
/// </summary>
public interface IRagProvider :
    IProvider,
    IRagSearchProvider,
    IRagIndexWriter,
    IRagIndexDeleter,
    IRagIndexManager
{
}
