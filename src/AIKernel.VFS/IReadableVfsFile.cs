namespace AIKernel.VFS;

/// <summary>
/// 読み取り可能な VFS ファイル能力を定義します。
/// </summary>
public interface IReadableVfsFile : IVfsEntryInfo
{
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
}
