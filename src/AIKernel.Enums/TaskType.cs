namespace AIKernel.Enums;

/// <summary>
/// EN: TaskType の契約を定義します。
/// EN: Documentation for public API. JA: TaskType の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.TaskType']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.TaskType']" />
public enum TaskType
{
    /// <summary>EN: Gets the Sync value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Sync 値を取得します。</summary>
    Sync = 1,
    /// <summary>EN: Gets the Async value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Async 値を取得します。</summary>
    Async = 2,
    /// <summary>EN: Gets the Conditional value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Conditional 値を取得します。</summary>
    Conditional = 3,
    /// <summary>EN: Gets the Loop value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Loop 値を取得します。</summary>
    Loop = 4,
    /// <summary>EN: Gets the Parallel value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Parallel 値を取得します。</summary>
    Parallel = 5
}



