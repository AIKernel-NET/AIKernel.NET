namespace AIKernel.Dtos;

/// <summary>
/// 転送トレースを表現します。
/// データフローとトレーサビリティを管理します。
/// </summary>
public sealed class TransferTrace
{
    /// <summary>
    /// トレースの一意識別子を取得または設定します。
    /// </summary>
    public required string TraceId { get; init; }

    /// <summary>
    /// データが転送された時刻を取得または設定します。
    /// </summary>
    public required DateTime TransferredAt { get; init; }

    /// <summary>
    /// 転送元を取得または設定します。
    /// </summary>
    public required string Source { get; init; }

    /// <summary>
    /// 転送先を取得または設定します。
    /// </summary>
    public required string Destination { get; init; }

    /// <summary>
    /// 転送時のコンテキストタイプを取得または設定します。
    /// </summary>
    public string? ContextType { get; init; }

    /// <summary>
    /// 転送されたデータサイズ（バイト）を取得または設定します。
    /// </summary>
    public long DataSizeBytes { get; init; }

    /// <summary>
    /// トレースに関連するメタデータを取得または設定します。
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}
