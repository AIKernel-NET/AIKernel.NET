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
    public Dictionary<string, object>? Metadata { get; init; }
}

/// <summary>
/// 目的を表現します。
/// 処理の意図と目標を定義します。
/// </summary>
public sealed class Purpose
{
    /// <summary>
    /// 目的の一意識別子を取得または設定します。
    /// </summary>
    public required string PurposeId { get; init; }

    /// <summary>
    /// 目的の説明を取得または設定します。
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// 目的の優先度（1-10）を取得または設定します。
    /// </summary>
    public int Priority { get; init; } = 5;

    /// <summary>
    /// 目的に関連するタグを取得または設定します。
    /// </summary>
    public List<string> Tags { get; init; } = new();

    /// <summary>
    /// 目的の達成条件を取得または設定します。
    /// </summary>
    public string? SuccessCriteria { get; init; }

    /// <summary>
    /// 目的が作成された日時を取得または設定します。
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
