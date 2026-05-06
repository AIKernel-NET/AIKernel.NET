namespace AIKernel.Abstractions.Tasks;

/// <summary>
/// UC-29 に基づく ITaskSchema の契約を定義します。
/// </summary>
public interface ITaskSchema
{
    string Name { get; }
    string Version { get; }
    IReadOnlyDictionary<string, string> Fields { get; }
}




