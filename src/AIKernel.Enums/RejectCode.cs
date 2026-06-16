namespace AIKernel.Enums;

/// <summary>
/// EN: RejectCode の契約を定義します。
/// EN: Documentation for public API. JA: RejectCode の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.RejectCode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.RejectCode']" />
public enum RejectCode
{
    /// <summary>EN: Gets the AuthenticationFailed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AuthenticationFailed 値を取得します。</summary>
    AuthenticationFailed = 1,
    /// <summary>EN: Gets the AuthorizationFailed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AuthorizationFailed 値を取得します。</summary>
    AuthorizationFailed = 2,
    /// <summary>EN: Gets the ResourceNotFound value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ResourceNotFound 値を取得します。</summary>
    ResourceNotFound = 3,
    /// <summary>EN: Gets the PolicyViolation value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PolicyViolation 値を取得します。</summary>
    PolicyViolation = 4,
    /// <summary>EN: Gets the RateLimitExceeded value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RateLimitExceeded 値を取得します。</summary>
    RateLimitExceeded = 5,
    /// <summary>EN: Gets the ResourceUnavailable value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ResourceUnavailable 値を取得します。</summary>
    ResourceUnavailable = 6,
    /// <summary>EN: Gets the InsufficientPermissions value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される InsufficientPermissions 値を取得します。</summary>
    InsufficientPermissions = 7,
    /// <summary>EN: Gets the SessionExpired value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SessionExpired 値を取得します。</summary>
    SessionExpired = 8
}



