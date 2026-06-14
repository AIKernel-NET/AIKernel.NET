namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 情報検索・取得（RAG）を実行する capability interface です。
/// JA: IRagSearchProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagSearchProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagSearchProvider']" />
public interface IRagSearchProvider
{
    /// <summary>
    /// クエリに関連するドキュメントを検索します。
    /// JA: SearchAsync 操作を実行します。
    /// </summary>
    /// <param name="query">検索クエリ JA: query パラメーターです。</param>
    /// <param name="topK">取得する上位件数 JA: topK パラメーターです。</param>
    /// <param name="cancellationToken">キャンセレーショントークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>関連する素材コンテキストのリスト JA: 結果を返します。</returns>
    Task<IReadOnlyList<MaterialContextDto>> SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// RAG インデックスへの書き込みを実行する capability interface です。
/// JA: IRagIndexWriter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexWriter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexWriter']" />
public interface IRagIndexWriter
{
    /// <summary>
    /// ドキュメントをインデックスに追加します。
    /// JA: IndexAsync 操作を実行します。
    /// </summary>
    /// <param name="documentId">ドキュメントID JA: documentId パラメーターです。</param>
    /// <param name="content">ドキュメント内容 JA: content パラメーターです。</param>
    /// <param name="metadata">メタデータ JA: metadata パラメーターです。</param>
    /// <param name="cancellationToken">キャンセレーショントークン JA: キャンセル通知を監視するトークンです。</param>
    Task IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// RAG インデックスからドキュメントを削除する capability interface です。
/// JA: IRagIndexDeleter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexDeleter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexDeleter']" />
public interface IRagIndexDeleter
{
    /// <summary>
    /// ドキュメントをインデックスから削除します。
    /// JA: DeleteAsync 操作を実行します。
    /// </summary>
    /// <param name="documentId">ドキュメントID JA: documentId パラメーターです。</param>
    /// <param name="cancellationToken">キャンセレーショントークン JA: キャンセル通知を監視するトークンです。</param>
    Task DeleteAsync(string documentId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// RAG インデックス全体の管理操作を実行する capability interface です。
/// JA: IRagIndexManager の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexManager']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IRagIndexManager']" />
public interface IRagIndexManager
{
    /// <summary>
    /// インデックスをクリアします。
    /// JA: ClearAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">キャンセレーショントークン JA: キャンセル通知を監視するトークンです。</param>
    Task ClearAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 情報検索・取得（RAG）プロバイダーを定義する互換合成インターフェースです。
/// ベクトル検索やキーワード検索を通じて関連データを取得し、必要に応じて
/// インデックスを更新します。
/// JA: IRagProvider の公開契約を定義します。
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
