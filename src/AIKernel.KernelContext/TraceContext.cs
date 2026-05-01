namespace AIKernel.KernelContext;

/// <summary>
/// トレースコンテキストを表現します。
/// 分散トレーシングと監視に使用されます。
/// </summary>
public sealed class TraceContext
{
    /// <summary>
    /// トレースIDを取得または設定します。
    /// </summary>
    public required string TraceId { get; init; }

    /// <summary>
    /// スパンIDを取得または設定します。
    /// </summary>
    public string? SpanId { get; init; }

    /// <summary>
    /// 親スパンIDを取得または設定します。
    /// </summary>
    public string? ParentSpanId { get; init; }

    /// <summary>
    /// トレース開始時刻を取得または設定します。
    /// </summary>
    public required DateTime StartTime { get; init; }

    /// <summary>
    /// トレース終了時刻を取得または設定します。
    /// </summary>
    public DateTime? EndTime { get; init; }

    /// <summary>
    /// トレースに関連するタグを取得または設定します。
    /// </summary>
    public Dictionary<string, string>? Tags { get; init; }

    /// <summary>
    /// トレース内のログを取得または設定します。
    /// </summary>
    public List<TraceLog>? Logs { get; init; }
}
