namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく ITask の契約を定義します。
/// </summary>
public interface ITask
{
    string TaskId { get; }
    string Name { get; }
    string? Description { get; }
    TaskType TaskType { get; }
    Task<string?> ExecuteAsync(ITaskContext context, CancellationToken cancellationToken = default);
    IReadOnlyDictionary<string, string>? GetInputSchema();
    IReadOnlyDictionary<string, string>? GetOutputSchema();
    bool CanExecute(ITaskContext context);
}




