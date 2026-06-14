namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IDiffFormatter の契約を定義します。
/// JA: IDiffFormatter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IDiffFormatter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IDiffFormatter']" />
public interface IDiffFormatter
{
    /// <summary>Executes the Format operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Format 操作を実行します。</summary>
    string Format(IConversationDiff diff);
    /// <summary>Executes the FormatAsMarkdown operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで FormatAsMarkdown 操作を実行します。</summary>
    string FormatAsMarkdown(IConversationDiff diff);
    /// <summary>Executes the FormatAsJson operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで FormatAsJson 操作を実行します。</summary>
    string FormatAsJson(IConversationDiff diff);
}



