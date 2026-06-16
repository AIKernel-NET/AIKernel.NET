namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// EN: UC-15/UC-16/UC-17/UC-18 に基づく IConversationBranch の契約を定義します。
/// EN: Documentation for public API. JA: IConversationBranch の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationBranch']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationBranch']" />
public interface IConversationBranch
{
    /// <summary>EN: Gets the BranchId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される BranchId 値を取得します。</summary>
    string BranchId { get; }
    /// <summary>EN: Gets the Name value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Name 値を取得します。</summary>
    string Name { get; }
    /// <summary>EN: Gets the HeadSnapshotId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HeadSnapshotId 値を取得します。</summary>
    string HeadSnapshotId { get; }
    /// <summary>EN: Executes the ForkFromAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ForkFromAsync 操作を実行します。</summary>
    Task<IConversationBranch> ForkFromAsync(string snapshotId, string newBranchName, CancellationToken ct = default);
}



