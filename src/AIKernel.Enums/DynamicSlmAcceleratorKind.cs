namespace AIKernel.Enums;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmAcceleratorKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmAcceleratorKind']" />
public enum DynamicSlmAcceleratorKind
{
    /// <summary>Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>Gets the Cpu value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Cpu 値を取得します。</summary>
    Cpu = 1,
    /// <summary>Gets the Gpu value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Gpu 値を取得します。</summary>
    Gpu = 2,
    /// <summary>Gets the Npu value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Npu 値を取得します。</summary>
    Npu = 3,
    /// <summary>Gets the Tpu value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Tpu 値を取得します。</summary>
    Tpu = 4,
    /// <summary>Gets the Other value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Other 値を取得します。</summary>
    Other = 5
}
