namespace AIKernel.Enums;

/// <summary>
/// Defines normalized outcomes for semantic admissibility checks.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.AdmissibilityDecisionKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.AdmissibilityDecisionKind']" />
public enum AdmissibilityDecisionKind
{
    /// <summary>Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>Gets the Admit value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Admit 値を取得します。</summary>
    Admit = 1,
    /// <summary>Gets the Deny value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Deny 値を取得します。</summary>
    Deny = 2,
    /// <summary>Gets the SuspendForApproval value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SuspendForApproval 値を取得します。</summary>
    SuspendForApproval = 3,
    /// <summary>Gets the Clarify value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Clarify 値を取得します。</summary>
    Clarify = 4,
    /// <summary>Gets the ReadOnly value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReadOnly 値を取得します。</summary>
    ReadOnly = 5,
    /// <summary>Gets the Delegate value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Delegate 値を取得します。</summary>
    Delegate = 6,
    /// <summary>Gets the Quarantine value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Quarantine 値を取得します。</summary>
    Quarantine = 7,
    /// <summary>Gets the Transform value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Transform 値を取得します。</summary>
    Transform = 8,
    /// <summary>Gets the Decompose value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Decompose 値を取得します。</summary>
    Decompose = 9,
    /// <summary>Gets the DelegateToSolver value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DelegateToSolver 値を取得します。</summary>
    DelegateToSolver = 10,
    /// <summary>Gets the NoExecution value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NoExecution 値を取得します。</summary>
    NoExecution = 11
}
