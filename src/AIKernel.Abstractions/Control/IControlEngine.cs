using AIKernel.Dtos.Control;

namespace AIKernel.Abstractions.Control;

/// <summary>EN: Documentation for public API. JA: IControlEngine contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IControlEngine']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IControlEngine']" />
public interface IControlEngine
{
    /// <summary>EN: Gets the EngineId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される EngineId 値を取得します。</summary>
    string EngineId { get; }

    /// <summary>EN: Executes the ExecuteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteAsync 操作を実行します。</summary>
    ValueTask<ControlExecutionResult> ExecuteAsync(
        IExecutionGraph graph,
        ControlExecutionRequest request,
        CancellationToken cancellationToken = default);
}
