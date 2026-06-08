namespace AIKernel.Vfs;

/// <summary>
/// 階層移動可能な Vfs セッション能力を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.INavigableVfsSession']" />
public interface INavigableVfsSession
{
    /// <summary>
    /// ディレクトリを取得します。
    /// </summary>
    /// <param name="path">ディレクトリパス</param>
    /// <returns>階層移動可能なディレクトリ</returns>
    Task<INavigableVfsDirectory> GetNavigableDirectoryAsync(string path);
}
