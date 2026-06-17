namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmPipelineStatus の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmPipelineStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmPipelineStatus']" />
public enum DynamicSlmPipelineStatus
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Success value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Success 値を取得します。</summary>
    Success = 1,
    /// <summary>EN: Gets the Failure value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Failure 値を取得します。</summary>
    Failure = 2,
    /// <summary>EN: Gets the OffloadPending value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される OffloadPending 値を取得します。</summary>
    OffloadPending = 3,
    /// <summary>EN: Gets the FallbackUsed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FallbackUsed 値を取得します。</summary>
    FallbackUsed = 4
}
