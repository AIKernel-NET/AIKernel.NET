namespace AIKernel.Events;

/// <summary>
/// 実行イベントを表現します。
/// コード実行の追跡と監視を行います。
/// </summary>
public sealed class ExecutionEvent
{
    /// <summary>
    /// イベントの一意識別子を取得または設定します。
    /// </summary>
    public required string EventId { get; init; }

    /// <summary>
    /// 実行IDを取得または設定します。
    /// </summary>
    public required string ExecutionId { get; init; }

    /// <summary>
    /// 実行される関数/メソッド名を取得または設定します。
    /// </summary>
    public required string FunctionName { get; init; }

    /// <summary>
    /// 実行開始時刻を取得または設定します。
    /// </summary>
    public required DateTime StartTime { get; init; }

    /// <summary>
    /// 実行終了時刻を取得または設定します。
    /// </summary>
    public DateTime? EndTime { get; init; }

    /// <summary>
    /// 実行ステータスを取得または設定します。
    /// </summary>
    public required string Status { get; init; }

    /// <summary>
    /// 実行結果を取得または設定します。
    /// </summary>
    public object? Result { get; init; }

    /// <summary>
    /// 実行中に発生したエラーを取得または設定します。
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }
}
