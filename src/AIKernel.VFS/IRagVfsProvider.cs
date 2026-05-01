namespace AIKernel.VFS;

/// <summary>
/// RAG（Retrieval-Augmented Generation）データソースへの VFS アクセス。
/// </summary>
public interface IRagVfsProvider : IVfsProvider
{
    /// <summary>
    /// RAG インデックスをクエリします。
    /// </summary>
    /// <param name="session">VFS セッション</param>
    /// <param name="query">クエリテキスト</param>
    /// <param name="limit">返すドキュメント数の上限</param>
    Task<IReadOnlyList<RagDocument>> QueryAsync(IVfsSession session, string query, int limit = 10);

    /// <summary>
    /// ドキュメントを RAG インデックスに追加します。
    /// </summary>
    /// <param name="session">VFS セッション</param>
    /// <param name="document">ドキュメント</param>
    Task AddDocumentAsync(IVfsSession session, RagDocument document);
}
