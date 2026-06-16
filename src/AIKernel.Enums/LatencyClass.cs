namespace AIKernel.Enums;

/// <summary>
/// レイテンシクラスを定義します。
/// EN: パフォーマンスプロファイリングと制約に使用されます。
/// EN: Documentation for public API. JA: LatencyClass の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.LatencyClass']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.LatencyClass']" />
public enum LatencyClass
{
    /// <summary>
    /// EN: リアルタイム（0-10ms）
    /// EN: Documentation for public API. JA: RealTime 値を表します。
    /// </summary>
    RealTime = 1,

    /// <summary>
    /// EN: 即座（10-100ms）
    /// EN: Documentation for public API. JA: Interactive 値を表します。
    /// </summary>
    Interactive = 2,

    /// <summary>
    /// EN: 高速（100-1000ms）
    /// EN: Documentation for public API. JA: Fast 値を表します。
    /// </summary>
    Fast = 3,

    /// <summary>
    /// EN: 標準（1-10秒）
    /// EN: Documentation for public API. JA: Normal 値を表します。
    /// </summary>
    Normal = 4,

    /// <summary>
    /// EN: 低速（10秒以上）
    /// EN: Documentation for public API. JA: Slow 値を表します。
    /// </summary>
    Slow = 5
}

