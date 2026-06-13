namespace AIKernel.Enums;

/// <summary>
/// Modality の契約を定義します。
/// JA: Modality の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.Modality']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.Modality']" />
public enum Modality
{
    /// <summary>Gets the Text value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Text 値を取得します。</summary>
    Text = 1,
    /// <summary>Gets the Image value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Image 値を取得します。</summary>
    Image = 2,
    /// <summary>Gets the Audio value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Audio 値を取得します。</summary>
    Audio = 3,
    /// <summary>Gets the Video value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Video 値を取得します。</summary>
    Video = 4,
    /// <summary>Gets the StructuredData value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StructuredData 値を取得します。</summary>
    StructuredData = 5,
    /// <summary>Gets the Binary value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Binary 値を取得します。</summary>
    Binary = 6,
    /// <summary>Gets the TimeSeries value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TimeSeries 値を取得します。</summary>
    TimeSeries = 7
}



