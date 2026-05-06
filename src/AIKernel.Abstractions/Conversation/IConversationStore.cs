namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationStore の契約を定義します。
/// </summary>
public interface IConversationStore
{
    Task SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default);
    Task<IConversationSnapshot?> GetSnapshotAsync(string snapshotId, CancellationToken ct = default);
    Task<IReadOnlyList<IConversationBranch>> ListBranchesAsync(CancellationToken ct = default);
    Task DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default);
}



