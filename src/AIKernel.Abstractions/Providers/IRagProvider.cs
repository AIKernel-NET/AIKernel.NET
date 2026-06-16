namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: 情報検索・取得（RAG）を実行する capability interface です。
/// EN: Documentation for public API. JA: IRagSearchProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagSearchProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagSearchProvider']" />
public interface IRagSearchProvider
{
    /// <summary>
    /// EN: クエリに関連するドキュメントを検索します。
    /// EN: Documentation for public API. JA: SearchAsync 操作を実行します。
    /// </summary>
    /// <param name="query">EN: Documentation for public API. JA: 検索クエリ query パラメーターです。</param>
    /// <param name="topK">EN: Documentation for public API. JA: 取得する上位件数 topK パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセレーショントークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 関連する素材コンテキストのリスト 結果を返します。</returns>
    Task<IReadOnlyList<MaterialContextDto>> SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: RAG インデックスへの書き込みを実行する capability interface です。
/// EN: Documentation for public API. JA: IRagIndexWriter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexWriter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexWriter']" />
public interface IRagIndexWriter
{
    /// <summary>
    /// EN: ドキュメントをインデックスに追加します。
    /// EN: Documentation for public API. JA: IndexAsync 操作を実行します。
    /// </summary>
    /// <param name="documentId">EN: Documentation for public API. JA: ドキュメントID documentId パラメーターです。</param>
    /// <param name="content">EN: Documentation for public API. JA: ドキュメント内容 content パラメーターです。</param>
    /// <param name="metadata">EN: Documentation for public API. JA: メタデータ metadata パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセレーショントークン キャンセル通知を監視するトークンです。</param>
    Task IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: RAG インデックスからドキュメントを削除する capability interface です。
/// EN: Documentation for public API. JA: IRagIndexDeleter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexDeleter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexDeleter']" />
public interface IRagIndexDeleter
{
    /// <summary>
    /// EN: ドキュメントをインデックスから削除します。
    /// EN: Documentation for public API. JA: DeleteAsync 操作を実行します。
    /// </summary>
    /// <param name="documentId">EN: Documentation for public API. JA: ドキュメントID documentId パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセレーショントークン キャンセル通知を監視するトークンです。</param>
    Task DeleteAsync(string documentId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: RAG インデックス全体の管理操作を実行する capability interface です。
/// EN: Documentation for public API. JA: IRagIndexManager の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexManager']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexManager']" />
public interface IRagIndexManager
{
    /// <summary>
    /// EN: インデックスをクリアします。
    /// EN: Documentation for public API. JA: ClearAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセレーショントークン キャンセル通知を監視するトークンです。</param>
    Task ClearAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 情報検索・取得（RAG）プロバイダーを定義する互換合成インターフェースです。
/// ベクトル検索やキーワード検索を通じて関連データを取得し、必要に応じて
/// EN: インデックスを更新します。
/// EN: Documentation for public API. JA: IRagProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagProvider']" />
public interface IRagProvider :
    IProvider,
    IRagSearchProvider,
    IRagIndexWriter,
    IRagIndexDeleter,
    IRagIndexManager
{
}
