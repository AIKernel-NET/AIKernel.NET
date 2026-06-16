namespace AIKernel.Enums;

/// <summary>EN: Documentation for public API. JA: DynamicSlmFailureKind の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmFailureKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmFailureKind']" />
public enum DynamicSlmFailureKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the FailClosed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FailClosed 値を取得します。</summary>
    FailClosed = 1,
    /// <summary>EN: Gets the CompatibilityRejected value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CompatibilityRejected 値を取得します。</summary>
    CompatibilityRejected = 2,
    /// <summary>EN: Gets the LineageRejected value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される LineageRejected 値を取得します。</summary>
    LineageRejected = 3,
    /// <summary>EN: Gets the CapabilityGraphRejected value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CapabilityGraphRejected 値を取得します。</summary>
    CapabilityGraphRejected = 4,
    /// <summary>EN: Gets the AdmissionRejected value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AdmissionRejected 値を取得します。</summary>
    AdmissionRejected = 5,
    /// <summary>EN: Gets the PayloadLoadFailed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PayloadLoadFailed 値を取得します。</summary>
    PayloadLoadFailed = 6,
    /// <summary>EN: Gets the SchedulingFailed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SchedulingFailed 値を取得します。</summary>
    SchedulingFailed = 7,
    /// <summary>EN: Gets the Quarantined value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Quarantined 値を取得します。</summary>
    Quarantined = 8,
    /// <summary>EN: Gets the StrictOutputViolation value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StrictOutputViolation 値を取得します。</summary>
    StrictOutputViolation = 9,
    /// <summary>EN: Gets the Delegated value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Delegated 値を取得します。</summary>
    Delegated = 10,
    /// <summary>EN: Gets the ThoughtArtifactMissing value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ThoughtArtifactMissing 値を取得します。</summary>
    ThoughtArtifactMissing = 11,
    /// <summary>EN: Gets the MemoryPlacementRejected value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される MemoryPlacementRejected 値を取得します。</summary>
    MemoryPlacementRejected = 12
}
