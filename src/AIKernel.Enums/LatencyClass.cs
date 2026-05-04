namespace AIKernel.Enums;

/// <summary>
/// レイテンシクラスを定義します。
/// パフォーマンスプロファイリングと制約に使用されます。
/// </summary>
public enum LatencyClass
{
    /// <summary>
    /// リアルタイム（0-10ms）
    /// </summary>
    RealTime = 1,

    /// <summary>
    /// 即座（10-100ms）
    /// </summary>
    Interactive = 2,

    /// <summary>
    /// 高速（100-1000ms）
    /// </summary>
    Fast = 3,

    /// <summary>
    /// 標準（1-10秒）
    /// </summary>
    Normal = 4,

    /// <summary>
    /// 低速（10秒以上）
    /// </summary>
    Slow = 5
}
