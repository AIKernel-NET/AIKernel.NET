namespace AIKernel.Abstractions.Query;

/// <summary>
/// Phase 1 Context Build において、入力 query の補間・正規化・意味的 rewrite を行う抽象契約です。
/// 実装は外部検索を行わず、KernelContext に基づく fail-closed な query 変換のみを担います。
/// </summary>
public interface IQueryAugmentor
{
    /// <summary>
    /// 入力 query を KernelContext に基づいて補間または正規化します。
    /// </summary>
    /// <param name="query">ユーザーまたは上流 pipeline から渡された元 query。</param>
    /// <param name="context">推論トランザクションの Kernel context。</param>
    /// <param name="cancellationToken">キャンセルトークン。</param>
    /// <returns>補間または正規化された query。</returns>
    Task<string> AugmentAsync(
        string query,
        IKernelContext context,
        CancellationToken cancellationToken = default);
}
