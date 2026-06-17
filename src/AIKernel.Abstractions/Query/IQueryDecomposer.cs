namespace AIKernel.Abstractions.Query;

/// <summary>
/// Phase 1 Context Build において、複合 query を意味的に独立した QueryPart へ分解する抽象契約です。
/// EN: 分解結果は ROM/CacheDB/Governance に渡す前の query planning 単位として扱われます。
/// [EN] Documents this public package API member. [JA] IQueryDecomposer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryDecomposer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryDecomposer']" />
public interface IQueryDecomposer
{
    /// <summary>
    /// EN: 入力 query を KernelContext に基づいて QueryPart の集合へ分解します。
    /// [EN] Documents this public package API member. [JA] DecomposeAsync 操作を実行します。
    /// </summary>
    /// <param name="query">[EN] Documents this public package API member. [JA] 補間または正規化済みの query。 query パラメーターです。</param>
    /// <param name="context">[EN] Documents this public package API member. [JA] 推論トランザクションの Kernel context。 context パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン。 キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 意味的に分解された query part の読み取り専用リスト。 結果を返します。</returns>
    Task<IReadOnlyList<QueryPart>> DecomposeAsync(
        string query,
        IKernelContext context,
        CancellationToken cancellationToken = default);
}
