namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく IPhaseHandover の契約を定義します。
/// </summary>
public interface IPhaseHandover
{
    Task<PhaseHandoverResult> ValidateHandoverAsync(
        IExecutionOutput output,
        string nextPhase,
        CancellationToken cancellationToken = default);

    Task<IExecutionOutput> RestageForNextPhaseAsync(
        IExecutionOutput output,
        string nextPhase,
        CancellationToken cancellationToken = default);
}




