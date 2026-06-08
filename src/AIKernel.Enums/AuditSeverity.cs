namespace AIKernel.Enums;

/// <summary>
/// AuditSeverity の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.AuditSeverity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.AuditSeverity']" />
public enum AuditSeverity
{
    /// <summary>Gets the Information value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Information 値を取得します。</summary>
    Information = 1,
    /// <summary>Gets the Warning value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Warning 値を取得します。</summary>
    Warning = 2,
    /// <summary>Gets the Error value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Error 値を取得します。</summary>
    Error = 3,
    /// <summary>Gets the Critical value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Critical 値を取得します。</summary>
    Critical = 4
}



