namespace AIKernel.Vfs;

/// <summary>
/// 階層移動可能な Vfs セッション能力を定義します。
/// JA: INavigableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
public interface INavigableVfsSession
{
    /// <summary>
    /// ディレクトリを取得します。
    /// JA: GetNavigableDirectoryAsync 操作を実行します。
    /// </summary>
    /// <param name="path">ディレクトリパス JA: path パラメーターです。</param>
    /// <returns>階層移動可能なディレクトリ JA: 結果を返します。</returns>
    Task<INavigableVfsDirectory> GetNavigableDirectoryAsync(string path);
}
