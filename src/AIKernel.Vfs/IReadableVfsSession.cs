namespace AIKernel.VFS;

/// <summary>
/// 読み取り可能な VFS セッション能力を定義します。
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
    /// <exception cref="ArgumentException">path が不正な場合にスローされます。</exception>
    /// <exception cref="FileNotFoundException">対象ファイルが存在しない場合にスローされます。</exception>
    Task<IReadableVfsFile> ReadReadableFileAsync(string path);

    /// <summary>
    /// ファイル/ディレクトリが存在するかどうかを確認します。
    /// </summary>
    /// <param name="path">パス</param>
    /// <returns>存在する場合は true。</returns>
    Task<bool> ExistsAsync(string path);
}
