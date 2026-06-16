namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmFallbackKind の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmFallbackKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmFallbackKind']" />
public enum DynamicSlmFallbackKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the None value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される None 値を取得します。</summary>
    None = 1,
    /// <summary>EN: Gets the Teacher value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Teacher 値を取得します。</summary>
    Teacher = 2,
    /// <summary>EN: Gets the Remote value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Remote 値を取得します。</summary>
    Remote = 3,
    /// <summary>EN: Gets the Cached value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Cached 値を取得します。</summary>
    Cached = 4,
    /// <summary>EN: Gets the HostPolicy value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HostPolicy 値を取得します。</summary>
    HostPolicy = 5
}
