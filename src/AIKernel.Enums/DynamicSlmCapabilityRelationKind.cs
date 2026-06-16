namespace AIKernel.Enums;

/// <summary>EN: Documentation for public API. JA: DynamicSlmCapabilityRelationKind の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmCapabilityRelationKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmCapabilityRelationKind']" />
public enum DynamicSlmCapabilityRelationKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Requires value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Requires 値を取得します。</summary>
    Requires = 1,
    /// <summary>EN: Gets the Refines value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Refines 値を取得します。</summary>
    Refines = 2,
    /// <summary>EN: Gets the Replaces value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Replaces 値を取得します。</summary>
    Replaces = 3,
    /// <summary>EN: Gets the Observes value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Observes 値を取得します。</summary>
    Observes = 4
}
