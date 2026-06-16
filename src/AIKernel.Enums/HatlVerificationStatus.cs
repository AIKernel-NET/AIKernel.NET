namespace AIKernel.Enums;

/// <summary>EN: Documentation for public API. JA: HatlVerificationStatus の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.HatlVerificationStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.HatlVerificationStatus']" />
public enum HatlVerificationStatus
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Valid value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Valid 値を取得します。</summary>
    Valid = 1,
    /// <summary>EN: Gets the Invalid value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Invalid 値を取得します。</summary>
    Invalid = 2,
    /// <summary>EN: Gets the Indeterminate value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Indeterminate 値を取得します。</summary>
    Indeterminate = 3,
    /// <summary>EN: Gets the Denied value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Denied 値を取得します。</summary>
    Denied = 4
}
