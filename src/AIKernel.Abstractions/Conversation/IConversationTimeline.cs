namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationTimeline の契約を定義します。
/// </summary>
public interface IConversationTimeline
{
    Task<IReadOnlyList<IConversationSnapshot>> GetTimelineAsync(string branchId, CancellationToken ct = default);
    Task<IConversationSnapshot?> GetHeadAsync(string branchId, CancellationToken ct = default);
    Task<IConversationCheckpoint?> FindCheckpointAsync(string checkpointId, CancellationToken ct = default);
}



