namespace AIKernel.Events;

/// <summary>
/// プロバイダーイベントを表現します。
/// プロバイダーの動作と状態を記録します。
/// </summary>
public sealed class ProviderEvent
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
    /// プロバイダーIDを取得または設定します。
    /// </summary>
    public required string ProviderId { get; init; }

    /// <summary>
    /// イベントタイプを取得または設定します。
    /// </summary>
    public required string EventType { get; init; }

    /// <summary>
    /// イベントの説明を取得または設定します。
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// 操作の成功/失敗を取得または設定します。
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// エラーメッセージを取得または設定します。
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }
}
