namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation snapshot writer 契約です。
/// </summary>
public interface IConversationSnapshotWriter
{
    Task SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation snapshot reader 契約です。
/// </summary>
public interface IConversationSnapshotReader
{
    Task<IConversationSnapshot?> GetSnapshotAsync(string snapshotId, CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation branch lister 契約です。
/// </summary>
public interface IConversationBranchLister
{
    Task<IReadOnlyList<IConversationBranch>> ListBranchesAsync(CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation snapshot deleter 契約です。
/// </summary>
public interface IConversationSnapshotDeleter
{
    Task DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationStore の互換合成 contract を定義します。
/// </summary>
public interface IConversationStore :
    IConversationSnapshotWriter,
    IConversationSnapshotReader,
    IConversationBranchLister,
    IConversationSnapshotDeleter
{
}
