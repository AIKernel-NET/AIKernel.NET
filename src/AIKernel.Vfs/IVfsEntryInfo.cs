namespace AIKernel.Vfs;

/// <summary>
/// Vfs エントリに共通する識別情報を定義します。
/// </summary>
public interface IVfsEntryInfo
{
    /// <summary>
    /// エントリ名を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// エントリパスを取得します。
    /// </summary>
    string Path { get; }

    /// <summary>
    /// エントリメタデータを取得します。
    /// </summary>
    /// <returns>メタデータ。未設定の場合は null。</returns>
    IReadOnlyDictionary<string, string>? GetMetadata();
}
