namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく ITaskContext の契約を定義します。
/// </summary>
public interface ITaskContext
{
    string ExecutionId { get; }
    string PipelineId { get; }
    UnifiedContextDto? ContextContract { get; }
    IReadOnlyDictionary<string, string?> GetInputParameters();
    void SetInputParameter(string key, string? value);
    ITaskExecutionResult? GetDependencyOutput(string taskId);
    string? GetVariable(string key);
    void SetVariable(string key, string? value);
    DateTime ExecutionTime { get; }
    int? TimeoutMs { get; }
}




