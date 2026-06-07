namespace AIKernel.Abstractions.Control;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IExecutionGraph']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IExecutionGraph']" />
public interface IExecutionGraph
{
    /// <summary>Gets the GraphId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される GraphId 値を取得します。</summary>
    string GraphId { get; }

    /// <summary>Gets the Nodes value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Nodes 値を取得します。</summary>
    IReadOnlyList<IExecutionNode> Nodes { get; }
}
