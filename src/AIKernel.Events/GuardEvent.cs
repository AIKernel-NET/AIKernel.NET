namespace AIKernel.Events;

/// <summary>
/// Guard イベントを表現します。
/// セキュリティガードの動作と意思決定を記録します。
/// </summary>
public sealed class GuardEvent
{
    /// <summary>
    /// イベントの一意識別子を取得または設定します。
    /// </summary>
    public required string EventId { get; init; }

    /// <summary>
    /// イベント発生日時を取得または設定します。
    /// </summary>
    public required DateTime EventTime { get; init; }

    /// <summary>
    /// ガード決定を取得または設定します。
    /// </summary>
    public required string Decision { get; init; }

    /// <summary>
    /// 対象リソースを取得または設定します。
    /// </summary>
    public string? Resource { get; init; }

    /// <summary>
    /// 対象アクションを取得または設定します。
    /// </summary>
    public string? Action { get; init; }

    /// <summary>
    /// 意思決定の詳細を取得または設定します。
    /// </summary>
    public string? Reason { get; init; }

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }
}
