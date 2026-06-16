namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// EN: 列挙および階層移動が可能な Vfs ディレクトリ能力を定義します。
/// EN: Documentation for public API. JA: INavigableVfsDirectory の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsDirectory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsDirectory']" />
public interface INavigableVfsDirectory : IVfsEntryInfo
{
    /// <summary>
    /// EN: ディレクトリ内の読み取り可能なファイルを列挙します。
    /// EN: Documentation for public API. JA: GetReadableFilesAsync 操作を実行します。
    /// </summary>
    /// <param name="recursive">EN: Documentation for public API. JA: 再帰的に列挙するかどうか recursive パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 読み取り可能なファイル一覧 結果を返します。</returns>
    Task<IReadOnlyList<IReadableVfsFile>> GetReadableFilesAsync(bool recursive = false);

    /// <summary>
    /// EN: ディレクトリ内のサブディレクトリを列挙します。
    /// EN: Documentation for public API. JA: GetNavigableDirectoriesAsync 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: サブディレクトリ一覧 結果を返します。</returns>
    Task<IReadOnlyList<INavigableVfsDirectory>> GetNavigableDirectoriesAsync();

    /// <summary>
    /// EN: ディレクトリ内のすべてのエントリ（ファイルおよびディレクトリ）を列挙します。
    /// EN: Documentation for public API. JA: GetEntriesAsync 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: エントリ一覧 結果を返します。</returns>
    Task<IReadOnlyList<VfsEntry>> GetEntriesAsync();

    /// <summary>
    /// EN: サブディレクトリを取得します。
    /// EN: Documentation for public API. JA: GetNavigableSubdirectoryAsync 操作を実行します。
    /// </summary>
    /// <param name="name">EN: Documentation for public API. JA: サブディレクトリ名 name パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 見つかったサブディレクトリ。存在しない場合は null。 結果を返します。</returns>
    Task<INavigableVfsDirectory?> GetNavigableSubdirectoryAsync(string name);
}
