namespace AIKernel.Abstractions.Governance;

using AIKernel.Dtos.Governance;

public interface ICriticalOperationGate
{
    ValueTask<CriticalOperationGateResult> EvaluateAsync(
        CriticalOperationProfile profile,
        CancellationToken cancellationToken = default);
}
