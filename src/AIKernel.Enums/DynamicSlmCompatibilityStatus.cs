namespace AIKernel.Enums;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmCompatibilityStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmCompatibilityStatus']" />
public enum DynamicSlmCompatibilityStatus
{
    /// <summary>Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>Gets the Compatible value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Compatible 値を取得します。</summary>
    Compatible = 1,
    /// <summary>Gets the Incompatible value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Incompatible 値を取得します。</summary>
    Incompatible = 2,
    /// <summary>Gets the RequiresAdapter value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RequiresAdapter 値を取得します。</summary>
    RequiresAdapter = 3,
    /// <summary>Gets the Quarantined value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Quarantined 値を取得します。</summary>
    Quarantined = 4
}
