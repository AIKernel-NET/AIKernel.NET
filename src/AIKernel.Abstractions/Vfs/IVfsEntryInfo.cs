namespace AIKernel.Vfs;

/// <summary>
/// EN: Vfs エントリに共通する識別情報を定義します。
/// EN: Documentation for public API. JA: IVfsEntryInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsEntryInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Vfs.IVfsEntryInfo']" />
public interface IVfsEntryInfo
{
    /// <summary>
    /// EN: エントリ名を取得します。
    /// EN: Documentation for public API. JA: GetMetadata 操作を実行します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// EN: エントリパスを取得します。
    /// EN: Documentation for public API. JA: GetMetadata 操作を実行します。
    /// </summary>
    string Path { get; }

    /// <summary>
    /// EN: エントリメタデータを取得します。
    /// EN: Documentation for public API. JA: GetMetadata 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: メタデータ。未設定の場合は null。 結果を返します。</returns>
    IReadOnlyDictionary<string, string>? GetMetadata();
}
