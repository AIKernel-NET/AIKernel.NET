namespace AIKernel.Enums;

/// <summary>
/// EventPriority の契約を定義します。
/// JA: EventPriority の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.EventPriority']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.EventPriority']" />
public enum EventPriority
{
    /// <summary>Gets the Low value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Low 値を取得します。</summary>
    Low = 0,
    /// <summary>Gets the Normal value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Normal 値を取得します。</summary>
    Normal = 1,
    /// <summary>Gets the High value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される High 値を取得します。</summary>
    High = 2,
    /// <summary>Gets the Critical value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Critical 値を取得します。</summary>
    Critical = 3
}



