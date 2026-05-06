namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationSnapshot の契約を定義します。
/// </summary>
public interface IConversationSnapshot
{
    string SnapshotId { get; }
    string BranchId { get; }
    DateTimeOffset TimestampUtc { get; }
    int MessageCount { get; }
}



