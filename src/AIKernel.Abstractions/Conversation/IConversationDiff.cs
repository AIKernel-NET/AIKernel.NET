namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationDiff の契約を定義します。
/// </summary>
public interface IConversationDiff
{
    string BaseSnapshotId { get; }
    string TargetSnapshotId { get; }
    IReadOnlyList<string> ChangedSections { get; }
    bool HasConflicts { get; }
}



