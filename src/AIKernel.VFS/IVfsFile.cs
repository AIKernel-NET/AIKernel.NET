namespace AIKernel.VFS;

/// <summary>
/// VFS ファイルのインターフェースを定義します。
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
    Task<byte[]> ReadAsync();

    /// <summary>
    /// ファイル内容をテキストとして読み取ります。
    /// </summary>
    Task<string> ReadAsTextAsync();

    /// <summary>
    /// ファイルメタデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string>? GetMetadata();
}
