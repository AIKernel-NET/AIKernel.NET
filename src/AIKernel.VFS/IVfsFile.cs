namespace AIKernel.VFS;

/// <summary>
/// VFS ファイルのインターフェースを定義します。
/// UC-08（コンテキストスナップショットと永続化）, UC-18（Chat Persistence）
/// </summary>
public interface IVfsFile
{
    /// <summary>
    /// ファイルの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// ファイルパスを取得します。
    /// </summary>
    string Path { get; }

    /// <summary>
    /// ファイルサイズ（バイト）を取得します。
    /// </summary>
    long Size { get; }

    /// <summary>
    /// ファイルが作成された日時を取得します。
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// ファイルが最後に変更された日時を取得します。
    /// </summary>
    DateTime ModifiedAt { get; }

    /// <summary>
    /// ファイル内容を読み取ります。
    /// </summary>
    /// <returns>ファイルのバイト列</returns>
    /// <exception cref="IOException">読み取り中に I/O エラーが発生した場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">読み取り権限がない場合にスローされます。</exception>
    Task<byte[]> ReadAsync();

    /// <summary>
    /// ファイル内容をテキストとして読み取ります。
    /// </summary>
    /// <returns>ファイルテキスト</returns>
    /// <exception cref="IOException">読み取り中に I/O エラーが発生した場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">読み取り権限がない場合にスローされます。</exception>
    Task<string> ReadAsTextAsync();

    /// <summary>
    /// ファイルメタデータを取得します。
    /// </summary>
    /// <returns>メタデータ。未設定の場合は null。</returns>
    IReadOnlyDictionary<string, string>? GetMetadata();
}

