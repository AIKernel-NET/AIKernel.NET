namespace AIKernel.VFS;

/// <summary>
/// VFS クエリ結果の行を表現します。
/// </summary>
public sealed class VfsQueryRow
{
    /// <summary>
    /// 行のデータを取得または設定します。
    /// </summary>
    public required Dictionary<string, object> Data { get; init; }

    /// <summary>
    /// 指定された列の値を取得します。
    /// </summary>
    /// <param name="columnName">列名</param>
    public object? GetValue(string columnName)
    {
        return Data.TryGetValue(columnName, out var value) ? value : null;
    }
}
