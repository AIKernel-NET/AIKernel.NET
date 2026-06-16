namespace AIKernel.Abstractions.Execution;

/// <summary>
/// EN: UC-02/UC-04/UC-09/UC-20/UC-22 に基づく IPhaseHandover の契約を定義します。
/// EN: Documentation for public API. JA: IPhaseHandover の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPhaseHandover']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPhaseHandover']" />
public interface IPhaseHandover
{
    /// <summary>EN: Executes the ValidateHandoverAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateHandoverAsync 操作を実行します。</summary>
    Task<PhaseHandoverResult> ValidateHandoverAsync(
        IExecutionOutput output,
        string nextPhase,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the RestageForNextPhaseAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RestageForNextPhaseAsync 操作を実行します。</summary>
    Task<IExecutionOutput> RestageForNextPhaseAsync(
        IExecutionOutput output,
        string nextPhase,
        CancellationToken cancellationToken = default);
}




