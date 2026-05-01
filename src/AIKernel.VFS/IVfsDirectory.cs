namespace AIKernel.VFS;

/// <summary>
/// VFS ディレクトリのインターフェースを定義します。
/// </summary>
public interface IVfsDirectory
{
    /// <summary>
    /// ディレクトリの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// ディレクトリパスを取得します。
    /// </summary>
    string Path { get; }

    /// <summary>
    /// ディレクトリ内のファイルを列挙します。
    /// </summary>
    /// <param name="recursive">再帰的に列挙するかどうか</param>
    Task<IReadOnlyList<IVfsFile>> GetFilesAsync(bool recursive = false);

    /// <summary>
    /// ディレクトリ内のサブディレクトリを列挙します。
    /// </summary>
    Task<IReadOnlyList<IVfsDirectory>> GetDirectoriesAsync();

    /// <summary>
    /// ディレクトリ内のすべてのエントリ（ファイルおよびディレクトリ）を列挙します。
    /// </summary>
    Task<IReadOnlyList<VfsEntry>> GetEntriesAsync();

    /// <summary>
    /// サブディレクトリを取得します。
    /// </summary>
    /// <param name="name">サブディレクトリ名</param>
    Task<IVfsDirectory?> GetSubdirectoryAsync(string name);

    /// <summary>
    /// ディレクトリメタデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? GetMetadata();
}
