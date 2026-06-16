namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// EN: UC-29 に基づく IPipeline の契約を定義します。
/// EN: Documentation for public API. JA: IPipeline の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipeline']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.IPipeline']" />
public interface IPipeline
{
    /// <summary>EN: Gets the PipelineId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PipelineId 値を取得します。</summary>
    string PipelineId { get; }
    /// <summary>EN: Gets the Name value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Name 値を取得します。</summary>
    string Name { get; }
    /// <summary>EN: Gets the Description value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Description 値を取得します。</summary>
    string? Description { get; }
    /// <summary>EN: Gets the Tasks value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Tasks 値を取得します。</summary>
    IReadOnlyList<ITask> Tasks { get; }
    /// <summary>EN: Gets the Dependencies value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Dependencies 値を取得します。</summary>
    IReadOnlyDictionary<string, IReadOnlyList<string>> Dependencies { get; }
    /// <summary>EN: Gets the Version value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Version 値を取得します。</summary>
    string Version { get; }
}




