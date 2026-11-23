namespace AIKernel.Dtos.Providers;

/// <summary>[EN] v1 provider placement schema and timing. [JA] v1 の配置スキーマと状態更新間隔。</summary>
public static class ProviderPlacementAbi
{
    /// <summary>[EN] Current schema version. [JA] 現在のスキーマ版。</summary>
    public const int SchemaVersion = 1;
    /// <summary>[EN] Recommended refresh cadence. [JA] 推奨の更新間隔。</summary>
    public static TimeSpan HeartbeatInterval => TimeSpan.FromSeconds(10);
    /// <summary>[EN] Maximum snapshot age at selection. [JA] 配置判定に使える観測の有効期間。</summary>
    public static TimeSpan SnapshotLifetime => TimeSpan.FromSeconds(30);
}
