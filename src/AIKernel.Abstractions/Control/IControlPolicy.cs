using AIKernel.Dtos.Control;

namespace AIKernel.Abstractions.Control;

/// <summary>[EN] Documents this public package API member. [JA] IControlPolicy contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IControlPolicy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Control.IControlPolicy']" />
public interface IControlPolicy
{
    /// <summary>EN: Executes the EvaluateAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EvaluateAsync 操作を実行します。</summary>
    ValueTask<ControlPolicyEvaluation> EvaluateAsync(
        IExecutionGraph graph,
        ControlExecutionRequest request,
        CancellationToken cancellationToken = default);
}
