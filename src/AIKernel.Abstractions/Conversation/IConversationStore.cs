namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation snapshot writer 契約です。
/// JA: IConversationSnapshotWriter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshotWriter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshotWriter']" />
public interface IConversationSnapshotWriter
{
    /// <summary>Executes the SaveSnapshotAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SaveSnapshotAsync 操作を実行します。</summary>
    Task SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation snapshot reader 契約です。
/// JA: IConversationSnapshotReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshotReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshotReader']" />
public interface IConversationSnapshotReader
{
    /// <summary>Executes the GetSnapshotAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetSnapshotAsync 操作を実行します。</summary>
    Task<IConversationSnapshot?> GetSnapshotAsync(string snapshotId, CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation branch lister 契約です。
/// JA: IConversationBranchLister の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationBranchLister']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationBranchLister']" />
public interface IConversationBranchLister
{
    /// <summary>Executes the ListBranchesAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ListBranchesAsync 操作を実行します。</summary>
    Task<IReadOnlyList<IConversationBranch>> ListBranchesAsync(CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく conversation snapshot deleter 契約です。
/// JA: IConversationSnapshotDeleter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshotDeleter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshotDeleter']" />
public interface IConversationSnapshotDeleter
{
    /// <summary>Executes the DeleteSnapshotAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで DeleteSnapshotAsync 操作を実行します。</summary>
    Task DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default);
}

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationStore の互換合成 contract を定義します。
/// JA: IConversationStore の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationStore']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationStore']" />
public interface IConversationStore :
    IConversationSnapshotWriter,
    IConversationSnapshotReader,
    IConversationBranchLister,
    IConversationSnapshotDeleter
{
}
