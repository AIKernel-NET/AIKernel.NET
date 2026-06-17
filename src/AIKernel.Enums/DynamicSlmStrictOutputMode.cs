namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmStrictOutputMode の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmStrictOutputMode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmStrictOutputMode']" />
public enum DynamicSlmStrictOutputMode
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the SchemaOnly value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SchemaOnly 値を取得します。</summary>
    SchemaOnly = 1,
    /// <summary>EN: Gets the JsonOnly value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される JsonOnly 値を取得します。</summary>
    JsonOnly = 2,
    /// <summary>EN: Gets the ReplayLogCompatible value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReplayLogCompatible 値を取得します。</summary>
    ReplayLogCompatible = 3,
    /// <summary>EN: Gets the ZeroSlop value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ZeroSlop 値を取得します。</summary>
    ZeroSlop = 4
}
