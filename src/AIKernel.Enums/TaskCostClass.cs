namespace AIKernel.Enums;

/// <summary>
/// EN: Conservative computational cost class used by pre-inference admissibility gates.
/// EN: Documentation for public API. JA: TaskCostClass の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.TaskCostClass']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.TaskCostClass']" />
public enum TaskCostClass
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Trivial value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Trivial 値を取得します。</summary>
    Trivial = 1,
    /// <summary>EN: Gets the Linear value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Linear 値を取得します。</summary>
    Linear = 2,
    /// <summary>EN: Gets the PolynomialSmall value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PolynomialSmall 値を取得します。</summary>
    PolynomialSmall = 3,
    /// <summary>EN: Gets the PolynomialLarge value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PolynomialLarge 値を取得します。</summary>
    PolynomialLarge = 4,
    /// <summary>EN: Gets the Exponential value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Exponential 値を取得します。</summary>
    Exponential = 5,
    /// <summary>EN: Gets the StateExplosive value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StateExplosive 値を取得します。</summary>
    StateExplosive = 6,
    /// <summary>EN: Gets the VerificationHard value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される VerificationHard 値を取得します。</summary>
    VerificationHard = 7,
    /// <summary>EN: Gets the SelfReferential value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SelfReferential 値を取得します。</summary>
    SelfReferential = 8,
    /// <summary>EN: Gets the Unbounded value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unbounded 値を取得します。</summary>
    Unbounded = 9
}
