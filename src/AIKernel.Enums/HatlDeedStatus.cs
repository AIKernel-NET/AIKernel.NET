namespace AIKernel.Enums;

/// <summary>EN: Documentation for public API. JA: HatlDeedStatus の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.HatlDeedStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.HatlDeedStatus']" />
public enum HatlDeedStatus
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Active value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Active 値を取得します。</summary>
    Active = 1,
    /// <summary>EN: Gets the Suspended value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Suspended 値を取得します。</summary>
    Suspended = 2,
    /// <summary>EN: Gets the Revoked value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Revoked 値を取得します。</summary>
    Revoked = 3,
    /// <summary>EN: Gets the Expired value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Expired 値を取得します。</summary>
    Expired = 4
}
