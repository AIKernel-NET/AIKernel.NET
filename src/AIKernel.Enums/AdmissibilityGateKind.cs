namespace AIKernel.Enums;

/// <summary>
/// Identifies a pre-inference admissibility gate that may emit replay evidence.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.AdmissibilityGateKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.AdmissibilityGateKind']" />
public enum AdmissibilityGateKind
{
    /// <summary>Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>Gets the PromptOverride value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PromptOverride 値を取得します。</summary>
    PromptOverride = 1,
    /// <summary>Gets the CapabilityAdmission value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CapabilityAdmission 値を取得します。</summary>
    CapabilityAdmission = 2,
    /// <summary>Gets the CriticalOperation value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CriticalOperation 値を取得します。</summary>
    CriticalOperation = 3,
    /// <summary>Gets the ComputationalComplexity value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ComputationalComplexity 値を取得します。</summary>
    ComputationalComplexity = 4,
    /// <summary>Gets the PolicyDecision value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PolicyDecision 値を取得します。</summary>
    PolicyDecision = 5,
    /// <summary>Gets the ContextIntegrity value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ContextIntegrity 値を取得します。</summary>
    ContextIntegrity = 6,
    /// <summary>Gets the RuntimeInvariant value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RuntimeInvariant 値を取得します。</summary>
    RuntimeInvariant = 7
}
