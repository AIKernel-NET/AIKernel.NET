namespace AIKernel.Vfs;

/// <summary>
/// クエリ可能な Vfs セッション能力を定義します。
/// JA: IQueryableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IQueryableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IQueryableVfsSession']" />
public interface IQueryableVfsSession
{
    /// <summary>
    /// クエリを実行します。
    /// JA: QueryAsync 操作を実行します。
    /// </summary>
    /// <param name="query">Vfs クエリ JA: query パラメーターです。</param>
    /// <returns>クエリ結果 JA: 結果を返します。</returns>
    Task<IVfsQueryResult> QueryAsync(IVfsQuery query);
}
