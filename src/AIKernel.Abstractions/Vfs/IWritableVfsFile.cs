namespace AIKernel.Vfs;

/// <summary>
/// EN: 書き込み可能な Vfs ファイル能力を定義します。
/// [EN] Documents this public package API member. [JA] IWritableVfsFile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsFile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsFile']" />
public interface IWritableVfsFile : IVfsEntryInfo
{
    /// <summary>
    /// EN: ファイル内容を書き込みます。
    /// [EN] Documents this public package API member. [JA] WriteAsync 操作を実行します。
    /// </summary>
    /// <param name="content">[EN] Documents this public package API member. [JA] ファイル内容 content パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 書き込み完了を表すタスク 結果を返します。</returns>
    Task WriteAsync(byte[] content);

    /// <summary>
    /// EN: ファイル内容をテキストとして書き込みます。
    /// [EN] Documents this public package API member. [JA] WriteTextAsync 操作を実行します。
    /// </summary>
    /// <param name="content">[EN] Documents this public package API member. [JA] ファイルテキスト content パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 書き込み完了を表すタスク 結果を返します。</returns>
    Task WriteTextAsync(string content);
}
