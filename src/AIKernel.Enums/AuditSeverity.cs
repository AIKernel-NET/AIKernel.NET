namespace AIKernel.Enums;

/// <summary>
/// EN: AuditSeverity の契約を定義します。
/// EN: Documentation for public API. JA: AuditSeverity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.AuditSeverity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.AuditSeverity']" />
public enum AuditSeverity
{
    /// <summary>EN: Gets the Information value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Information 値を取得します。</summary>
    Information = 1,
    /// <summary>EN: Gets the Warning value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Warning 値を取得します。</summary>
    Warning = 2,
    /// <summary>EN: Gets the Error value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Error 値を取得します。</summary>
    Error = 3,
    /// <summary>EN: Gets the Critical value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Critical 値を取得します。</summary>
    Critical = 4
}



