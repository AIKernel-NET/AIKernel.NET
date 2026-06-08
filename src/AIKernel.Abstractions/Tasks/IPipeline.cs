namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく IPipeline の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipeline']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipeline']" />
public interface IPipeline
{
    /// <summary>Gets the PipelineId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PipelineId 値を取得します。</summary>
    string PipelineId { get; }
    /// <summary>Gets the Name value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Name 値を取得します。</summary>
    string Name { get; }
    /// <summary>Gets the Description value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Description 値を取得します。</summary>
    string? Description { get; }
    /// <summary>Gets the Tasks value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Tasks 値を取得します。</summary>
    IReadOnlyList<ITask> Tasks { get; }
    /// <summary>Gets the Dependencies value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Dependencies 値を取得します。</summary>
    IReadOnlyDictionary<string, IReadOnlyList<string>> Dependencies { get; }
    /// <summary>Gets the Version value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Version 値を取得します。</summary>
    string Version { get; }
}




