namespace AIKernel.Abstractions.Query;

/// <summary>
/// Phase 1 Context Build において、複合 query を意味的に独立した QueryPart へ分解する抽象契約です。
/// 分解結果は ROM/CacheDB/Governance に渡す前の query planning 単位として扱われます。
/// </summary>
public interface IQueryDecomposer
{
    /// <summary>
    /// 入力 query を KernelContext に基づいて QueryPart の集合へ分解します。
    /// </summary>
    /// <param name="query">補間または正規化済みの query。</param>
    /// <param name="context">推論トランザクションの Kernel context。</param>
    /// <param name="cancellationToken">キャンセルトークン。</param>
    /// <returns>意味的に分解された query part の読み取り専用リスト。</returns>
    Task<IReadOnlyList<QueryPart>> DecomposeAsync(
        string query,
        IKernelContext context,
        CancellationToken cancellationToken = default);
}
