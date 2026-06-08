namespace AIKernel.Vfs;

/// <summary>
/// 削除可能な Vfs セッション能力を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IDeletableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IDeletableVfsSession']" />
public interface IDeletableVfsSession
{
    /// <summary>
    /// ファイル/ディレクトリを削除します。
    /// </summary>
    /// <param name="path">パス</param>
    /// <returns>削除完了を表すタスク</returns>
    Task DeleteAsync(string path);
}
