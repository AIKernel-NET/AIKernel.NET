namespace AIKernel.Abstractions;

/// <summary>
/// レート制限情報を表現します。
/// </summary>
public sealed class RateLimitInfo
{
    /// <summary>
    /// 制限期間（秒）を取得または設定します。
    /// </summary>
    public required int WindowSeconds { get; init; }

    /// <summary>
    /// 制限期間内のリクエスト数上限を取得または設定します。
    /// </summary>
    public required int RequestsPerWindow { get; init; }

    /// <summary>
    /// 現在のウィンドウ内で使用済みのリクエスト数を取得または設定します。
    /// </summary>
    public int UsedRequests { get; init; }
}
