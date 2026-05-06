namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく IPipelineExecutionResult の契約を定義します。
/// </summary>
public interface IPipelineExecutionResult
{
    string ExecutionId { get; }
    string PipelineId { get; }
    DateTime StartTime { get; }
    DateTime? EndTime { get; }
    bool Success { get; }
    string? FinalOutput { get; }
    IReadOnlyDictionary<string, ITaskExecutionResult> TaskResults { get; }
    string? Error { get; }
    string? ExecutionLog { get; }
}




