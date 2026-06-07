namespace AIKernel.Enums;

/// <summary>
/// ContextStage の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextStage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextStage']" />
public enum ContextStage
{
    /// <summary>Gets the Initialized value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Initialized 値を取得します。</summary>
    Initialized = 0,
    /// <summary>Gets the OrchestrationActive value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される OrchestrationActive 値を取得します。</summary>
    OrchestrationActive = 1,
    /// <summary>Gets the Materialized value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Materialized 値を取得します。</summary>
    Materialized = 2,
    /// <summary>Gets the Compressed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Compressed 値を取得します。</summary>
    Compressed = 3,
    /// <summary>Gets the Summarized value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Summarized 値を取得します。</summary>
    Summarized = 4,
    /// <summary>Gets the Cleared value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Cleared 値を取得します。</summary>
    Cleared = 5
}



