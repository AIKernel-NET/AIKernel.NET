namespace AIKernel.Enums;

/// <summary>
/// ContextCategory の契約を定義します。
/// JA: ContextCategory の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextCategory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextCategory']" />
public enum ContextCategory
{
    /// <summary>Gets the Orchestration value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Orchestration 値を取得します。</summary>
    Orchestration = 1,
    /// <summary>Gets the Material value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Material 値を取得します。</summary>
    Material = 2,
    /// <summary>Gets the Expression value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Expression 値を取得します。</summary>
    Expression = 3,
    /// <summary>Gets the Governance value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Governance 値を取得します。</summary>
    Governance = 4,
    /// <summary>Gets the History value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される History 値を取得します。</summary>
    History = 5
}



