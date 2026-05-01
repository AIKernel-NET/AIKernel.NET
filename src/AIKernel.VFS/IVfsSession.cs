namespace AIKernel.VFS;

/// <summary>
/// VFS セッションのインターフェースを定義します。
/// ファイルシステム操作を行うセッション。
/// </summary>
public interface IVfsSession : IAsyncDisposable
{
    /// <summary>
    /// セッションの一意識別子を取得します。
    /// </summary>
    string SessionId { get; }

    /// <summary>
    /// ファイルを読み取ります。
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <returns>ファイル</returns>
    Task<IVfsFile> ReadFileAsync(string path);

    /// <summary>
    /// ファイルを書き込みます。
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <param name="content">ファイル内容</param>
    Task WriteFileAsync(string path, byte[] content);

    /// <summary>
    /// ディレクトリを取得します。
    /// </summary>
    /// <param name="path">ディレクトリパス</param>
    /// <returns>ディレクトリ</returns>
    Task<IVfsDirectory> GetDirectoryAsync(string path);

    /// <summary>
    /// ファイル/ディレクトリが存在するかどうかを確認します。
    /// </summary>
    /// <param name="path">パス</param>
    Task<bool> ExistsAsync(string path);

    /// <summary>
    /// ファイル/ディレクトリを削除します。
    /// </summary>
    /// <param name="path">パス</param>
    Task DeleteAsync(string path);

    /// <summary>
    /// クエリを実行します。
    /// </summary>
    /// <param name="query">VFS クエリ</param>
    /// <returns>クエリ結果</returns>
    Task<IVfsQueryResult> QueryAsync(IVfsQuery query);
}
