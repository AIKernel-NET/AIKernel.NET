namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmDelegationReason の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmDelegationReason']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmDelegationReason']" />
public enum DynamicSlmDelegationReason
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the CapabilityGap value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CapabilityGap 値を取得します。</summary>
    CapabilityGap = 1,
    /// <summary>EN: Gets the ContractViolationRisk value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ContractViolationRisk 値を取得します。</summary>
    ContractViolationRisk = 2,
    /// <summary>EN: Gets the InsufficientConfidence value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される InsufficientConfidence 値を取得します。</summary>
    InsufficientConfidence = 3,
    /// <summary>EN: Gets the UnsupportedOutputSchema value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される UnsupportedOutputSchema 値を取得します。</summary>
    UnsupportedOutputSchema = 4,
    /// <summary>EN: Gets the SafetyBoundary value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SafetyBoundary 値を取得します。</summary>
    SafetyBoundary = 5
}
