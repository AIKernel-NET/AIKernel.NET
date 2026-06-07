namespace AIKernel.Enums;

/// <summary>
/// Required mitigation attached before a critical operation may execute.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.CriticalOperationRequirement']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.CriticalOperationRequirement']" />
public enum CriticalOperationRequirement
{
    /// <summary>Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>Gets the HumanApproval value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HumanApproval 値を取得します。</summary>
    HumanApproval = 1,
    /// <summary>Gets the Sandbox value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Sandbox 値を取得します。</summary>
    Sandbox = 2,
    /// <summary>Gets the Snapshot value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Snapshot 値を取得します。</summary>
    Snapshot = 3,
    /// <summary>Gets the ReadOnly value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReadOnly 値を取得します。</summary>
    ReadOnly = 4,
    /// <summary>Gets the RestrictScope value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RestrictScope 値を取得します。</summary>
    RestrictScope = 5,
    /// <summary>Gets the NoExecution value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NoExecution 値を取得します。</summary>
    NoExecution = 6,
    /// <summary>Gets the ReplayRequired value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReplayRequired 値を取得します。</summary>
    ReplayRequired = 7
}
