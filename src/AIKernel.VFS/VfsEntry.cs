namespace AIKernel.VFS;

/// <summary>
/// VFS エントリ（ファイルまたはディレクトリ）を表現します。
/// </summary>
public sealed class VfsEntry
{
    /// <summary>
    /// エントリの名前を取得または設定します。
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// エントリのタイプを取得または設定します。
    /// </summary>
    public required VfsEntryType Type { get; init; }

    /// <summary>
    /// エントリパスを取得または設定します。
    /// </summary>
    public required string Path { get; init; }

    /// <summary>
    /// エントリサイズ（バイト）を取得または設定します。
    /// </summary>
    public long Size { get; init; }

    /// <summary>
    /// 作成日時を取得または設定します。
    /// </summary>
    public required DateTime CreatedAt { get; init; }

    /// <summary>
    /// 変更日時を取得または設定します。
    /// </summary>
    public required DateTime ModifiedAt { get; init; }
}
