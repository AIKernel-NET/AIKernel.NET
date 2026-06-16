namespace AIKernel.Enums;

/// <summary>
/// EN: Defines normalized outcomes for semantic admissibility checks.
/// [EN] Documents this public package API member. [JA] AdmissibilityDecisionKind の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.AdmissibilityDecisionKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.AdmissibilityDecisionKind']" />
public enum AdmissibilityDecisionKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Admit value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Admit 値を取得します。</summary>
    Admit = 1,
    /// <summary>EN: Gets the Deny value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Deny 値を取得します。</summary>
    Deny = 2,
    /// <summary>EN: Gets the SuspendForApproval value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SuspendForApproval 値を取得します。</summary>
    SuspendForApproval = 3,
    /// <summary>EN: Gets the Clarify value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Clarify 値を取得します。</summary>
    Clarify = 4,
    /// <summary>EN: Gets the ReadOnly value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReadOnly 値を取得します。</summary>
    ReadOnly = 5,
    /// <summary>EN: Gets the Delegate value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Delegate 値を取得します。</summary>
    Delegate = 6,
    /// <summary>EN: Gets the Quarantine value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Quarantine 値を取得します。</summary>
    Quarantine = 7,
    /// <summary>EN: Gets the Transform value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Transform 値を取得します。</summary>
    Transform = 8,
    /// <summary>EN: Gets the Decompose value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Decompose 値を取得します。</summary>
    Decompose = 9,
    /// <summary>EN: Gets the DelegateToSolver value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DelegateToSolver 値を取得します。</summary>
    DelegateToSolver = 10,
    /// <summary>EN: Gets the NoExecution value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NoExecution 値を取得します。</summary>
    NoExecution = 11
}
