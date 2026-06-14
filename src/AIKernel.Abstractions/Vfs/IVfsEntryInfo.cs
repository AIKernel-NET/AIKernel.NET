namespace AIKernel.Vfs;

/// <summary>
/// Vfs エントリに共通する識別情報を定義します。
/// JA: IVfsEntryInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsEntryInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsEntryInfo']" />
public interface IVfsEntryInfo
{
    /// <summary>
    /// エントリ名を取得します。
    /// JA: GetMetadata 操作を実行します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// エントリパスを取得します。
    /// JA: GetMetadata 操作を実行します。
    /// </summary>
    string Path { get; }

    /// <summary>
    /// エントリメタデータを取得します。
    /// JA: GetMetadata 操作を実行します。
    /// </summary>
    /// <returns>メタデータ。未設定の場合は null。 JA: 結果を返します。</returns>
    IReadOnlyDictionary<string, string>? GetMetadata();
}
