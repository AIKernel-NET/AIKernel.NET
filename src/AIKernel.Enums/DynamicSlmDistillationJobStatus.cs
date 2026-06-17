namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmDistillationJobStatus の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmDistillationJobStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmDistillationJobStatus']" />
public enum DynamicSlmDistillationJobStatus
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Pending value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Pending 値を取得します。</summary>
    Pending = 1,
    /// <summary>EN: Gets the Queued value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Queued 値を取得します。</summary>
    Queued = 2,
    /// <summary>EN: Gets the Running value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Running 値を取得します。</summary>
    Running = 3,
    /// <summary>EN: Gets the Completed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Completed 値を取得します。</summary>
    Completed = 4,
    /// <summary>EN: Gets the Failed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Failed 値を取得します。</summary>
    Failed = 5,
    /// <summary>EN: Gets the Cancelled value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Cancelled 値を取得します。</summary>
    Cancelled = 6,
    /// <summary>EN: Gets the Quarantined value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Quarantined 値を取得します。</summary>
    Quarantined = 7
}
