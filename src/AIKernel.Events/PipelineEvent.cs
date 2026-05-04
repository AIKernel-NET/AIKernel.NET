namespace AIKernel.Events;

/// <summary>
/// パイプラインイベントを表現します。
/// 処理パイプラインの進捗と状態を記録します。
/// </summary>
public sealed class PipelineEvent
{
    /// <summary>
    /// イベントの一意識別子を取得または設定します。
    /// </summary>
    public required string EventId { get; init; }

    /// <summary>
    /// パイプラインの一意識別子を取得または設定します。
    /// </summary>
    public required string PipelineId { get; init; }

    /// <summary>
    /// ステージ名を取得または設定します。
    /// </summary>
    public required string StageName { get; init; }

    /// <summary>
    /// イベント発生日時を取得または設定します。
    /// </summary>
    public required DateTime EventTime { get; init; }

    /// <summary>
    /// ステージの状態を取得または設定します。
    /// </summary>
    public required string Status { get; init; }

    /// <summary>
    /// 処理時間（ミリ秒）を取得または設定します。
    /// </summary>
    public long DurationMs { get; init; }

    /// <summary>
    /// イベントの説明を取得または設定します。
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }
}
