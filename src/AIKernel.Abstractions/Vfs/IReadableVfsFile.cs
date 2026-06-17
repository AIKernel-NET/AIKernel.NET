namespace AIKernel.Vfs;

/// <summary>
/// EN: 読み取り可能な Vfs ファイル能力を定義します。
/// [EN] Documents this public package API member. [JA] IReadableVfsFile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsFile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IReadableVfsFile']" />
public interface IReadableVfsFile : IVfsEntryInfo
{
    /// <summary>
    /// EN: ファイルサイズ（バイト）を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    long Size { get; }

    /// <summary>
    /// EN: ファイルが作成された日時を取得します。
    /// [EN] Documents this public package API member. [JA] ReadAsync 操作を実行します。
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// EN: ファイルが最後に変更された日時を取得します。
    /// [EN] Documents this public package API member. [JA] ReadAsync 操作を実行します。
    /// </summary>
    DateTime ModifiedAt { get; }

    /// <summary>
    /// EN: ファイル内容を読み取ります。
    /// [EN] Documents this public package API member. [JA] ReadAsync 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] ファイルのバイト列 結果を返します。</returns>
    Task<byte[]> ReadAsync();

    /// <summary>
    /// EN: ファイル内容をテキストとして読み取ります。
    /// [EN] Documents this public package API member. [JA] ReadAsTextAsync 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] ファイルテキスト 結果を返します。</returns>
    Task<string> ReadAsTextAsync();
}
