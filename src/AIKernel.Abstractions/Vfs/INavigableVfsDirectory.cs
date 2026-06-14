namespace AIKernel.Vfs;

using AIKernel.Dtos.Vfs;

/// <summary>
/// 列挙および階層移動が可能な Vfs ディレクトリ能力を定義します。
/// JA: INavigableVfsDirectory の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsDirectory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsDirectory']" />
public interface INavigableVfsDirectory : IVfsEntryInfo
{
    /// <summary>
    /// ディレクトリ内の読み取り可能なファイルを列挙します。
    /// JA: GetReadableFilesAsync 操作を実行します。
    /// </summary>
    /// <param name="recursive">再帰的に列挙するかどうか JA: recursive パラメーターです。</param>
    /// <returns>読み取り可能なファイル一覧 JA: 結果を返します。</returns>
    Task<IReadOnlyList<IReadableVfsFile>> GetReadableFilesAsync(bool recursive = false);

    /// <summary>
    /// ディレクトリ内のサブディレクトリを列挙します。
    /// JA: GetNavigableDirectoriesAsync 操作を実行します。
    /// </summary>
    /// <returns>サブディレクトリ一覧 JA: 結果を返します。</returns>
    Task<IReadOnlyList<INavigableVfsDirectory>> GetNavigableDirectoriesAsync();

    /// <summary>
    /// ディレクトリ内のすべてのエントリ（ファイルおよびディレクトリ）を列挙します。
    /// JA: GetEntriesAsync 操作を実行します。
    /// </summary>
    /// <returns>エントリ一覧 JA: 結果を返します。</returns>
    Task<IReadOnlyList<VfsEntry>> GetEntriesAsync();

    /// <summary>
    /// サブディレクトリを取得します。
    /// JA: GetNavigableSubdirectoryAsync 操作を実行します。
    /// </summary>
    /// <param name="name">サブディレクトリ名 JA: name パラメーターです。</param>
    /// <returns>見つかったサブディレクトリ。存在しない場合は null。 JA: 結果を返します。</returns>
    Task<INavigableVfsDirectory?> GetNavigableSubdirectoryAsync(string name);
}
