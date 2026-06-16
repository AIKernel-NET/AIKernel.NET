namespace AIKernel.Abstractions.Conversation;

/// <summary>
/// EN: UC-15/UC-16/UC-17/UC-18 に基づく IConversationCheckpoint の契約を定義します。
/// EN: Documentation for public API. JA: IConversationCheckpoint の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationCheckpoint']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Conversation.IConversationCheckpoint']" />
public interface IConversationCheckpoint
{
    /// <summary>EN: Gets the CheckpointId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CheckpointId 値を取得します。</summary>
    string CheckpointId { get; }
    /// <summary>EN: Gets the SnapshotId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SnapshotId 値を取得します。</summary>
    string SnapshotId { get; }
    /// <summary>EN: Gets the Label value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Label 値を取得します。</summary>
    string Label { get; }
    /// <summary>EN: Gets the PinnedAtUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PinnedAtUtc 値を取得します。</summary>
    DateTimeOffset PinnedAtUtc { get; }
}



