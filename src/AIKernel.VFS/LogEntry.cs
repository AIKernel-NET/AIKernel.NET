namespace AIKernel.VFS;

/// <summary>
/// ログエントリを表現します。
/// </summary>
public sealed class LogEntry
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
    /// ソースコンポーネントを取得または設定します。
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// ログコンテキストを取得します。
    /// </summary>
    public Dictionary<string, object>? Context { get; init; }
}
