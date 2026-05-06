namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IModelMessage の契約を定義します。
/// </summary>
public interface IModelMessage
{
    string Role { get; }
    string Content { get; }
}




