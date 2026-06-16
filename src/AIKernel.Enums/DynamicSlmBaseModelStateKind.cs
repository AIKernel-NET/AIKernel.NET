namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmBaseModelStateKind の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmBaseModelStateKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmBaseModelStateKind']" />
public enum DynamicSlmBaseModelStateKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Null value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Null 値を取得します。</summary>
    Null = 1,
    /// <summary>EN: Gets the Adapted value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Adapted 値を取得します。</summary>
    Adapted = 2,
    /// <summary>EN: Gets the HotSwap value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HotSwap 値を取得します。</summary>
    HotSwap = 3
}
