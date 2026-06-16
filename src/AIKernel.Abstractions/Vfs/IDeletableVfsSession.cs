namespace AIKernel.Vfs;

/// <summary>
/// EN: 削除可能な Vfs セッション能力を定義します。
/// [EN] Documents this public package API member. [JA] IDeletableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IDeletableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IDeletableVfsSession']" />
public interface IDeletableVfsSession
{
    /// <summary>
    /// EN: ファイル/ディレクトリを削除します。
    /// [EN] Documents this public package API member. [JA] DeleteAsync 操作を実行します。
    /// </summary>
    /// <param name="path">[EN] Documents this public package API member. [JA] パス path パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 削除完了を表すタスク 結果を返します。</returns>
    Task DeleteAsync(string path);
}
