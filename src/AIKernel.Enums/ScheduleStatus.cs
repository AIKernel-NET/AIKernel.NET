namespace AIKernel.Enums;

/// <summary>
/// ScheduleStatus の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.ScheduleStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.ScheduleStatus']" />
public enum ScheduleStatus
{
    /// <summary>Gets the Waiting value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Waiting 値を取得します。</summary>
    Waiting = 1,
    /// <summary>Gets the Running value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Running 値を取得します。</summary>
    Running = 2,
    /// <summary>Gets the Completed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Completed 値を取得します。</summary>
    Completed = 3,
    /// <summary>Gets the Failed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Failed 値を取得します。</summary>
    Failed = 4,
    /// <summary>Gets the Cancelled value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Cancelled 値を取得します。</summary>
    Cancelled = 5
}



