namespace AIKernel.VFS;

/// <summary>
/// VFS クエリの並べ替え条件を定義します。
/// </summary>
public sealed class VfsQuerySort
{
    /// <summary>
    /// 並べ替えのフィールド名を取得または設定します。
    /// </summary>
    public required string FieldName { get; init; }

    /// <summary>
    /// 昇順かどうかを取得または設定します。
    /// </summary>
    public bool Ascending { get; init; } = true;
}
