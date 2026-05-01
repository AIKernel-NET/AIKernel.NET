namespace AIKernel.KernelContext;

/// <summary>
/// トレース内のログ項目を表現します。
/// </summary>
public sealed class TraceLog
{
    /// <summary>
    /// ログレベルを取得または設定します。
    /// </summary>
    public required string Level { get; init; }

    /// <summary>
    /// ログメッセージを取得または設定します。
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// ログ発生時刻を取得または設定します。
    /// </summary>
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// ログに関連するデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Data { get; init; }
}
