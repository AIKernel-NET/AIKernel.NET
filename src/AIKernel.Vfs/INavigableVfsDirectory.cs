namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// 列挙および階層移動が可能な Vfs ディレクトリ能力を定義します。
/// </summary>
public interface INavigableVfsDirectory : IVfsEntryInfo
{
    /// <summary>
    /// ディレクトリ内の読み取り可能なファイルを列挙します。
    /// </summary>
    /// <param name="recursive">再帰的に列挙するかどうか</param>
    /// <returns>読み取り可能なファイル一覧</returns>
    /// <exception cref="UnauthorizedAccessException">参照権限がない場合にスローされます。</exception>
    Task<IReadOnlyList<IReadableVfsFile>> GetReadableFilesAsync(bool recursive = false);

    /// <summary>
    /// ディレクトリ内のサブディレクトリを列挙します。
    /// </summary>
    /// <returns>サブディレクトリ一覧</returns>
    Task<IReadOnlyList<INavigableVfsDirectory>> GetNavigableDirectoriesAsync();

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
    Task<INavigableVfsDirectory?> GetNavigableSubdirectoryAsync(string name);
}
