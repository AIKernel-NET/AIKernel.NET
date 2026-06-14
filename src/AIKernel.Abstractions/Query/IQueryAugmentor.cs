namespace AIKernel.Abstractions.Query;

/// <summary>
/// Phase 1 Context Build において、入力 query の補間・正規化・意味的 rewrite を行う抽象契約です。
/// 実装は外部検索を行わず、KernelContext に基づく fail-closed な query 変換のみを担います。
/// JA: IQueryAugmentor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryAugmentor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Query.IQueryAugmentor']" />
public interface IQueryAugmentor
{
    /// <summary>
    /// 入力 query を KernelContext に基づいて補間または正規化します。
    /// JA: AugmentAsync 操作を実行します。
    /// </summary>
    /// <param name="query">ユーザーまたは上流 pipeline から渡された元 query。 JA: query パラメーターです。</param>
    /// <param name="context">推論トランザクションの Kernel context。 JA: context パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン。 JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>補間または正規化された query。 JA: 結果を返します。</returns>
    Task<string> AugmentAsync(
        string query,
        IKernelContext context,
        CancellationToken cancellationToken = default);
}
