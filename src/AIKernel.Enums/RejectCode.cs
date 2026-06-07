namespace AIKernel.Enums;

/// <summary>
/// RejectCode の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.RejectCode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.RejectCode']" />
public enum RejectCode
{
    /// <summary>Gets the AuthenticationFailed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AuthenticationFailed 値を取得します。</summary>
    AuthenticationFailed = 1,
    /// <summary>Gets the AuthorizationFailed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AuthorizationFailed 値を取得します。</summary>
    AuthorizationFailed = 2,
    /// <summary>Gets the ResourceNotFound value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ResourceNotFound 値を取得します。</summary>
    ResourceNotFound = 3,
    /// <summary>Gets the PolicyViolation value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PolicyViolation 値を取得します。</summary>
    PolicyViolation = 4,
    /// <summary>Gets the RateLimitExceeded value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RateLimitExceeded 値を取得します。</summary>
    RateLimitExceeded = 5,
    /// <summary>Gets the ResourceUnavailable value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ResourceUnavailable 値を取得します。</summary>
    ResourceUnavailable = 6,
    /// <summary>Gets the InsufficientPermissions value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される InsufficientPermissions 値を取得します。</summary>
    InsufficientPermissions = 7,
    /// <summary>Gets the SessionExpired value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SessionExpired 値を取得します。</summary>
    SessionExpired = 8
}



