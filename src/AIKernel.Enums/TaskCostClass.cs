namespace AIKernel.Enums;

/// <summary>
/// Conservative computational cost class used by pre-inference admissibility gates.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.TaskCostClass']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.TaskCostClass']" />
public enum TaskCostClass
{
    /// <summary>Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>Gets the Trivial value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Trivial 値を取得します。</summary>
    Trivial = 1,
    /// <summary>Gets the Linear value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Linear 値を取得します。</summary>
    Linear = 2,
    /// <summary>Gets the PolynomialSmall value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PolynomialSmall 値を取得します。</summary>
    PolynomialSmall = 3,
    /// <summary>Gets the PolynomialLarge value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PolynomialLarge 値を取得します。</summary>
    PolynomialLarge = 4,
    /// <summary>Gets the Exponential value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Exponential 値を取得します。</summary>
    Exponential = 5,
    /// <summary>Gets the StateExplosive value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StateExplosive 値を取得します。</summary>
    StateExplosive = 6,
    /// <summary>Gets the VerificationHard value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される VerificationHard 値を取得します。</summary>
    VerificationHard = 7,
    /// <summary>Gets the SelfReferential value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SelfReferential 値を取得します。</summary>
    SelfReferential = 8,
    /// <summary>Gets the Unbounded value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unbounded 値を取得します。</summary>
    Unbounded = 9
}
