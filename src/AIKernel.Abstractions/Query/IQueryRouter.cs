namespace AIKernel.Abstractions.Query;

/// <summary>
/// Phase 1 Context Build において、QueryPart を処理可能な Provider へ割り当てる抽象契約です。
/// ルーティング判断は Provider capability と KernelContext に基づき、部分成功を確定させない形で行われます。
/// JA: IQueryRouter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryRouter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryRouter']" />
public interface IQueryRouter
{
    /// <summary>
    /// QueryPart を処理する Provider を候補群から選択します。
    /// JA: RouteAsync 操作を実行します。
    /// </summary>
    /// <param name="queryPart">ルーティング対象の query part。 JA: queryPart パラメーターです。</param>
    /// <param name="context">推論トランザクションの Kernel context。 JA: context パラメーターです。</param>
    /// <param name="candidates">選択候補となる Provider 群。 JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン。 JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>選択された Provider。選択不能な場合は null。 JA: 結果を返します。</returns>
    Task<IProvider?> RouteAsync(
        QueryPart queryPart,
        IKernelContext context,
        IReadOnlyList<IProvider> candidates,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 複数の QueryPart を処理する Provider 群を一括で選択します。
    /// JA: RouteManyAsync 操作を実行します。
    /// </summary>
    /// <param name="queryParts">ルーティング対象の query part 群。 JA: queryParts パラメーターです。</param>
    /// <param name="context">推論トランザクションの Kernel context。 JA: context パラメーターです。</param>
    /// <param name="candidates">選択候補となる Provider 群。 JA: candidates パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン。 JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>QueryPart の順序に対応する Provider 群。 JA: 結果を返します。</returns>
    Task<IReadOnlyList<IProvider>> RouteManyAsync(
        IReadOnlyList<QueryPart> queryParts,
        IKernelContext context,
        IReadOnlyList<IProvider> candidates,
        CancellationToken cancellationToken = default);
}
