namespace AIKernel.Vfs;

/// <summary>
/// EN: クエリ可能な Vfs セッション能力を定義します。
/// EN: Documentation for public API. JA: IQueryableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IQueryableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IQueryableVfsSession']" />
public interface IQueryableVfsSession
{
    /// <summary>
    /// EN: クエリを実行します。
    /// EN: Documentation for public API. JA: QueryAsync 操作を実行します。
    /// </summary>
    /// <param name="query">EN: Documentation for public API. JA: Vfs クエリ query パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: クエリ結果 結果を返します。</returns>
    Task<IVfsQueryResult> QueryAsync(IVfsQuery query);
}
