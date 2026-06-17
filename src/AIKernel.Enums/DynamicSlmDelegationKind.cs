namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmDelegationKind の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmDelegationKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmDelegationKind']" />
public enum DynamicSlmDelegationKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the None value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される None 値を取得します。</summary>
    None = 1,
    /// <summary>EN: Gets the Teacher value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Teacher 値を取得します。</summary>
    Teacher = 2,
    /// <summary>EN: Gets the Solver value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Solver 値を取得します。</summary>
    Solver = 3,
    /// <summary>EN: Gets the Remote value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Remote 値を取得します。</summary>
    Remote = 4
}
