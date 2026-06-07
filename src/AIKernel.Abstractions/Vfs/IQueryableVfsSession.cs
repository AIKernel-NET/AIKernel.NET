namespace AIKernel.Vfs;

/// <summary>
/// クエリ可能な Vfs セッション能力を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IQueryableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IQueryableVfsSession']" />
public interface IQueryableVfsSession
{
    /// <summary>
    /// クエリを実行します。
    /// </summary>
    /// <param name="query">Vfs クエリ</param>
    /// <returns>クエリ結果</returns>
    Task<IVfsQueryResult> QueryAsync(IVfsQuery query);
}
