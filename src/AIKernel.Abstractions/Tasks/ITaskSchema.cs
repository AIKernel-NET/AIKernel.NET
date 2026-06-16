namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// EN: UC-29 に基づく ITaskSchema の契約を定義します。
/// EN: Documentation for public API. JA: ITaskSchema の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskSchema']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskSchema']" />
public interface ITaskSchema
{
    /// <summary>EN: Gets the Name value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Name 値を取得します。</summary>
    string Name { get; }
    /// <summary>EN: Gets the Version value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Version 値を取得します。</summary>
    string Version { get; }
    /// <summary>EN: Gets the Fields value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Fields 値を取得します。</summary>
    IReadOnlyDictionary<string, string> Fields { get; }
}




