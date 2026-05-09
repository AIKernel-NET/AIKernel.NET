namespace AIKernel.Abstractions.Query;

/// <summary>
/// Phase 1 Context Build において、QueryPart を処理可能な Provider へ割り当てる抽象契約です。
/// ルーティング判断は Provider capability と KernelContext に基づき、部分成功を確定させない形で行われます。
/// </summary>
public interface IQueryRouter
{
    /// <summary>
    /// QueryPart を処理する Provider を候補群から選択します。
    /// </summary>
    /// <param name="queryPart">ルーティング対象の query part。</param>
    /// <param name="context">推論トランザクションの Kernel context。</param>
    /// <param name="candidates">選択候補となる Provider 群。</param>
    /// <param name="cancellationToken">キャンセルトークン。</param>
    /// <returns>選択された Provider。選択不能な場合は null。</returns>
    Task<IProvider?> RouteAsync(
        QueryPart queryPart,
        IKernelContext context,
        IReadOnlyList<IProvider> candidates,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 複数の QueryPart を処理する Provider 群を一括で選択します。
    /// </summary>
    /// <param name="queryParts">ルーティング対象の query part 群。</param>
    /// <param name="context">推論トランザクションの Kernel context。</param>
    /// <param name="candidates">選択候補となる Provider 群。</param>
    /// <param name="cancellationToken">キャンセルトークン。</param>
    /// <returns>QueryPart の順序に対応する Provider 群。</returns>
    Task<IReadOnlyList<IProvider>> RouteManyAsync(
        IReadOnlyList<QueryPart> queryParts,
        IKernelContext context,
        IReadOnlyList<IProvider> candidates,
        CancellationToken cancellationToken = default);
}
