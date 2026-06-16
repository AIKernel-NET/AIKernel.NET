namespace AIKernel.Vfs;

/// <summary>
/// EN: 書き込み可能な Vfs セッション能力を定義します。
/// EN: Documentation for public API. JA: IWritableVfsSession の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsSession']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsSession']" />
public interface IWritableVfsSession
{
    /// <summary>
    /// EN: ファイルを書き込みます。
    /// EN: Documentation for public API. JA: WriteFileAsync 操作を実行します。
    /// </summary>
    /// <param name="path">EN: Documentation for public API. JA: ファイルパス path パラメーターです。</param>
    /// <param name="content">EN: Documentation for public API. JA: ファイル内容 content パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 書き込み完了を表すタスク 結果を返します。</returns>
    Task WriteFileAsync(string path, byte[] content);
}
