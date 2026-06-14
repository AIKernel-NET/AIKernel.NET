namespace AIKernel.Enums.Metrics;

/// <summary>
/// Describes metric kinds.
/// JA: MetricKind の公開契約を定義します。
/// </summary>
public enum MetricKind
{
    /// <summary>Unknown metric kind. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Latency metric. JA: Latency 値を表します。</summary>
    Latency = 1,

    /// <summary>Frames per second metric. JA: FramesPerSecond 値を表します。</summary>
    FramesPerSecond = 2,

    /// <summary>Throughput metric. JA: Throughput 値を表します。</summary>
    Throughput = 3,

    /// <summary>Error rate metric. JA: ErrorRate 値を表します。</summary>
    ErrorRate = 4,

    /// <summary>Retry count metric. JA: RetryCount 値を表します。</summary>
    RetryCount = 5,

    /// <summary>Cache hit rate metric. JA: CacheHitRate 値を表します。</summary>
    CacheHitRate = 6,

    /// <summary>Memory byte metric. JA: MemoryBytes 値を表します。</summary>
    MemoryBytes = 7,

    /// <summary>Input count metric. JA: InputCount 値を表します。</summary>
    InputCount = 8,

    /// <summary>Replay frame count metric. JA: ReplayFrameCount 値を表します。</summary>
    ReplayFrameCount = 9,

    /// <summary>Governance score metric. JA: GovernanceScore 値を表します。</summary>
    GovernanceScore = 10
}

/// <summary>
/// Describes metric aggregation.
/// JA: MetricAggregationKind の公開契約を定義します。
/// </summary>
public enum MetricAggregationKind
{
    /// <summary>Unknown aggregation. JA: Unknown 値を表します。</summary>
    Unknown = 0,

    /// <summary>Gauge aggregation. JA: Gauge 値を表します。</summary>
    Gauge = 1,

    /// <summary>Counter aggregation. JA: Counter 値を表します。</summary>
    Counter = 2,

    /// <summary>Average aggregation. JA: Average 値を表します。</summary>
    Average = 3,

    /// <summary>Minimum aggregation. JA: Minimum 値を表します。</summary>
    Minimum = 4,

    /// <summary>Maximum aggregation. JA: Maximum 値を表します。</summary>
    Maximum = 5,

    /// <summary>Percentile aggregation. JA: Percentile 値を表します。</summary>
    Percentile = 6
}
