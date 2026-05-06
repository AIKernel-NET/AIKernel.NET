namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 に基づく IRelationResolver の契約を定義します。
/// </summary>
public interface IRelationResolver
{
    Task<AIKernel.Dtos.Rom.ResolvableEntity?> ResolveAsync(string referenceId, CancellationToken cancellationToken = default);
    Task<bool> CanResolveAsync(string referenceId, CancellationToken cancellationToken = default);
}



