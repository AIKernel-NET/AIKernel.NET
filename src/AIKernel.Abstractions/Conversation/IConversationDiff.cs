namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// UC-15/UC-16/UC-17/UC-18 に基づく IConversationDiff の契約を定義します。
/// JA: IConversationDiff の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationDiff']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationDiff']" />
public interface IConversationDiff
{
    /// <summary>Gets the BaseSnapshotId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される BaseSnapshotId 値を取得します。</summary>
    string BaseSnapshotId { get; }
    /// <summary>Gets the TargetSnapshotId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TargetSnapshotId 値を取得します。</summary>
    string TargetSnapshotId { get; }
    /// <summary>Gets the ChangedSections value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ChangedSections 値を取得します。</summary>
    IReadOnlyList<string> ChangedSections { get; }
    /// <summary>Gets the HasConflicts value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HasConflicts 値を取得します。</summary>
    bool HasConflicts { get; }
}



