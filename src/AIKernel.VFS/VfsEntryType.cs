namespace AIKernel.VFS;

/// <summary>
/// VFS エントリタイプを定義します。
/// </summary>
public enum VfsEntryType
{
    /// <summary>
    /// ファイル
    /// </summary>
    File = 1,

    /// <summary>
    /// ディレクトリ
    /// </summary>
    Directory = 2,

    /// <summary>
    /// シンボリックリンク
    /// </summary>
    Link = 3
}
