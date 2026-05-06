namespace AIKernel.VFS;

using AIKernel.Dtos.Vfs;

/// <summary>
/// VFS ディレクトリのインターフェースを定義します。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
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
    /// <returns>ファイル一覧</returns>
    /// <exception cref="UnauthorizedAccessException">参照権限がない場合にスローされます。</exception>
    Task<IReadOnlyList<IVfsFile>> GetFilesAsync(bool recursive = false);

    /// <summary>
    /// ディレクトリ内のサブディレクトリを列挙します。
    /// </summary>
    /// <returns>サブディレクトリ一覧</returns>
    Task<IReadOnlyList<IVfsDirectory>> GetDirectoriesAsync();

    /// <summary>
    /// ディレクトリ内のすべてのエントリ（ファイルおよびディレクトリ）を列挙します。
    /// </summary>
    /// <returns>エントリ一覧</returns>
    Task<IReadOnlyList<VfsEntry>> GetEntriesAsync();

    /// <summary>
    /// サブディレクトリを取得します。
    /// </summary>
    /// <param name="name">サブディレクトリ名</param>
    /// <returns>見つかったサブディレクトリ。存在しない場合は null。</returns>
    /// <exception cref="ArgumentException">name が不正な場合にスローされます。</exception>
    Task<IVfsDirectory?> GetSubdirectoryAsync(string name);

    /// <summary>
    /// ディレクトリメタデータを取得します。
    /// </summary>
    /// <returns>メタデータ。未設定の場合は null。</returns>
    IReadOnlyDictionary<string, string>? GetMetadata();
}

