namespace AIKernel.Abstractions.Context;

/// <summary>
/// UC-06/UC-08 に基づく IContextSnapshot の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextSnapshot']" />
public interface IContextSnapshot
{
    /// <summary>Gets the SnapshotId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SnapshotId 値を取得します。</summary>
    string SnapshotId { get; }
    /// <summary>Gets the ParentSnapshotId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ParentSnapshotId 値を取得します。</summary>
    string? ParentSnapshotId { get; }
    /// <summary>Gets the CreatedAtUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CreatedAtUtc 値を取得します。</summary>
    DateTimeOffset CreatedAtUtc { get; }
    /// <summary>Gets the ContextHash value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ContextHash 値を取得します。</summary>
    string ContextHash { get; }
    /// <summary>Gets the Context value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Context 値を取得します。</summary>
    IContextCollection Context { get; }
}



