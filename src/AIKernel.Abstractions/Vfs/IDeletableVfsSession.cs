namespace AIKernel.Vfs;

/// <summary>
/// 削除可能な Vfs セッション能力を定義します。
/// JA: IDeletableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IDeletableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IDeletableVfsSession']" />
public interface IDeletableVfsSession
{
    /// <summary>
    /// ファイル/ディレクトリを削除します。
    /// JA: DeleteAsync 操作を実行します。
    /// </summary>
    /// <param name="path">パス JA: path パラメーターです。</param>
    /// <returns>削除完了を表すタスク JA: 結果を返します。</returns>
    Task DeleteAsync(string path);
}
