namespace AIKernel.Enums;

/// <summary>
/// EN: Declares the invocation boundary used for an external capability.
/// EN: Documentation for public API. JA: CapabilityInvocationMode の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.CapabilityInvocationMode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.CapabilityInvocationMode']" />
public enum CapabilityInvocationMode
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the Direct value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Direct 値を取得します。</summary>
    Direct = 1,
    /// <summary>EN: Gets the Sandbox value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Sandbox 値を取得します。</summary>
    Sandbox = 2,
    /// <summary>EN: Gets the AssemblyReference value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AssemblyReference 値を取得します。</summary>
    AssemblyReference = 3,
    /// <summary>EN: Gets the NativeAbi value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NativeAbi 値を取得します。</summary>
    NativeAbi = 4,
    /// <summary>EN: Gets the DslPipeline value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DslPipeline 値を取得します。</summary>
    DslPipeline = 5,
    /// <summary>EN: Gets the Remote value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Remote 値を取得します。</summary>
    Remote = 6
}
