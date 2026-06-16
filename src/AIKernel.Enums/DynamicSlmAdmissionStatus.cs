namespace AIKernel.Enums;

/// <summary>EN: Documentation for public API. JA: DynamicSlmAdmissionStatus の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmAdmissionStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmAdmissionStatus']" />
public enum DynamicSlmAdmissionStatus
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Accepted value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Accepted 値を取得します。</summary>
    Accepted = 1,
    /// <summary>EN: Gets the Rejected value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Rejected 値を取得します。</summary>
    Rejected = 2,
    /// <summary>EN: Gets the Quarantined value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Quarantined 値を取得します。</summary>
    Quarantined = 3
}
