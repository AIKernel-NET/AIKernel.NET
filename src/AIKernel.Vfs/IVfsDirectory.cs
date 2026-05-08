namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs ディレクトリの互換合成インターフェースを定義します。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// </summary>
/// <remarks>
/// v0.0.2 以降、階層移動能力は <see cref="INavigableVfsDirectory"/> で表現します。
/// 本インターフェースは既存実装との互換性を維持するため、従来の戻り値型を残します。
/// </remarks>
public interface IVfsDirectory : INavigableVfsDirectory
{
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
    /// サブディレクトリを取得します。
    /// </summary>
    /// <param name="name">サブディレクトリ名</param>
    /// <returns>見つかったサブディレクトリ。存在しない場合は null。</returns>
    /// <exception cref="ArgumentException">name が不正な場合にスローされます。</exception>
    Task<IVfsDirectory?> GetSubdirectoryAsync(string name);

    async Task<IReadOnlyList<IReadableVfsFile>> INavigableVfsDirectory.GetReadableFilesAsync(bool recursive)
    {
        IReadOnlyList<IVfsFile> files = await GetFilesAsync(recursive).ConfigureAwait(false);
        return files;
    }

    async Task<IReadOnlyList<INavigableVfsDirectory>> INavigableVfsDirectory.GetNavigableDirectoriesAsync()
    {
        IReadOnlyList<IVfsDirectory> directories = await GetDirectoriesAsync().ConfigureAwait(false);
        return directories;
    }

    async Task<INavigableVfsDirectory?> INavigableVfsDirectory.GetNavigableSubdirectoryAsync(string name)
    {
        return await GetSubdirectoryAsync(name).ConfigureAwait(false);
    }
}

