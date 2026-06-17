namespace AIKernel.Abstractions.Control;

/// <summary>[EN] Documents this public package API member. [JA] IExecutionNode contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IExecutionNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IExecutionNode']" />
public interface IExecutionNode
{
    /// <summary>EN: Gets the NodeId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NodeId 値を取得します。</summary>
    string NodeId { get; }

    /// <summary>EN: Gets the OperatorId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される OperatorId 値を取得します。</summary>
    string OperatorId { get; }

    /// <summary>EN: Gets the Metadata value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Metadata 値を取得します。</summary>
    IReadOnlyDictionary<string, string> Metadata { get; }
}
