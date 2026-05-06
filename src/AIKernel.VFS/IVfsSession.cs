namespace AIKernel.VFS;

/// <summary>
/// VFS セッションのインターフェースを定義します。
/// ファイルシステム操作を行うセッション。
/// </summary>
/// <remarks>
/// UC-08/UC-18 の永続化操作は、本セッション契約を通じて実行されます。
/// </remarks>
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
    /// <exception cref="ArgumentException">path が不正な場合にスローされます。</exception>
    /// <exception cref="FileNotFoundException">対象ファイルが存在しない場合にスローされます。</exception>
    Task<IVfsFile> ReadFileAsync(string path);

    /// <summary>
    /// ファイルを書き込みます。
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <param name="content">ファイル内容</param>
    /// <returns>書き込み完了を表すタスク</returns>
    /// <exception cref="ArgumentException">path が不正な場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">書き込み権限がない場合にスローされます。</exception>
    Task WriteFileAsync(string path, byte[] content);

    /// <summary>
    /// ディレクトリを取得します。
    /// </summary>
    /// <param name="path">ディレクトリパス</param>
    /// <returns>ディレクトリ</returns>
    /// <exception cref="ArgumentException">path が不正な場合にスローされます。</exception>
    /// <exception cref="DirectoryNotFoundException">対象ディレクトリが存在しない場合にスローされます。</exception>
    Task<IVfsDirectory> GetDirectoryAsync(string path);

    /// <summary>
    /// ファイル/ディレクトリが存在するかどうかを確認します。
    /// </summary>
    /// <param name="path">パス</param>
    /// <returns>存在する場合は true。</returns>
    Task<bool> ExistsAsync(string path);

    /// <summary>
    /// ファイル/ディレクトリを削除します。
    /// </summary>
    /// <param name="path">パス</param>
    /// <returns>削除完了を表すタスク</returns>
    /// <exception cref="ArgumentException">path が不正な場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">削除権限がない場合にスローされます。</exception>
    Task DeleteAsync(string path);

    /// <summary>
    /// クエリを実行します。
    /// </summary>
    /// <param name="query">VFS クエリ</param>
    /// <returns>クエリ結果</returns>
    /// <exception cref="ArgumentNullException">query が null の場合にスローされます。</exception>
    Task<IVfsQueryResult> QueryAsync(IVfsQuery query);
}

