namespace AIKernel.VFS;

/// <summary>
/// ログフィルター条件を表現します。
/// </summary>
public sealed class LogFilter
{
    /// <summary>
    /// 開始時刻を取得または設定します。
    /// </summary>
    public DateTime? StartTime { get; init; }

    /// <summary>
    /// 終了時刻を取得または設定します。
    /// </summary>
    public DateTime? EndTime { get; init; }

    /// <summary>
    /// ログレベルフィルターを取得または設定します。
    /// </summary>
    public List<string>? Levels { get; init; }

    /// <summary>
    /// メッセージフィルター（含む）を取得または設定します。
    /// </summary>
    public string? MessageContains { get; init; }

    /// <summary>
    /// ソースフィルターを取得または設定します。
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// 返すエントリ数の上限を取得または設定します。
    /// </summary>
    public int Limit { get; init; } = 1000;
}
