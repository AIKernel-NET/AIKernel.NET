namespace AIKernel.Vfs;

/// <summary>
/// 書き込み可能な Vfs ファイル能力を定義します。
/// JA: IWritableVfsFile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsFile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IWritableVfsFile']" />
public interface IWritableVfsFile : IVfsEntryInfo
{
    /// <summary>
    /// ファイル内容を書き込みます。
    /// JA: WriteAsync 操作を実行します。
    /// </summary>
    /// <param name="content">ファイル内容 JA: content パラメーターです。</param>
    /// <returns>書き込み完了を表すタスク JA: 結果を返します。</returns>
    Task WriteAsync(byte[] content);

    /// <summary>
    /// ファイル内容をテキストとして書き込みます。
    /// JA: WriteTextAsync 操作を実行します。
    /// </summary>
    /// <param name="content">ファイルテキスト JA: content パラメーターです。</param>
    /// <returns>書き込み完了を表すタスク JA: 結果を返します。</returns>
    Task WriteTextAsync(string content);
}
