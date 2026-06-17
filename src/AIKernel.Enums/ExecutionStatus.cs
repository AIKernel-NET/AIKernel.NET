namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] ExecutionStatus の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.ExecutionStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.ExecutionStatus']" />
public enum ExecutionStatus
{
    /// <summary>EN: Gets the Succeeded value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Succeeded 値を取得します。</summary>
    Succeeded = 0,

    /// <summary>EN: Gets the Rejected value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Rejected 値を取得します。</summary>
    Rejected = 1,

    /// <summary>EN: Gets the Failed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Failed 値を取得します。</summary>
    Failed = 2,

    /// <summary>EN: Gets the Canceled value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Canceled 値を取得します。</summary>
    Canceled = 3,

    /// <summary>EN: Gets the TimedOut value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TimedOut 値を取得します。</summary>
    TimedOut = 4,

    /// <summary>EN: Gets the RateLimited value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RateLimited 値を取得します。</summary>
    RateLimited = 5
}
