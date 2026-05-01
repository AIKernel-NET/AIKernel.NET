namespace AIKernel.Abstractions;

/// <summary>
/// プロバイダーのヘルスステータスを表現します。
/// </summary>
public sealed class ProviderHealthStatus
{
    /// <summary>
    /// ヘルスチェックが成功したかどうかを取得または設定します。
    /// </summary>
    public required bool IsHealthy { get; init; }

    /// <summary>
    /// ヘルスチェックのメッセージを取得または設定します。
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// ヘルスチェック実行時刻を取得または設定します。
    /// </summary>
    public DateTime CheckedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// 応答時間（ミリ秒）を取得または設定します。
    /// </summary>
    public long ResponseTimeMs { get; init; }
}
