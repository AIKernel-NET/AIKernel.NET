namespace AIKernel.Vfs;

/// <summary>
/// 読み取り可能な Vfs セッション能力を定義します。
/// </summary>
public interface IReadableVfsSession
{
    /// <summary>
    /// セッションの一意識別子を取得します。
    /// </summary>
    string SessionId { get; }

    /// <summary>
    /// ファイルを読み取ります。
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <returns>読み取り可能なファイル</returns>
    Task<IReadableVfsFile> ReadReadableFileAsync(string path);

    /// <summary>
    /// ファイル/ディレクトリが存在するかどうかを確認します。
    /// </summary>
    /// <param name="path">パス</param>
    /// <returns>存在する場合は true。</returns>
    Task<bool> ExistsAsync(string path);
}
