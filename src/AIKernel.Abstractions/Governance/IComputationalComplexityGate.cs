namespace AIKernel.Abstractions.Governance;

using AIKernel.Dtos.Governance;

public interface IComputationalComplexityGate
{
    ValueTask<ComplexityGateResult> EvaluateAsync(
        TaskComplexityProfile taskProfile,
        ModelExecutionBudget budget,
        CancellationToken cancellationToken = default);
}
