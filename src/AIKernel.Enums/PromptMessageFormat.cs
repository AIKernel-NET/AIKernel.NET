namespace AIKernel.Enums;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.PromptMessageFormat']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.PromptMessageFormat']" />
public enum PromptMessageFormat
{
    /// <summary>Gets the ChatMessages value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ChatMessages 値を取得します。</summary>
    ChatMessages = 0,

    /// <summary>Gets the SingleTextPrompt value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SingleTextPrompt 値を取得します。</summary>
    SingleTextPrompt = 1,

    /// <summary>Gets the AlternatingMessages value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AlternatingMessages 値を取得します。</summary>
    AlternatingMessages = 2
}
