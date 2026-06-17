namespace AIKernel.Enums;

/// <summary>
/// EN: ContextStage の契約を定義します。
/// [EN] Documents this public package API member. [JA] ContextStage の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextStage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextStage']" />
public enum ContextStage
{
    /// <summary>EN: Gets the Initialized value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Initialized 値を取得します。</summary>
    Initialized = 0,
    /// <summary>EN: Gets the OrchestrationActive value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される OrchestrationActive 値を取得します。</summary>
    OrchestrationActive = 1,
    /// <summary>EN: Gets the Materialized value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Materialized 値を取得します。</summary>
    Materialized = 2,
    /// <summary>EN: Gets the Compressed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Compressed 値を取得します。</summary>
    Compressed = 3,
    /// <summary>EN: Gets the Summarized value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Summarized 値を取得します。</summary>
    Summarized = 4,
    /// <summary>EN: Gets the Cleared value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Cleared 値を取得します。</summary>
    Cleared = 5
}



