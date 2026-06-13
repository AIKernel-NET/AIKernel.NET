namespace AIKernel.Vfs;

/// <summary>
/// 書き込み可能な Vfs セッション能力を定義します。
/// JA: IWritableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsSession']" />
public interface IWritableVfsSession
{
    /// <summary>
    /// ファイルを書き込みます。
    /// JA: WriteFileAsync 操作を実行します。
    /// </summary>
    /// <param name="path">ファイルパス JA: path パラメーターです。</param>
    /// <param name="content">ファイル内容 JA: content パラメーターです。</param>
    /// <returns>書き込み完了を表すタスク JA: 結果を返します。</returns>
    Task WriteFileAsync(string path, byte[] content);
}
