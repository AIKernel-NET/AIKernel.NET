namespace AIKernel.Enums.Metrics;

/// <summary>
/// EN: Describes metric kinds.
/// [EN] Documents this public package API member. [JA] MetricKind の公開契約を定義します。
/// </summary>
public enum MetricKind
{
    /// <summary>EN: Unknown metric kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Latency metric. JA: Latency 値を表します。</summary>
    Latency = 1,

    /// <summary>EN: Frames per second metric. JA: FramesPerSecond 値を表します。</summary>
    FramesPerSecond = 2,

    /// <summary>EN: Throughput metric. JA: Throughput 値を表します。</summary>
    Throughput = 3,

    /// <summary>EN: Error rate metric. JA: ErrorRate 値を表します。</summary>
    ErrorRate = 4,

    /// <summary>EN: Retry count metric. JA: RetryCount 値を表します。</summary>
    RetryCount = 5,

    /// <summary>EN: Cache hit rate metric. JA: CacheHitRate 値を表します。</summary>
    CacheHitRate = 6,

    /// <summary>EN: Memory byte metric. JA: MemoryBytes 値を表します。</summary>
    MemoryBytes = 7,

    /// <summary>EN: Input count metric. JA: InputCount 値を表します。</summary>
    InputCount = 8,

    /// <summary>EN: Replay frame count metric. JA: ReplayFrameCount 値を表します。</summary>
    ReplayFrameCount = 9,

    /// <summary>EN: Governance score metric. JA: GovernanceScore 値を表します。</summary>
    GovernanceScore = 10
}

/// <summary>
/// EN: Describes metric aggregation.
/// [EN] Documents this public package API member. [JA] MetricAggregationKind の公開契約を定義します。
/// </summary>
public enum MetricAggregationKind
{
    /// <summary>EN: Unknown aggregation. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>EN: Gauge aggregation. JA: Gauge 値を表します。</summary>
    Gauge = 1,

    /// <summary>EN: Counter aggregation. JA: Counter 値を表します。</summary>
    Counter = 2,

    /// <summary>EN: Average aggregation. JA: Average 値を表します。</summary>
    Average = 3,

    /// <summary>EN: Minimum aggregation. JA: Minimum 値を表します。</summary>
    Minimum = 4,

    /// <summary>EN: Maximum aggregation. JA: Maximum 値を表します。</summary>
    Maximum = 5,

    /// <summary>EN: Percentile aggregation. JA: Percentile 値を表します。</summary>
    Percentile = 6
}
