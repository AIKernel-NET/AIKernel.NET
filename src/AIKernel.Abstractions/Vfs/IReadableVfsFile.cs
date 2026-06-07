namespace AIKernel.Vfs;

/// <summary>
/// 読み取り可能な Vfs ファイル能力を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsFile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsFile']" />
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
    Task<byte[]> ReadAsync();

    /// <summary>
    /// ファイル内容をテキストとして読み取ります。
    /// </summary>
    /// <returns>ファイルテキスト</returns>
    Task<string> ReadAsTextAsync();
}
