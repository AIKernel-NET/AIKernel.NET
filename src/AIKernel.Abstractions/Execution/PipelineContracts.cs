namespace AIKernel.Abstractions.Execution;

/// <summary>
/// IPipelineStep の契約を定義します。
/// </summary>
public interface IPipelineStep
{
    string StepId { get; }
    IReadOnlyList<string> DependsOn { get; }
    Task<AIKernel.Dtos.Execution.ExecutionResult> ExecuteAsync(Hosting.IKernelContext context, CancellationToken ct = default);
}




