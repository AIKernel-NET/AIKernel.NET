namespace AIKernel.Enums;

/// <summary>
/// レイテンシクラスを定義します。
/// パフォーマンスプロファイリングと制約に使用されます。
/// JA: LatencyClass の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.LatencyClass']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.LatencyClass']" />
public enum LatencyClass
{
    /// <summary>
    /// リアルタイム（0-10ms）
    /// JA: RealTime 値を表します。
    /// </summary>
    RealTime = 1,

    /// <summary>
    /// 即座（10-100ms）
    /// JA: Interactive 値を表します。
    /// </summary>
    Interactive = 2,

    /// <summary>
    /// 高速（100-1000ms）
    /// JA: Fast 値を表します。
    /// </summary>
    Fast = 3,

    /// <summary>
    /// 標準（1-10秒）
    /// JA: Normal 値を表します。
    /// </summary>
    Normal = 4,

    /// <summary>
    /// 低速（10秒以上）
    /// JA: Slow 値を表します。
    /// </summary>
    Slow = 5
}

