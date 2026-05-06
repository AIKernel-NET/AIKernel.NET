namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IDiffFormatter の契約を定義します。
/// </summary>
public interface IDiffFormatter
{
    string Format(IConversationDiff diff);
    string FormatAsMarkdown(IConversationDiff diff);
    string FormatAsJson(IConversationDiff diff);
}



