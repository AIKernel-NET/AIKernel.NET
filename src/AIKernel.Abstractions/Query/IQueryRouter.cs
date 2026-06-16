namespace AIKernel.Abstractions.Query;

/// <summary>
/// Phase 1 Context Build において、QueryPart を処理可能な Provider へ割り当てる抽象契約です。
/// EN: ルーティング判断は Provider capability と KernelContext に基づき、部分成功を確定させない形で行われます。
/// EN: Documentation for public API. JA: IQueryRouter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryRouter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryRouter']" />
public interface IQueryRouter
{
    /// <summary>
    /// EN: QueryPart を処理する Provider を候補群から選択します。
    /// EN: Documentation for public API. JA: RouteAsync 操作を実行します。
    /// </summary>
    /// <param name="queryPart">EN: Documentation for public API. JA: ルーティング対象の query part。 queryPart パラメーターです。</param>
    /// <param name="context">EN: Documentation for public API. JA: 推論トランザクションの Kernel context。 context パラメーターです。</param>
    /// <param name="candidates">EN: Documentation for public API. JA: 選択候補となる Provider 群。 candidates パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン。 キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 選択された Provider。選択不能な場合は null。 結果を返します。</returns>
    Task<IProvider?> RouteAsync(
        QueryPart queryPart,
        IKernelContext context,
        IReadOnlyList<IProvider> candidates,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: 複数の QueryPart を処理する Provider 群を一括で選択します。
    /// EN: Documentation for public API. JA: RouteManyAsync 操作を実行します。
    /// </summary>
    /// <param name="queryParts">EN: Documentation for public API. JA: ルーティング対象の query part 群。 queryParts パラメーターです。</param>
    /// <param name="context">EN: Documentation for public API. JA: 推論トランザクションの Kernel context。 context パラメーターです。</param>
    /// <param name="candidates">EN: Documentation for public API. JA: 選択候補となる Provider 群。 candidates パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン。 キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: QueryPart の順序に対応する Provider 群。 結果を返します。</returns>
    Task<IReadOnlyList<IProvider>> RouteManyAsync(
        IReadOnlyList<QueryPart> queryParts,
        IKernelContext context,
        IReadOnlyList<IProvider> candidates,
        CancellationToken cancellationToken = default);
}
