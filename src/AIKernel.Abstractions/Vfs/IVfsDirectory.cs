namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// Vfs ディレクトリの互換合成インターフェースを定義します。
/// EN: UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// EN: Documentation for public API. JA: IVfsDirectory の公開契約を定義します。
/// </summary>
/// <remarks>
/// v0.0.2 以降、階層移動能力は <see cref="INavigableVfsDirectory"/> で表現します。
/// 本インターフェースは既存実装との互換性を維持するため、従来の戻り値型を残します。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsDirectory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsDirectory']" />
public interface IVfsDirectory : INavigableVfsDirectory
{
    /// <summary>
    /// EN: ディレクトリ内のファイルを列挙します。
    /// EN: Documentation for public API. JA: GetFilesAsync 操作を実行します。
    /// </summary>
    /// <param name="recursive">EN: Documentation for public API. JA: 再帰的に列挙するかどうか recursive パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: ファイル一覧 結果を返します。</returns>
    Task<IReadOnlyList<IVfsFile>> GetFilesAsync(bool recursive = false);

    /// <summary>
    /// EN: ディレクトリ内のサブディレクトリを列挙します。
    /// EN: Documentation for public API. JA: GetDirectoriesAsync 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: サブディレクトリ一覧 結果を返します。</returns>
    Task<IReadOnlyList<IVfsDirectory>> GetDirectoriesAsync();

    /// <summary>
    /// EN: サブディレクトリを取得します。
    /// EN: Documentation for public API. JA: GetSubdirectoryAsync 操作を実行します。
    /// </summary>
    /// <param name="name">EN: Documentation for public API. JA: サブディレクトリ名 name パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 見つかったサブディレクトリ。存在しない場合は null。 結果を返します。</returns>
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

