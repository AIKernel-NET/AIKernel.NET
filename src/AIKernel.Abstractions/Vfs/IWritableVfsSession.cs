namespace AIKernel.Vfs;

/// <summary>
/// 書き込み可能な Vfs セッション能力を定義します。
/// </summary>
public interface IWritableVfsSession
{
    /// <summary>
    /// ファイルを書き込みます。
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <param name="content">ファイル内容</param>
    /// <returns>書き込み完了を表すタスク</returns>
    Task WriteFileAsync(string path, byte[] content);
}
