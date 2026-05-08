namespace AIKernel.Vfs;

/// <summary>
/// 書き込み可能な Vfs ファイル能力を定義します。
/// </summary>
public interface IWritableVfsFile : IVfsEntryInfo
{
    /// <summary>
    /// ファイル内容を書き込みます。
    /// </summary>
    /// <param name="content">ファイル内容</param>
    /// <returns>書き込み完了を表すタスク</returns>
    /// <exception cref="IOException">書き込み中に I/O エラーが発生した場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">書き込み権限がない場合にスローされます。</exception>
    Task WriteAsync(byte[] content);

    /// <summary>
    /// ファイル内容をテキストとして書き込みます。
    /// </summary>
    /// <param name="content">ファイルテキスト</param>
    /// <returns>書き込み完了を表すタスク</returns>
    /// <exception cref="IOException">書き込み中に I/O エラーが発生した場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">書き込み権限がない場合にスローされます。</exception>
    Task WriteTextAsync(string content);
}
