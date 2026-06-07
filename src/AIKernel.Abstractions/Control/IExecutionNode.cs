namespace AIKernel.Abstractions.Control;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IExecutionNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IExecutionNode']" />
public interface IExecutionNode
{
    /// <summary>Gets the NodeId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NodeId 値を取得します。</summary>
    string NodeId { get; }

    /// <summary>Gets the OperatorId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される OperatorId 値を取得します。</summary>
    string OperatorId { get; }

    /// <summary>Gets the Metadata value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Metadata 値を取得します。</summary>
    IReadOnlyDictionary<string, string> Metadata { get; }
}
