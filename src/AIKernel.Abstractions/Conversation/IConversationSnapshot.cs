namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationSnapshot の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationSnapshot']" />
public interface IConversationSnapshot
{
    /// <summary>Gets the SnapshotId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SnapshotId 値を取得します。</summary>
    string SnapshotId { get; }
    /// <summary>Gets the BranchId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される BranchId 値を取得します。</summary>
    string BranchId { get; }
    /// <summary>Gets the TimestampUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TimestampUtc 値を取得します。</summary>
    DateTimeOffset TimestampUtc { get; }
    /// <summary>Gets the MessageCount value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される MessageCount 値を取得します。</summary>
    int MessageCount { get; }
}



