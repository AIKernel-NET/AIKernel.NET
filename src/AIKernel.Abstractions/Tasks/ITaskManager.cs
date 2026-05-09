namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 登録を行う capability interface です。
/// </summary>
public interface IPipelineRegistrar
{
    Task<string> RegisterPipelineAsync(IPipeline pipeline);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 実行を行う capability interface です。
/// </summary>
public interface IPipelineExecutor
{
    Task<IPipelineExecutionResult> ExecutePipelineAsync(string pipelineId, ITaskContext context, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Task 実行を行う capability interface です。
/// </summary>
public interface ITaskExecutor
{
    Task<ITaskExecutionResult> ExecuteTaskAsync(ITask task, ITaskContext context, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 実行状態を制御する capability interface です。
/// </summary>
public interface IPipelineExecutionController
{
    Task<bool> PausePipelineAsync(string executionId);

    Task<bool> ResumePipelineAsync(string executionId);

    Task<bool> CancelPipelineAsync(string executionId);
}

/// <summary>
/// UC-29 に基づく契約です。
/// Pipeline 実行結果を参照する capability interface です。
/// </summary>
public interface IPipelineExecutionResultReader
{
    Task<IPipelineExecutionResult?> GetExecutionResultAsync(string executionId);
}

/// <summary>
/// UC-29 に基づく ITaskManager の互換合成 contract を定義します。
/// </summary>
public interface ITaskManager :
    IPipelineRegistrar,
    IPipelineExecutor,
    ITaskExecutor,
    IPipelineExecutionController,
    IPipelineExecutionResultReader
{
}
