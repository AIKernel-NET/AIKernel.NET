namespace AIKernel.Enums;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmPayloadKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmPayloadKind']" />
public enum DynamicSlmPayloadKind
{
    /// <summary>Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>Gets the BaseWeights value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される BaseWeights 値を取得します。</summary>
    BaseWeights = 1,
    /// <summary>Gets the Adapter value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Adapter 値を取得します。</summary>
    Adapter = 2,
    /// <summary>Gets the LoRaDelta value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される LoRaDelta 値を取得します。</summary>
    LoRaDelta = 3,
    /// <summary>Gets the QLoRaDelta value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される QLoRaDelta 値を取得します。</summary>
    QLoRaDelta = 4,
    /// <summary>Gets the QuantizedBlock value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される QuantizedBlock 値を取得します。</summary>
    QuantizedBlock = 5,
    /// <summary>Gets the TokenizerFragment value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TokenizerFragment 値を取得します。</summary>
    TokenizerFragment = 6,
    /// <summary>Gets the ExecutableSegment value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExecutableSegment 値を取得します。</summary>
    ExecutableSegment = 7,
    /// <summary>Gets the SeedBase value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SeedBase 値を取得します。</summary>
    SeedBase = 8,
    /// <summary>Gets the CapabilityPage value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CapabilityPage 値を取得します。</summary>
    CapabilityPage = 9
}
