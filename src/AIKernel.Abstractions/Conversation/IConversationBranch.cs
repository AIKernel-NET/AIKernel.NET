namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationBranch の契約を定義します。
/// </summary>
public interface IConversationBranch
{
    string BranchId { get; }
    string Name { get; }
    string HeadSnapshotId { get; }
    Task<IConversationBranch> ForkFromAsync(string snapshotId, string newBranchName, CancellationToken ct = default);
}



