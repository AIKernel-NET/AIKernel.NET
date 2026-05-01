namespace AIKernel.VFS;

/// <summary>
/// VFS プロバイダーのヘルスステータスを表現します。
/// </summary>
public sealed class VfsProviderHealth
{
    /// <summary>
    /// プロバイダーが健全かどうかを取得または設定します。
    /// </summary>
    public required bool IsHealthy { get; init; }

    /// <summary>
    /// ステータスメッセージを取得または設定します。
    /// </summary>
    public string? StatusMessage { get; init; }

    /// <summary>
    /// 応答時間（ミリ秒）を取得または設定します。
    /// </summary>
    public long ResponseTimeMs { get; init; }

    /// <summary>
    /// ヘルスチェック実行時刻を取得または設定します。
    /// </summary>
    public DateTime CheckedAt { get; init; } = DateTime.UtcNow;
}
