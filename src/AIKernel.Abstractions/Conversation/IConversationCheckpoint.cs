namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationCheckpoint の契約を定義します。
/// </summary>
public interface IConversationCheckpoint
{
    string CheckpointId { get; }
    string SnapshotId { get; }
    string Label { get; }
    DateTimeOffset PinnedAtUtc { get; }
}



