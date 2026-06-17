namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// EN: UC-15/UC-16/UC-17/UC-18 に基づく IConversationTimeline の契約を定義します。
/// [EN] Documents this public package API member. [JA] IConversationTimeline の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationTimeline']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationTimeline']" />
public interface IConversationTimeline
{
    /// <summary>EN: Executes the GetTimelineAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetTimelineAsync 操作を実行します。</summary>
    Task<IReadOnlyList<IConversationSnapshot>> GetTimelineAsync(string branchId, CancellationToken ct = default);
    /// <summary>EN: Executes the GetHeadAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetHeadAsync 操作を実行します。</summary>
    Task<IConversationSnapshot?> GetHeadAsync(string branchId, CancellationToken ct = default);
    /// <summary>EN: Executes the FindCheckpointAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで FindCheckpointAsync 操作を実行します。</summary>
    Task<IConversationCheckpoint?> FindCheckpointAsync(string checkpointId, CancellationToken ct = default);
}



