namespace AIKernel.Vfs;

/// <summary>
/// EN: 階層移動可能な Vfs セッション能力を定義します。
/// EN: Documentation for public API. JA: INavigableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
public interface INavigableVfsSession
{
    /// <summary>
    /// EN: ディレクトリを取得します。
    /// EN: Documentation for public API. JA: GetNavigableDirectoryAsync 操作を実行します。
    /// </summary>
    /// <param name="path">EN: Documentation for public API. JA: ディレクトリパス path パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 階層移動可能なディレクトリ 結果を返します。</returns>
    Task<INavigableVfsDirectory> GetNavigableDirectoryAsync(string path);
}
