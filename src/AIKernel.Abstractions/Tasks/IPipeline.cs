namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく IPipeline の契約を定義します。
/// </summary>
public interface IPipeline
{
    string PipelineId { get; }
    string Name { get; }
    string? Description { get; }
    IReadOnlyList<ITask> Tasks { get; }
    IReadOnlyDictionary<string, IReadOnlyList<string>> Dependencies { get; }
    string Version { get; }
}




