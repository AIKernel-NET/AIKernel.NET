namespace AIKernel.Enums;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.PromptOverflowPolicy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.PromptOverflowPolicy']" />
public enum PromptOverflowPolicy
{
    /// <summary>Gets the FailClosed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FailClosed 値を取得します。</summary>
    FailClosed = 0,

    /// <summary>Gets the TruncateLowestPriorityContext value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TruncateLowestPriorityContext 値を取得します。</summary>
    TruncateLowestPriorityContext = 1
}
