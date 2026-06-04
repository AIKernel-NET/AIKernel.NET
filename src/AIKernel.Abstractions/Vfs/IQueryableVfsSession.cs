namespace AIKernel.Vfs;

/// <summary>
/// クエリ可能な Vfs セッション能力を定義します。
/// </summary>
public interface IQueryableVfsSession
{
    /// <summary>
    /// クエリを実行します。
    /// </summary>
    /// <param name="query">Vfs クエリ</param>
    /// <returns>クエリ結果</returns>
    Task<IVfsQueryResult> QueryAsync(IVfsQuery query);
}
