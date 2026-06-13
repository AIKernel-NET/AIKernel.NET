namespace AIKernel.Enums;

/// <summary>
/// ModelType の契約を定義します。
/// JA: ModelType の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.ModelType']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.ModelType']" />
public enum ModelType
{
    /// <summary>Gets the LanguageModel value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される LanguageModel 値を取得します。</summary>
    LanguageModel = 1,
    /// <summary>Gets the ImageGeneration value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ImageGeneration 値を取得します。</summary>
    ImageGeneration = 2,
    /// <summary>Gets the ImageRecognition value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ImageRecognition 値を取得します。</summary>
    ImageRecognition = 3,
    /// <summary>Gets the SpeechRecognition value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SpeechRecognition 値を取得します。</summary>
    SpeechRecognition = 4,
    /// <summary>Gets the TextToSpeech value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TextToSpeech 値を取得します。</summary>
    TextToSpeech = 5,
    /// <summary>Gets the MultiModal value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される MultiModal 値を取得します。</summary>
    MultiModal = 6,
    /// <summary>Gets the Embedding value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Embedding 値を取得します。</summary>
    Embedding = 7,
    /// <summary>Gets the Classification value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Classification 値を取得します。</summary>
    Classification = 8,
    /// <summary>Gets the Custom value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Custom 値を取得します。</summary>
    Custom = 9
}



