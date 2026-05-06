namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく ITaskManager の契約を定義します。
/// </summary>
public interface ITaskManager
{
    Task<string> RegisterPipelineAsync(IPipeline pipeline);
    Task<IPipelineExecutionResult> ExecutePipelineAsync(string pipelineId, ITaskContext context, CancellationToken cancellationToken = default);
    Task<ITaskExecutionResult> ExecuteTaskAsync(ITask task, ITaskContext context, CancellationToken cancellationToken = default);
    Task<bool> PausePipelineAsync(string executionId);
    Task<bool> ResumePipelineAsync(string executionId);
    Task<bool> CancelPipelineAsync(string executionId);
    Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId);
}




