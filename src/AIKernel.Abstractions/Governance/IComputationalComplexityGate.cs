namespace AIKernel.Abstractions.Governance;

using AIKernel.Dtos.Governance;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IComputationalComplexityGate']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IComputationalComplexityGate']" />
public interface IComputationalComplexityGate
{
    /// <summary>Executes the EvaluateAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EvaluateAsync 操作を実行します。</summary>
    ValueTask<ComplexityGateResult> EvaluateAsync(
        TaskComplexityProfile taskProfile,
        ModelExecutionBudget budget,
        CancellationToken cancellationToken = default);
}
